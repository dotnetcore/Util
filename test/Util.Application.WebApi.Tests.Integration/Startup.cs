using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Util.Applications.Locks;
using Util.Caching.EasyCaching;
using Util.Events.Infrastructure;
using Util.Helpers;
using Util.Http;
using Util.Infrastructure;
using Util.Tests.Middlewares;
using Xunit.DependencyInjection;
using Xunit.DependencyInjection.Logging;

namespace Util.Applications {
    /// <summary>
    /// ��������
    /// </summary>
    public class Startup {
        /// <summary>
        /// ��������
        /// </summary>
        public void ConfigureHost( IHostBuilder hostBuilder ) {
            ServiceRegistrarConfig.Instance.DisableDependencyServiceRegistrar();
            ServiceRegistrarConfig.Instance.DisableLocalEventBusServiceRegistrar();
            hostBuilder.ConfigureDefaults( null )
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
                .AddUtil( options => {
                    Environment.SetDevelopment();
                    options.UseLock()
                        .UseEasyCaching( easyCachingOptions => easyCachingOptions.UseInMemory() );
                } );
        }

        /// <summary>
        /// ���÷���
        /// </summary>
        public void ConfigureServices( IServiceCollection services ) {
            services.AddControllers();
            services.AddTransient<LockTestService>();
            services.AddTransient<IHttpClient>( t => {
                var client = new HttpClientService();
                client.SetHttpClient( t.GetService<IHost>().GetTestClient() );
                return client;
            } );
        }

        /// <summary>
        /// ������־�ṩ����
        /// </summary>
        public void Configure( ILoggerFactory loggerFactory, ITestOutputHelperAccessor accessor ) {
            loggerFactory.AddProvider( new XunitTestOutputLoggerProvider( accessor ) );
        }
    }
}
