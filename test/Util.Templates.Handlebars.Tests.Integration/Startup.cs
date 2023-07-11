using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit.DependencyInjection.Logging;

namespace Util.Templates.Handlebars.Tests.Integration; 

/// <summary>
/// 启动配置
/// </summary>
public class Startup {
    /// <summary>
    /// 配置主机
    /// </summary>
    public void ConfigureHost( IHostBuilder hostBuilder ) {
        hostBuilder.AddUtil();
    }

	/// <summary>
	/// 配置服务
	/// </summary>
	public void ConfigureServices( IServiceCollection services ) {
		services.AddLogging( logBuilder => logBuilder.AddXunitOutput() );
	}
}