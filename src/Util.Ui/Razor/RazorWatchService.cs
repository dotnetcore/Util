using System.Reactive.Linq;
using System.Reactive.Subjects;
using Microsoft.Extensions.Configuration;
using Util.Helpers;
using Util.Ui.Razor.Internal;

namespace Util.Ui.Razor;

/// <summary>
/// Razor页面监视服务
/// </summary>
public class RazorWatchService : IRazorWatchService {
    /// <summary>
    /// 是否启动完成
    /// </summary>
    public static bool IsStartComplete { get; set; }
    /// <summary>
    /// 文件监视器
    /// </summary>
    private readonly FileWatcher _watcher;
    /// <summary>
    /// Razor视图容器
    /// </summary>
    private readonly RazorViewContainer _container;
    /// <summary>
    /// Http客户端
    /// </summary>
    private readonly HttpClient _client;
    /// <summary>
    /// 操作描述符集合提供器
    /// </summary>
    private readonly IActionDescriptorCollectionProvider _provider;
    /// <summary>
    /// Razor配置
    /// </summary>
    private readonly RazorOptions _options;
    /// <summary>
    /// 是否生成缺失的html
    /// </summary>
    private bool _isGenerateMissingHtml;
    /// <summary>
    /// 新增视图事件
    /// </summary>
    private readonly SequentialSimpleAsyncSubject<string> _addViewSubject;

    /// <summary>
    /// 初始化Razor页面监视服务
    /// </summary>
    public RazorWatchService( IServiceProvider serviceProvider, IPartViewPathResolver resolver, HttpClient client,
            IActionDescriptorCollectionProvider provider, IOptions<RazorOptions> options ) {
        Ioc.SetServiceProviderAction( () => serviceProvider );
        _watcher = new FileWatcher();
        _client = client;
        _provider = provider;
        _options = options.Value;
        _container = new RazorViewContainer( resolver );
        _addViewSubject = new SequentialSimpleAsyncSubject<string>();
        InitAddViewSubject();
    }

    /// <summary>
    /// 初始化添加视图事件
    /// </summary>
    private void InitAddViewSubject() {
        _addViewSubject.Where( path => path.IsEmpty() == false )
            .Delay( TimeSpan.FromSeconds( 1 ) )
            .SubscribeAsync( async path => {
                WriteLog( $"发现新增文件: {path}" );
                _container.AddView( path );
                EnableOverrideHtml( false );
                await Request( path );
                EnableOverrideHtml();
                await Task.Delay( 200 );
            } );
    }

    /// <summary>
    /// 启用Html覆盖
    /// </summary>
    protected void EnableOverrideHtml( bool isOverrideHtml = true ) {
        _options.EnableOverrideHtml = isOverrideHtml;
    }

    /// <summary>
    /// 发送请求
    /// </summary>
    /// <param name="path">视图路径</param>
    /// <param name="isWrite">是否写入日志</param>
    /// <param name="times">请求次数</param>
    public async Task Request( string path, bool isWrite = true, int times = 0 ) {
        try {
            times++;
            if ( times > 3 )
                return;
            await Task.Delay( TimeSpan.FromMilliseconds( _options.HtmlRenderDelayOnRazorChange ) );
            var requestPath = Url.JoinPath( GetApplicationUrl(), "view", path.RemoveStart( _options.RazorRootDirectory ).RemoveEnd( ".cshtml" ) );
            WriteLog( $"发送请求: {requestPath}", isWrite );
            var response = await _client.GetAsync( requestPath );
            if ( response.IsSuccessStatusCode ) {
                WriteLog( $"请求成功: {requestPath}", isWrite );
                return;
            }
            await Task.Delay( 2000 );
            if ( response.StatusCode == HttpStatusCode.NotFound ) {
                await AddView( path );
                return;
            }
            await Request( path, isWrite, times );
        }
        catch ( InvalidOperationException ) {
            await Task.Delay( 2000 );
            await Request( path, isWrite, times );
        }
    }

    /// <summary>
    /// 获取应用地址
    /// </summary>
    protected string GetApplicationUrl() {
        var path = GetProjectPath( "Properties" );
        var builder = new ConfigurationBuilder()
            .SetBasePath( path )
            .AddJsonFile( "launchSettings.json", true, false );
        var config = builder.Build();
        foreach ( var child in config.AsEnumerable() ) {
            if ( child.Key.Contains( "applicationUrl", StringComparison.OrdinalIgnoreCase ) )
                return child.Value;
        }
        return null;
    }

    /// <summary>
    /// 添加视图
    /// </summary>
    protected async Task AddView( string path ) {
        await _addViewSubject.OnNextAsync( path );
    }

    /// <inheritdoc />
    public virtual async Task StartAsync( CancellationToken cancellationToken ) {
        WriteLog( "启动中..." );
        WriteLog( "准备初始化..." );
        InitRazorViewContainer();
        await Task.Factory.StartNew( async () => {
            await Task.Delay( _options.StartInitDelay, cancellationToken );
            await GenerateAllHtml();
            await GenerateMissingHtml();
            await Preheat();
            IsStartComplete = true;
            WriteLog( "初始化完成." );
            await StartWatch();
        }, cancellationToken );
    }

    /// <summary>
    /// 写入控制台日志
    /// </summary>
    private void WriteLog( string content, bool isWrite = true ) {
        if ( isWrite == false )
            return;
        Console.WriteLine( $"dbug: {DateTime.Now.ToMillisecondString()} - Util应用框架 - Razor监听服务 - {content}" );
    }

