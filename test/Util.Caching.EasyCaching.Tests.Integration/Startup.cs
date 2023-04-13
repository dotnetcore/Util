using EasyCaching.Core.Configurations;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Util.Aop;
using Xunit.DependencyInjection;
using Xunit.DependencyInjection.Logging;

namespace Util.Caching.EasyCaching {
    /// <summary>
    /// 启动配置
    /// </summary>
    public class Startup {
        /// <summary>
        /// 配置主机
        /// </summary>
        public void ConfigureHost( IHostBuilder hostBuilder ) {
            hostBuilder.ConfigureDefaults( null )
                .AddUtil( options => {
                    Util.Helpers.Environment.SetDevelopment();
                    options.UseAop()
                        .UseRedisCache( t => {
                            t.MaxRdSecond = 0;
                            t.DBConfig.AllowAdmin = true;
                            t.DBConfig.KeyPrefix = "test:";
                            t.DBConfig.Endpoints.Add( new ServerEndPoint( "192.168.31.157", 6379 ) );
                        } )
                        .UseMemoryCache( t => t.MaxRdSecond = 0 );
                } );
        }

        /// <summary>
        /// 配置日志提供程序
        /// </summary>
        public void Configure( ILoggerFactory loggerFactory, ITestOutputHelperAccessor accessor ) {
            loggerFactory.AddProvider( new XunitTestOutputLoggerProvider( accessor, ( s, logLevel ) => logLevel >= LogLevel.Trace ) );
        }
    }
}
