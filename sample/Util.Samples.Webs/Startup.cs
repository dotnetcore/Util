using System;
using System.IO;
using System.Xml.XPath;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Util.Datas.Ef;
using Util.Events.Default;
using Util.Logs.Extensions;
using Util.Samples.Webs.Datas;
using Util.Samples.Webs.Datas.SqlServer;
using Util.Webs.Extensions;

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
            //添加HttpContextAccessor服务
            services.AddHttpContextAccessor();

            //添加Mvc服务
            services.AddMvc().AddControllersAsServices();

            //添加NLog日志操作
            services.AddNLog();

            //添加事件总线服务
            services.AddEventBus();

            //添加工作单元
            services.AddUnitOfWork<ISampleUnitOfWork, SampleUnitOfWork>( Configuration.GetConnectionString( "DefaultConnection" ) );

            //添加Swagger
            services.AddSwaggerGen( c => {
                c.SwaggerDoc( "v1", new Info { Title = "Util Web Api Demo", Version = "v1" } );
                c.IncludeXmlComments( Path.Combine( AppContext.BaseDirectory, "Util.xml" ) );
                c.IncludeXmlComments( Path.Combine( AppContext.BaseDirectory, "Util.Webs.xml" ) );
                c.IncludeXmlComments( Path.Combine( AppContext.BaseDirectory, "Util.Samples.Webs.xml" ) );
            } );

            //添加Util基础设施服务
            return services.AddUtil();
        }

        /// <summary>
        /// 配置请求管道
        /// </summary>
        public void Configure( IApplicationBuilder app, IHostingEnvironment env ) {
            if( env.IsDevelopment() ) {
                DevelopmentConfig( app );
                return;
            }
            ProductionConfig( app );
        }

        /// <summary>
        /// 开发环境配置
        /// </summary>
        private void DevelopmentConfig( IApplicationBuilder app ) {
            app.UseBrowserLink();
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
            app.UseWebpackDevMiddleware( new WebpackDevMiddlewareOptions {
                HotModuleReplacement = true
            } );
            ConfigSwagger( app );
            CommonConfig( app );
        }

        /// <summary>
        /// 配置Swagger
        /// </summary>
        private void ConfigSwagger( IApplicationBuilder app ) {
            app.UseSwagger();
            app.UseSwaggerUI( c => {
                c.SwaggerEndpoint( "/swagger/v1/swagger.json", "api v1" );
            } );
        }

        /// <summary>
        /// 公共配置
        /// </summary>
        private void CommonConfig( IApplicationBuilder app ) {
            app.UseErrorLog();
            app.UseStaticFiles();
            app.UseAuthentication();
            ConfigRoute( app );
        }

        /// <summary>
        /// 路由配置,支持区域
        /// </summary>
        private void ConfigRoute( IApplicationBuilder app ) {
            app.UseMvc( routes => {
                routes.MapRoute( "areaRoute", "view/{area:exists}/{controller}/{action=Index}/{id?}" );
                routes.MapRoute( "default", "{controller=Home}/{action=Index}/{id?}" );
                routes.MapSpaFallbackRoute( "spa-fallback", new { controller = "Home", action = "Index" } );
            } );
        }

        /// <summary>
        /// 生产环境配置
        /// </summary>
        private void ProductionConfig( IApplicationBuilder app ) {
            app.UseExceptionHandler( "/Home/Error" );
            CommonConfig( app );
        }
    }
}
