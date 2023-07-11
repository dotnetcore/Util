using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util.Aop;
using Xunit.DependencyInjection.Logging;

namespace Util.Validation.Tests; 

/// <summary>
/// 启动配置
/// </summary>
public class Startup {
    /// <summary>
    /// 配置主机
    /// </summary>
    public void ConfigureHost( IHostBuilder hostBuilder ) {
        hostBuilder.AsBuild().AddAop().AddUtil();
    }

    /// <summary>
    /// 配置服务
    /// </summary>
    public void ConfigureServices( IServiceCollection services ) {
        services.AddLogging( logBuilder => logBuilder.AddXunitOutput() );
    }
}