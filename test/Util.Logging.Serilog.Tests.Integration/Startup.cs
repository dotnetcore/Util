using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util.Logging.Serilog;
using Xunit.DependencyInjection.Logging;
using serilog = Serilog;

namespace Util.Logging.Tests; 

/// <summary>
/// 启动配置
/// </summary>
public class Startup {
    /// <summary>
    /// 配置主机
    /// </summary>
    public void ConfigureHost( IHostBuilder hostBuilder ) {
        AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
        hostBuilder.ConfigureDefaults( null )
            .AsBuild()
            .AddSerilog()
            .AddUtil();
    }

    /// <summary>
    /// 进程退出时释放日志实例,用于解决Seq无法写入的问题
    /// </summary>
    private void CurrentDomain_ProcessExit( object sender, EventArgs e ) {
        var log = (serilog.Core.Logger)serilog.Log.Logger;
        log.Dispose();
    }

    /// <summary>
    /// 配置服务
    /// </summary>
    public void ConfigureServices( IServiceCollection services ) {
	    services.AddLogging( logBuilder => logBuilder.AddXunitOutput() );
		services.AddSingleton<ILogContextAccessor, LogContextAccessor>();
    }
}