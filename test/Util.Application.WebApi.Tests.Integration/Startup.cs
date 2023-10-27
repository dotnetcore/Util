using EasyCaching.Core.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util.Applications.Locks;
using Util.Caching.EasyCaching;
using Util.Events.Infrastructure;
using Util.Helpers;
using Util.Http;
using Util.Infrastructure;
using Util.Sessions;
using Util.Tests.Middlewares;
using Xunit.DependencyInjection.Logging;

namespace Util.Applications {
    /// <summary>
    /// 启动配置
    /// </summary>
    public class Startup {
        /// <summary>
        /// 配置主机
        /// </summary>
        public void ConfigureHost( IHostBuilder hostBuilder ) {
            Environment.SetDevelopment();
            ServiceRegistrarConfig.Instance.DisableDependencyServiceRegistrar();
            ServiceRegistrarConfig.Instance.DisableLocalEventBusServiceRegistrar();
            var builder = hostBuilder.ConfigureDefaults( null )
                .ConfigureWebHostDefaults( webHostBuilder => {
                    webHostBuilder.UseTestServer()
                        .Configure( t => {
                            t.UseMiddleware<TestUserMiddleware>();
                            t.UseRouting();
                            t.UseEndpoints( endpoints => {
                                endpoints.MapControllers();
                            } );
                        } );
                } )
                .AsBuild()
                .AddLock();
            if ( Environment.IsDevelopment() ) {
                builder.AddMemoryCache( t => t.MaxRdSecond = 0 );
            }
            else {
                builder.AddRedisCache( t => {
                    t.MaxRdSecond = 0;
                    t.DBConfig.AllowAdmin = true;
                    t.DBConfig.KeyPrefix = "util.lock.test:";
                    t.DBConfig.Endpoints.Add( new ServerEndPoint( "127.0.0.1", 6379 ) );
                } );
            }
            builder.AddUtil();
        }

        /// <summary>
        /// 配置服务
        /// </summary>
        public void ConfigureServices( IServiceCollection services ) {
            services.AddLogging( logBuilder => logBuilder.AddXunitOutput() );
            services.AddControllers();
            services.AddTransient<LockTestService>();
            services.AddSingleton<ISession,UserSession>();
            services.AddTransient<IHttpClient>( t => {
                var client = new HttpClientService();
                client.SetHttpClient( t.GetService<IHost>().GetTestClient() );
                return client;
            } );
        }
    }
}
