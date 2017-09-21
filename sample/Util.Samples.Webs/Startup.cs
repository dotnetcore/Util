using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Util.Logs.Extensions;
using Util.Samples.Webs.Configs;

namespace Util.Samples.Webs {
    /// <summary>
    /// 启动配置
    /// </summary>
    public class Startup {
        /// <summary>
        /// 初始化启动配置
        /// </summary>
        /// <param name="configuration">配置</param>
        public Startup( IConfiguration configuration ) {
            Configuration = configuration;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 配置服务
        /// </summary>
        public IServiceProvider ConfigureServices( IServiceCollection services ) {
            //添加Mvc服务
            services.AddMvc().AddControllersAsServices();

            //添加NLog日志操作
            services.AddNLog();

            //添加Exceptionless日志操作
            //services.AddExceptionless( config => {
            //    config.ServerUrl = "http://127.0.0.1:8011";
            //    config.ApiKey = "oGBxMBfTQhdRJm1npjGgN1kNJvR6eYSWIpws8pvm";
            //} );

            //添加Ioc服务
            return services.AddIoc( new IocConfig() );
        }

        /// <summary>
        /// 配置请求管道
        /// </summary>
        public void Configure( IApplicationBuilder app, IHostingEnvironment env ) {
            ConfigExceptionHandler( app, env );
            app.UseStaticFiles();
            app.UseAuthentication();
            ConfigRoute( app );
        }

        /// <summary>
        /// 配置异常处理
        /// </summary>
        private void ConfigExceptionHandler( IApplicationBuilder app, IHostingEnvironment env ) {
            if( env.IsDevelopment() ) {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
                app.UseStatusCodePages();
                return;
            }
            app.UseExceptionHandler( "/Home/Error" );
        }

        /// <summary>
        /// 路由配置,支持区域
        /// </summary>
        private void ConfigRoute( IApplicationBuilder app ) {
            app.UseMvc( routes => {
                routes.MapRoute( "areaRoute", "{area:exists}/{controller}/{action=Index}/{id?}" );
                routes.MapRoute( "default", "{controller=Home}/{action=Index}/{id?}" );
            } );
        }
    }
}
