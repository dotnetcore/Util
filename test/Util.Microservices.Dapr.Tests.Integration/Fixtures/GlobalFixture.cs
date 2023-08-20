using Serilog;
using Util.Logging.Serilog;


namespace Util.Microservices.Dapr.Tests.Fixtures;

/// <summary>
/// 全局测试设置
/// </summary>
public class GlobalFixture : IDisposable {
    /// <summary>
    /// app_webapi
    /// </summary>
    public const string WebApiAppId = "app_webapi";
    /// <summary>
    /// Dapr Http端口
    /// </summary>
    public int DaprHttpPort { get; }
    /// <summary>
    /// Dapr Grpc端口
    /// </summary>
    public int DaprGrpcPort { get; }

    /// <summary>
    /// 测试初始化
    /// </summary>
    public GlobalFixture() {
        ConfigLog();
        var loggerFactory = Ioc.Create<ILoggerFactory>();
        var log = loggerFactory.CreateLogger( "Util.Microservices.Dapr.Tests.Integration" );
        var command = ExecuteDaprRunCommand( log, WebApiAppId, "Util.Microservices.Dapr.WebApiSample" );
        DaprHttpPort = command.GetDaprHttpPort();
        DaprGrpcPort = command.GetDaprGrpcPort();
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
    private DaprRunCommand ExecuteDaprRunCommand( Microsoft.Extensions.Logging.ILogger log,string appId,string project ) {
        var command = DaprRunCommand.Create( appId );
        command
            .Project( $"../../../../../test/{project}/{project}.csproj" )
            .AppPort( Config.GetValue<int>( "DaprPorts:AppPort" ) )
            .DaprHttpPort( Config.GetValue<int>( "DaprPorts:HttpPort" ) )
            .DaprGrpcPort( Config.GetValue<int>( "DaprPorts:GrpcPort" ) )
            .ComponentsPath( "Resources/components/" )
            .ConfigPath( "Resources/configuration/config.yaml" )
            .Log( log )
            .Execute();
        return command;
    }

    /// <summary>
    /// 测试清理
    /// </summary>
    public void Dispose() {
        DaprStopCommand.Create( WebApiAppId ).Execute();
    }
}