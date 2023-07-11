using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util.Helpers;
using Util.Logging.Serilog;
using Xunit.DependencyInjection.Logging;

namespace Util.Generators.Razor.Tests.Integration {
    /// <summary>
    /// 启动配置
    /// </summary>
    public class Startup {
        /// <summary>
        /// 配置主机
        /// </summary>
        public void ConfigureHost( IHostBuilder hostBuilder ) {
            Environment.SetDevelopment();
            hostBuilder.ConfigureDefaults( null )
                .AsBuild()
                .AddSerilog()
                .AddUtil();
        }

		/// <summary>
		/// 配置服务
		/// </summary>
		public void ConfigureServices( IServiceCollection services ) {
			services.AddLogging( logBuilder => logBuilder.AddXunitOutput() );
		}
	}
}
