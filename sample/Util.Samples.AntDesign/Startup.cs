using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Util.Datas.Ef;
using Util.Logs.Extensions;
using Util.Samples.Data;
using Util.Ui.Extensions;
using Util.Webs.Extensions;

namespace Util.Samples {
    /// <summary>
    /// ��������
    /// </summary>
    public class Startup {
        /// <summary>
        /// ��ʼ����������
        /// </summary>
        /// <param name="configuration">����</param>
        public Startup( IConfiguration configuration ) {
            Configuration = configuration;
        }

        /// <summary>
        /// ����
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// ���÷���
        /// </summary>
        public void ConfigureServices( IServiceCollection services ) {
            //ע��Razor��ͼ����·��
            services.AddRazorViewLocationExpander();

            //���Mvc����
            services.AddMvc( options => options.EnableEndpointRouting = false
                //options.Filters.Add( new AutoValidateAntiforgeryTokenAttribute() );
             ).AddNewtonsoftJson().AddRazorPageConventions();

            //���NLog��־����
            services.AddNLog();

            //���EF������Ԫ
            //====== ֧��Sql Server 2012+ ==========
            services.AddUnitOfWork<ISampleUnitOfWork, Util.Samples.Data.UnitOfWorks.SqlServer.SampleUnitOfWork>( Configuration.GetConnectionString( "DefaultConnection" ) );
            //======= ֧��Sql Server 2005+ ==========
            //services.AddUnitOfWork<ISampleUnitOfWork, Util.Samples.Data.UnitOfWorks.SqlServer.SampleUnitOfWork>( builder => {
            //    builder.UseSqlServer( Configuration.GetConnectionString( "DefaultConnection" ), option => option.UseRowNumberForPaging() );
            //} );
            //======= ֧��PgSql =======
            //services.AddUnitOfWork<ISampleUnitOfWork, Util.Samples.Data.UnitOfWorks.PgSql.SampleUnitOfWork>( Configuration.GetConnectionString( "PgSqlConnection" ) );
            //======= ֧��MySql =======
            //services.AddUnitOfWork<ISampleUnitOfWork, Util.Samples.Data.UnitOfWorks.MySql.SampleUnitOfWork>( Configuration.GetConnectionString( "MySqlConnection" ) );

            //���Swagger
            //services.AddSwaggerGen( options => {
            //    options.SwaggerDoc( "v1", new Info { Title = "Util Api Demo", Version = "v1" } );
            //    options.IncludeXmlComments( Path.Combine( AppContext.BaseDirectory, "Util.Samples.AntDesign.xml" ) );
            //} );
        }

        /// <summary>
        /// ���ÿ�����������ܵ�
        /// </summary>
        public void ConfigureDevelopment( IApplicationBuilder app ) {
            app.UseDeveloperExceptionPage();
            app.UseWebpackDevMiddleware( new WebpackDevMiddlewareOptions {
                HotModuleReplacement = true
            } );
            //app.UseSwaggerX();
            CommonConfig( app );
        }

        /// <summary>
        /// ����������������ܵ�
        /// </summary>
        public void ConfigureProduction( IApplicationBuilder app ) {
            app.UseExceptionHandler( "/Error" );
            app.UseHsts();
            CommonConfig( app );
        }

        /// <summary>
        /// ��������
        /// </summary>
        private void CommonConfig( IApplicationBuilder app ) {
            app.UseErrorLog();
            app.UseStaticFiles();
            app.UseAuthentication();
            ConfigRoute( app );
        }

        /// <summary>
        /// ·������,֧������
        /// </summary>
        private void ConfigRoute( IApplicationBuilder app ) {
            app.UseMvc( routes => {
                routes.MapSpaFallbackRoute( "spa-fallback", new { controller = "Home", action = "Index" } );
            } );
        }
    }
}
