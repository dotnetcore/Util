using Microsoft.AspNetCore.Builder;
using Util.Ui.Sources.Spa.AngularCli;
using Util.Ui.Sources.Spa;

namespace Util.Ui.NgZorro;

/// <summary>
/// NgZorro配置扩展
/// </summary>
public static class WebApplicationExtensions {
    /// <summary>
    /// ClientApp
    /// </summary>
    private const string SourcePath = "ClientApp";

    /// <summary>
    /// 配置NgZorro应用
    /// </summary>
    /// <param name="app">Web应用</param>
    public static WebApplication UseNgZorro( this WebApplication app ) {
        app.CheckNull( nameof( app ) );
        AddEndpoints( app );
        app.UseAngular( spa => {
            spa.Options.SourcePath = SourcePath;
            if ( app.Environment.IsDevelopment() )
                spa.UseAngularCliServer( "start" );
        } );
        return app;
    }

    /// <summary>
    /// 添加路由端点
    /// </summary>
    private static void AddEndpoints( WebApplication app ) {
        app.CheckNull( nameof( app ) );
        app.UseStaticFiles();
        app.UseSpaStaticFiles();
        app.UseRouting();
#pragma warning disable ASP0014
        app.UseEndpoints( builder => {
            builder.MapRazorPages();
            builder.MapControllers();
        } );
#pragma warning restore ASP0014
    }

    /// <summary>
    /// 配置NgZorro应用
    /// </summary>
    /// <param name="app">Web应用</param>
    /// <param name="action">配置Spa操作</param>
    public static WebApplication UseNgZorro( this WebApplication app, Action<Microsoft.AspNetCore.SpaServices.ISpaBuilder> action ) {
        app.CheckNull( nameof( app ) );
        AddEndpoints( app );
        if ( app.Environment.IsDevelopment() == false )
            return app;
        if ( action == null )
            return app;
        app.UseSpa( spa => {
            if ( app.Environment.IsDevelopment() )
                action( spa );
        });
        return app;
    }

    /// <summary>
    /// 配置NgZorro应用
    /// </summary>
    /// <param name="app">Web应用</param>
    /// <param name="developmentServerBaseUri">开发服务器基地址,范例: http://localhost:5000</param>
    /// <param name="isAutoStartAngularServer">是否自动启动Angular服务器,默认值: true</param>
    public static WebApplication UseNgZorro( this WebApplication app, string developmentServerBaseUri, bool isAutoStartAngularServer = true ) {
        app.CheckNull( nameof( app ) );
        var port = new Uri( developmentServerBaseUri ).Port;
        return app.UseNgZorro( port, isAutoStartAngularServer );
    }

    /// <summary>
    /// 配置NgZorro应用
    /// </summary>
    /// <param name="app">Web应用</param>
    /// <param name="port">开发服务器端口号</param>
    /// <param name="isAutoStartAngularServer">是否自动启动Angular服务器,默认值: true</param>
    public static WebApplication UseNgZorro( this WebApplication app, int port, bool isAutoStartAngularServer = true ) {
        app.CheckNull( nameof( app ) );
        return isAutoStartAngularServer ? UseCustomSpa( app, port ) : UseSpa( app, $"http://localhost:{port}" );
    }

    /// <summary>
    /// 使用官方SPA实现
    /// </summary>
    private static WebApplication UseSpa( WebApplication app, string developmentServerBaseUri ) {
        app.CheckNull( nameof( app ) );
        AddEndpoints( app );
        app.UseSpa( spa => {
            spa.Options.SourcePath = SourcePath;
            if ( app.Environment.IsDevelopment() )
                spa.UseProxyToSpaDevelopmentServer( developmentServerBaseUri );
        } );
        return app;
    }

    /// <summary>
    /// 使用SPA扩展实现
    /// </summary>
    private static WebApplication UseCustomSpa( WebApplication app, int port ) {
        app.CheckNull( nameof( app ) );
        AddEndpoints( app );
        app.UseAngular( spa => {
            spa.Options.SourcePath = SourcePath;
            spa.Options.DevServerPort = port;
            if ( app.Environment.IsDevelopment() )
                spa.UseAngularCliServer( "start" );
        } );
        return app;
    }
}