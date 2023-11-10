using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util.Helpers;
using Util.Logging.Serilog;
using Xunit.DependencyInjection.Logging;

namespace Util.Logging.Tests; 

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
            .AsBuild()
            .AddExceptionless()
            .AddUtil();
    }

    /// <summary>
    /// 配置服务
    /// </summary>
    public void ConfigureServices( IServiceCollection services ) {
	    services.AddLogging( logBuilder => logBuilder.AddXunitOutput() );
		services.AddSingleton<ILogContextAccessor, LogContextAccessor>();
    }
}