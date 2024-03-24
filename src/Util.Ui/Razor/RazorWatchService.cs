using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Util.Helpers;
using Util.Ui.Razor.Internal;

namespace Util.Ui.Razor;

/// <summary>
/// Razor页面监听服务
/// </summary>
public class RazorWatchService : IRazorWatchService {
    /// <summary>
    /// 文件监视器
    /// </summary>
    private readonly FileWatcher _watcher;
    /// <summary>
    /// Razor视图容器
    /// </summary>
    private RazorViewContainer _container;
    /// <summary>
    /// 分部视图路径解析器
    /// </summary>
    private readonly IPartViewPathResolver _resolver;
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
    /// 初始化Razor页面监听服务
    /// </summary>
    public RazorWatchService( IPartViewPathResolver resolver, HttpClient client,
        IActionDescriptorCollectionProvider provider, IOptions<RazorOptions> options ) {
        _watcher = new FileWatcher();
        _resolver = resolver;
        _client = client;
        _provider = provider;
        _options = options.Value;
    }

    /// <inheritdoc />
    public virtual async Task StartAsync( CancellationToken cancellationToken ) {
        WriteLog( "启动中..." );
        WriteLog( "准备初始化..." );
        InitRazorViewContainer();
        await Preheat( cancellationToken );
        WriteLog( "初始化完成." );
        await StartWatch( cancellationToken );
    }

    /// <summary>
    /// 写入控制台日志
    /// </summary>
    private void WriteLog( string content ) {
        Console.WriteLine( $"dbug: Util应用框架 - Razor监听服务 - {content}" );
    }

    /// <summary>
    /// 初始化Razor视图容器
    /// </summary>
    protected virtual void InitRazorViewContainer() {
        _container = new RazorViewContainer( _resolver );
        _container.Init( GetAllViewContents() );
    }

    /// <summary>
    /// 获取所有视图内容列表
    /// </summary>
    protected Dictionary<string, string> GetAllViewContents() {
        var result = new Dictionary<string, string>();
        var descriptors = GetPageActionDescriptors();
        foreach ( var descriptor in descriptors ) {
            var content = GetContent( descriptor.RelativePath );
            result.TryAdd( descriptor.RelativePath, content );
        }
        return result;
    }

    /// <summary>
    /// 获取页面操作描述符列表
    /// </summary>
    protected List<PageActionDescriptor> GetPageActionDescriptors() {
        return _provider.ActionDescriptors.Items.OfType<PageActionDescriptor>().ToList();
    }

    /// <summary>
    /// 获取Razor文件内容
    /// </summary>
    protected string GetContent( string relativePath ) {
        var path = Url.JoinPath( Common.GetCurrentDirectory(), relativePath );
        return Util.Helpers.File.ReadToString( path );
    }

    /// <summary>
    /// Razor页面预热
    /// </summary>
    protected async Task Preheat( CancellationToken cancellationToken ) {
        await Task.Factory.StartNew( async () => {
            await Task.Delay( 1000, cancellationToken );
            WriteLog( "Razor页面准备预热..." );
            var paths = _container.GetRandomPaths();
            foreach ( var path in paths )
                await Request( path, cancellationToken );
            WriteLog( "Razor页面预热完成..." );
        }, cancellationToken );
    }

    /// <summary>
    /// 生成Html
    /// </summary>
    /// <param name="path">视图路径</param>
    /// <param name="cancellationToken">取消令牌</param>
    public async Task Request( string path, CancellationToken cancellationToken = default ) {
        await Task.Delay( _options.HtmlRenderDelayOnRazorChange, cancellationToken );
        var requestPath = $"{GetApplicationUrl()}/view/{path.TrimStart( "/Pages".ToCharArray() ).TrimEnd( ".cshtml".ToCharArray() )}";
        await _client.GetAsync( requestPath, cancellationToken );
    }

    /// <summary>
    /// 获取应用地址
    /// </summary>
    protected string GetApplicationUrl() {
        var path = Url.JoinPath( Common.GetCurrentDirectory(), "Properties" );
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
    /// 启动监听器
    /// </summary>
    protected virtual Task StartWatch( CancellationToken cancellationToken ) {
        WriteLog( "开始监听..." );
        var path = Common.JoinPath( Common.GetCurrentDirectory(), "Pages" );
        _watcher.Path( path )
            .Filter( "*.cshtml" )
            .OnChangedAsync( async ( _, e ) => await GenerateAsync( e.FullPath, cancellationToken ) )
            .OnRenamedAsync( async ( _, e ) => await GenerateAsync( e.FullPath, cancellationToken ) )
            .Start();
        return Task.CompletedTask;
    }

    /// <summary>
    /// 生成Html
    /// </summary>
    private async Task GenerateAsync( string fullPath, CancellationToken cancellationToken ) {
        if ( IsCshtml( fullPath ) == false )
            return;
        EnableGenerateHtml();
        var file = new FileInfo( fullPath );
        var path = file.FullName.Replace( Common.GetCurrentDirectory(), "" ).Replace( "\\", "/" );
        WriteLog( $"发现修改: {file.FullName.Replace( "\\", "/" )}" );
        var viewPaths = _container.GetViewPaths( path );
        if ( viewPaths == null || viewPaths.Count == 0 ) {
            WriteLog( $"未找到可更新的视图路径: {path}" );
            return;
        }
        foreach ( var viewPath in viewPaths ) {
            WriteLog( $"请求生成: {path}" );
            await Request( viewPath, cancellationToken );
        }
    }

    /// <summary>
    /// 是否cshtml文件
    /// </summary>
    protected bool IsCshtml( string path ) {
        return path.EndsWith( ".cshtml", StringComparison.OrdinalIgnoreCase );
    }

    /// <summary>
    /// 启用Html生成
    /// </summary>
    protected void EnableGenerateHtml() {
        _options.IsGenerateHtml = true;
    }

    /// <inheritdoc />
    public virtual Task StopAsync( CancellationToken cancellationToken ) {
        WriteLog( "准备关闭服务..." );
        _watcher.Dispose();
        return Task.CompletedTask;
    }
}