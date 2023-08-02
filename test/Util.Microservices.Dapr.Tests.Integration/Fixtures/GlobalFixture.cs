using Serilog;
using Util.Logging.Serilog;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Util.Microservices.Dapr.Tests.Fixtures;

/// <summary>
/// 全局测试设置
/// </summary>
public class GlobalFixture : IDisposable {
    /// <summary>
    /// app_webapi
    /// </summary>
    public const string AppId = "app_webapi";
    /// <summary>
    /// Dapr Http端口
    /// </summary>
    public int DaprHttpPort { get; }

    /// <summary>
    /// 测试初始化
    /// </summary>
    public GlobalFixture() {
        ConfigLog();
        var loggerFactory = Ioc.Create<ILoggerFactory>();
        var log = loggerFactory.CreateLogger( "Util.Microservices.Dapr.Tests.Integration" );
        var command = ExecuteDaprRunCommand( log );
        DaprHttpPort = command.GetDaprHttpPort();
    }

    /// <summary>
    /// 配置日志
    /// </summary>
    private void ConfigLog() {
        var services = Ioc.GetServices();
        services.AddLogging( loggingBuilder => {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Seq( Config.GetValue( "SeqUrl" ) )
                .MinimumLevel.Verbose()
                .Enrich.FromLogContext()
                .Enrich.WithLogContext()
                .Enrich.WithProperty( "ApplicationName", "Util.Microservices.Dapr.Tests.Integration" )
                .CreateLogger();
            loggingBuilder.AddSerilog( Log.Logger );
        } );
    }

    /// <summary>
    /// 通过命令行启动Dapr
    /// </summary>
    private DaprRunCommand ExecuteDaprRunCommand( ILogger log ) {
        var command = DaprRunCommand.Create( AppId );
        command.Project( "../../../../../test/Util.Microservices.Dapr.WebApiSample/Util.Microservices.Dapr.WebApiSample.csproj" )
            .UseFreePorts()
            .Log( log )
            .Execute();
        return command;
    }

    /// <summary>
    /// 测试清理
    /// </summary>
    public void Dispose() {
        DaprStopCommand.Create( AppId ).Execute();
    }
}