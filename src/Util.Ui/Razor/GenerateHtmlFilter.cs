using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Globalization;
using Util.Helpers;
using File = System.IO.File;

namespace Util.Ui.Razor;

/// <summary>
/// 生成Html静态页面过滤器
/// </summary>
public class GenerateHtmlFilter : IAsyncPageFilter {
    /// <summary>
    /// 执行
    /// </summary>
    public async Task OnPageHandlerExecutionAsync( PageHandlerExecutingContext context, PageHandlerExecutionDelegate next ) {
        await next();
    }

    /// <summary>
    /// 选择操作
    /// </summary>
    public async Task OnPageHandlerSelectionAsync( PageHandlerSelectedContext context ) {
        var options = context.HttpContext.RequestServices.GetService<IOptions<RazorOptions>>()?.Value ?? new RazorOptions();
        if ( options.IsGenerateHtml == false )
            return;
        if ( context.ActionDescriptor.ViewEnginePath == "/Error" )
            return;
        var path = CreatePath( context, options );
        if ( string.IsNullOrWhiteSpace( path ) )
            return;
        var log = GetLogger( context );
        try {
            var html = await GetHtml( context );
            await WriteFile( path, html );
            log.LogDebug( $"Razor生成Html成功: Razor Path: {context.ActionDescriptor.ViewEnginePath}, Html Path: {path}" );
        }
        catch ( Exception exception ) {
            log.LogError(exception, $"Razor页面生成 html 失败: razor path: {context.ActionDescriptor.ViewEnginePath}" );
            throw;
        }
    }

    /// <summary>
    /// 获取日志记录器
    /// </summary>
    protected virtual ILogger<GenerateHtmlFilter> GetLogger( PageHandlerSelectedContext context ) {
        return context?.HttpContext?.RequestServices?.GetService<ILogger<GenerateHtmlFilter>>() ?? NullLogger<GenerateHtmlFilter>.Instance;
    }

    /// <summary>
    /// 创建Html文件路径
    /// </summary>
    private string CreatePath( PageHandlerSelectedContext context, RazorOptions options ) {
        var attribute = context?.ActionDescriptor?.ModelTypeInfo?.GetCustomAttribute<HtmlAttribute>();
        if ( attribute == null )
            return GetPath( context?.ActionDescriptor.ViewEnginePath, options.GenerateHtmlBasePath, options.GenerateHtmlFolder, options.GenerateHtmlSuffix );
        if ( attribute.Ignore )
            return string.Empty;
        if ( string.IsNullOrWhiteSpace( attribute.Path ) )
            return string.Empty;
        return attribute.Path;
    }

    /// <summary>
    /// 获取Html文件路径
    /// </summary>
    /// <param name="path">路径</param>
    /// <param name="basePath">基路径，默认值：/ClientApp/src/app</param>
    /// <param name="folder">html文件目录名称，默认值：html</param>
    /// <param name="htmlSuffix">html文件后缀，默认值：component.html</param>
    public static string GetPath( string path, string basePath = "/ClientApp/src/app",string folder = "html", string htmlSuffix = "component.html" ) {
        if ( string.IsNullOrWhiteSpace( path ) )
            return string.Empty;
        path = path.Kebaberize().ToLower().Trim( '\\' ).Trim( '/' );
        if ( path.Contains( "/" ) == false )
            return Util.Helpers.Url.JoinPath( basePath, $"{path}.{htmlSuffix}" );
        var lastIndex = path.LastIndexOf( "/", StringComparison.Ordinal );
        return Util.Helpers.Url.JoinPath( basePath, path.Substring( 0, lastIndex ), folder, $"{path.Substring( lastIndex + 1 )}.{htmlSuffix}" );
    }

    /// <summary>
    /// 获取页面Html
    /// </summary>
    private async Task<string> GetHtml( PageHandlerSelectedContext context ) {
        var serviceProvider = context.HttpContext.RequestServices;
        var engine = serviceProvider.GetService<IRazorViewEngine>();
        var activator = serviceProvider.GetService<IRazorPageActivator>();
        dynamic model = System.Convert.ChangeType( context.HandlerInstance, context.HandlerInstance.GetType(), CultureInfo.InvariantCulture );
        var actionContext = new ActionContext( context.HttpContext, model.RouteData, context.ActionDescriptor );
        var page = FindPage( engine, context.ActionDescriptor.RelativePath );
        await using var stringWriter = new StringWriter();
        var view = new RazorView( engine, activator, new List<IRazorPage>(), page, HtmlEncoder.Default, new DiagnosticListener( "ViewRenderService" ) );
        var viewContext = new ViewContext( actionContext, view, Reflection.GetPropertyValue( model, "ViewData" ), Reflection.GetPropertyValue( model, "TempData" ), stringWriter, new HtmlHelperOptions() ) {
            ExecutingFilePath = context.ActionDescriptor.RelativePath
        };
        var razorPage = (Page)page;
        razorPage.PageContext = model.PageContext;
        razorPage.ViewContext = viewContext;
        activator.Activate( razorPage, viewContext );
        await page.ExecuteAsync();
        return stringWriter.ToString();
    }

    /// <summary>
    /// 查找Razor页面
    /// </summary>
    private IRazorPage FindPage( IRazorViewEngine razorViewEngine, string pageName ) {
        var result = razorViewEngine.GetPage( null!, pageName );
        return result.Page;
    }

    /// <summary>
    /// 写入文件
    /// </summary>
    private async Task WriteFile( string path, string html ) {
        if ( string.IsNullOrWhiteSpace( html ) )
            return;
        path = Util.Helpers.Web.GetPhysicalPath( path );
        var directory = Path.GetDirectoryName( path );
        if ( string.IsNullOrWhiteSpace( directory ) )
            return;
        if ( Directory.Exists( directory ) == false )
            Directory.CreateDirectory( directory );
        await File.WriteAllTextAsync( path, html );
    }
}