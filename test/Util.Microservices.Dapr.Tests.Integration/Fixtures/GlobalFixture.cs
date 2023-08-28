using Serilog;
using Util.Logging.Serilog;

namespace Util.Microservices.Dapr.Tests.Fixtures;

/// <summary>
/// 全局测试设置
/// </summary>
public class GlobalFixture : IAsyncDisposable {
    /// <summary>
    /// app_webapi
    /// </summary>
    public const string WebApiAppId = "app_webapi";
    /// <summary>
    /// app_pubsub
    /// </summary>
    public const string PubsubAppId = "app_pubsub";
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
        StopDapr();
        ConfigLog();
        var loggerFactory = Ioc.Create<ILoggerFactory>();
        var log = loggerFactory.CreateLogger( "Util.Microservices.Dapr.Tests.Integration" );
        var command = ExecuteDaprRunCommand( log, WebApiAppId, "Util.Microservices.Dapr.WebApiSample", 
            Config.GetValue<int>( "DaprPorts:WebApi:AppPort" ),
            Config.GetValue<int>( "DaprPorts:WebApi:HttpPort" ),
            Config.GetValue<int>( "DaprPorts:WebApi:GrpcPort" )
        );
        ExecuteDaprRunCommand( log, PubsubAppId, "Util.Microservices.Dapr.PubsubSample",
            Config.GetValue<int>( "DaprPorts:Pubsub:AppPort" ),
            Config.GetValue<int>( "DaprPorts:Pubsub:HttpPort" ),
            Config.GetValue<int>( "DaprPorts:Pubsub:GrpcPort" )
        );
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
    private DaprRunCommand ExecuteDaprRunCommand( Microsoft.Extensions.Logging.ILogger log,string appId,string project,
        int appPort,int daprHttpPort,int daprGrpcPort ) {
        var command = DaprRunCommand.Create( appId );
        if ( project.IsEmpty() == false )
            command.Project( $"../../../../../test/{project}/{project}.csproj" );
        command.AppPort( appPort )
            .DaprHttpPort( daprHttpPort )
            .DaprGrpcPort( daprGrpcPort )
            .ComponentsPath( "Resources/components/" )
            .ConfigPath( "Resources/configuration/config.yaml" )
            .Log( log )
            .Execute();
        return command;
    }

    /// <summary>
    /// 测试清理
    /// </summary>
    public async ValueTask DisposeAsync() {
        await Task.Delay( 3000 );
        DaprStopCommand.Create( WebApiAppId ).Execute();
        DaprStopCommand.Create( PubsubAppId ).Execute();
        StopDapr();
        CommandLine.ExecutePowerShell( "Stop-Process -Name \"dotnet*\"" );
    }

    /// <summary>
    /// 停止Dapr进程
    /// </summary>
    private void StopDapr() {
        CommandLine.ExecutePowerShell( "Stop-Process -Name \"Util.Microservices.Dapr*\"" );
        CommandLine.ExecutePowerShell( "Stop-Process -Name \"dapr*\"" );
    }
}