using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Util.Helpers;
using Util.Logging.Serilog;
using Xunit.DependencyInjection;
using Xunit.DependencyInjection.Logging;

namespace Util.Generators.Razor.Tests {
    /// <summary>
    /// 启动配置
    /// </summary>
    public class Startup {
        /// <summary>
        /// 配置主机
        /// </summary>
        public void ConfigureHost( IHostBuilder hostBuilder ) {
            hostBuilder.ConfigureDefaults( null )
                .ConfigureHostConfiguration( builder => {
                    Environment.SetDevelopment();
                } )
                .AddUtil( t => t.UseSerilog() );
        }

        /// <summary>
        /// 配置日志提供程序
        /// </summary>
        public void Configure( ILoggerFactory loggerFactory, ITestOutputHelperAccessor accessor ) {
            loggerFactory.AddProvider( new XunitTestOutputLoggerProvider( accessor ) );
        }
    }
}