    /// <summary>
    /// 初始化Razor视图容器
    /// </summary>
    protected virtual void InitRazorViewContainer() {
        _container.Init( GetAllViewPaths() );
    }

    /// <summary>
    /// 获取所有主视图路径列表
    /// </summary>
    protected List<string> GetAllViewPaths() {
        var result = new List<string>();
        var descriptors = GetPageActionDescriptors();
        foreach ( var descriptor in descriptors )
            result.Add( descriptor.RelativePath );
        return result.Distinct().ToList();
    }

    /// <summary>
    /// 获取页面操作描述符列表
    /// </summary>
    protected List<PageActionDescriptor> GetPageActionDescriptors() {
        return _provider.ActionDescriptors.Items.OfType<PageActionDescriptor>().ToList();
    }

    /// <summary>
    /// 重新生成全部html
    /// </summary>
    protected async Task GenerateAllHtml() {
        if ( _options.EnableGenerateAllHtml == false )
            return;
        WriteLog( "准备重新生成全部html..." );
        _isGenerateMissingHtml = true;
        EnableGenerateHtml();
        var requestPath = Url.JoinPath( GetApplicationUrl(), "api/html" );
        var response = await _client.GetAsync( requestPath );
        if ( response.IsSuccessStatusCode ) {
            WriteLog( "重新生成全部html完成..." );
            return;
        }
        var result = await response.Content.ReadAsStringAsync();
        WriteLog( "重新生成全部html失败..." );
        WriteLog( result );
    }

    /// <summary>
    /// 生成缺失的html
    /// </summary>
    protected async Task GenerateMissingHtml() {
        if ( _options.EnableGenerateAllHtml )
            return;
        WriteLog( "准备生成缺失的html..." );
        EnableGenerateHtml();
        EnableOverrideHtml( false );
        var fileBasePath = GetProjectPath( _options.GenerateHtmlBasePath );
        var files = Util.Helpers.File.GetAllFiles( fileBasePath, "*.html" );
        foreach ( var path in _container.GetMainViewPaths() ) {
            if ( Exists( files.Select( t => t.FullName ).ToList(), path ) )
                continue;
            _isGenerateMissingHtml = true;
            await Request( path );
        }
        EnableOverrideHtml();
        WriteLog( "生成缺失的html完成..." );
    }

    /// <summary>
    /// 启用Html生成
    /// </summary>
    protected void EnableGenerateHtml( bool isGenerateHtml = true ) {
        _options.IsGenerateHtml = isGenerateHtml;
    }

    /// <summary>
    /// 获取项目路径
    /// </summary>
    protected string GetProjectPath( string relativePath ) {
        return Url.JoinPath( Common.GetCurrentDirectory(), relativePath );
    }

    /// <summary>
    /// html是否存在
    /// </summary>
    protected bool Exists( List<string> htmlPaths, string razorPath ) {
        if ( string.Equals( razorPath, $"{_options.RazorRootDirectory}/Error.cshtml", StringComparison.OrdinalIgnoreCase ) )
            return true;
        var path = GenerateHtmlFilter.GetPath( razorPath.RemoveStart( _options.RazorRootDirectory ).RemoveEnd( ".cshtml" ), _options );
        return htmlPaths.Any( t => t.Replace( "\\", "/" ).EndsWith( path, StringComparison.OrdinalIgnoreCase ) );
    }

    /// <summary>
    /// Razor页面预热
    /// </summary>
    protected async Task Preheat() {
        if ( _isGenerateMissingHtml )
            return;
        if ( _options.EnablePreheat == false )
            return;
        WriteLog( "Razor页面准备预热..." );
        EnableGenerateHtml( false );
        var paths = _container.GetRandomPaths();
        foreach ( var path in paths )
            await Request( path, false );
        WriteLog( "Razor页面预热完成..." );
    }

    /// <summary>
    /// 启动监听器
    /// </summary>
    protected virtual Task StartWatch() {
        WriteLog( "开始监听..." );
        var path = GetProjectPath( _options.RazorRootDirectory.RemoveStart( "/" ) );
        _watcher.Path( path )
            .Filter( "*.cshtml" )
            .OnChangedAsync( async ( _, e ) => await GenerateAsync( e.FullPath ) )
            .OnRenamedAsync( async ( _, e ) => await GenerateAsync( e.FullPath ) )
            .Start();
        return Task.CompletedTask;
    }

    /// <summary>
    /// 生成Html
    /// </summary>
    private async Task GenerateAsync( string fullPath ) {
        if ( IsIgnore( fullPath ) )
            return;
        EnableGenerateHtml();
        var file = new FileInfo( fullPath );
        var path = file.FullName.Replace( Common.GetCurrentDirectory(), "" ).Replace( "\\", "/" );
        WriteLog( $"发现修改: {file.FullName.Replace( "\\", "/" )}" );
        var viewPaths = _container.GetViewPaths( path );
        if ( viewPaths == null || viewPaths.Count == 0 ) {
            await AddView( path );
            return;
        }
        foreach ( var viewPath in viewPaths )
            await Request( viewPath );
    }

    /// <summary>
    /// 是否忽略
    /// </summary>
    protected bool IsIgnore( string path ) {
        if ( path.EndsWith( ".cshtml", StringComparison.OrdinalIgnoreCase ) == false )
            return true;
        if ( path.Contains( "_ViewImports", StringComparison.OrdinalIgnoreCase ) )
            return true;
        return false;
    }

    /// <inheritdoc />
    public virtual Task StopAsync( CancellationToken cancellationToken ) {
        WriteLog( "准备关闭服务..." );
        _watcher.Dispose();
        return Task.CompletedTask;
    }
}