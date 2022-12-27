using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Util.Ui.NgZorro {
    /// <summary>
    /// NgZorro配置扩展
    /// </summary>
    public static class WebApplicationExtensions {
        /// <summary>
        /// 配置NgZorro应用
        /// </summary>
        /// <param name="app">Web应用</param>
        /// <param name="action">配置Spa操作</param>
        public static WebApplication UseNgZorro( this WebApplication app, Action<ISpaBuilder> action ) {
            app.CheckNull( nameof( app ) );
            action.CheckNull( nameof( action ) );
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseRouting();
            app.UseEndpoints( endpoints => {
                if ( app.Environment.IsDevelopment() ) {
                    endpoints.MapRazorPages();
                    endpoints.MapControllerRoute( "default", "{controller}/{action=Index}/{id?}" );
                }
            } );
            app.UseSpa( action );
            return app;
        }

        /// <summary>
        /// 配置NgZorro应用
        /// </summary>
        /// <param name="app">Web应用</param>
        /// <param name="developmentServerBaseUri">开发服务器基地址,范例: http://localhost:5000</param>
        public static WebApplication UseNgZorro( this WebApplication app, string developmentServerBaseUri ) {
            app.CheckNull( nameof( app ) );
            return app.UseNgZorro( spa => {
                spa.Options.SourcePath = "ClientApp";
                if ( app.Environment.IsDevelopment() )
                    spa.UseProxyToSpaDevelopmentServer( developmentServerBaseUri );
            } );
        }
    }
}
