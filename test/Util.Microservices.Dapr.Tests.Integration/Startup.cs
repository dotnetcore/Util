using Util.Logging.Serilog;

namespace Util.Microservices.Dapr.Tests; 

/// <summary>
/// 启动配置
/// </summary>
public class Startup {
    /// <summary>
    /// 配置主机
    /// </summary>
    public void ConfigureHost( IHostBuilder hostBuilder ) {
        Util.Helpers.Environment.SetDevelopment();
        hostBuilder.ConfigureDefaults( null )
            .AsBuild()
            .AddSerilog( "Util.Microservices.Dapr.Tests.Integration" )
            .AddDapr( t => t.AppId = "app_webapi", builder => {
                builder.UseHttpEndpoint( $"http://127.0.0.1:{Config.GetValue( "DaprPorts:WebApi:HttpPort" )}" )
                    .UseGrpcEndpoint( $"http://127.0.0.1:{Config.GetValue( "DaprPorts:WebApi:GrpcPort" )}" );
            } )
            .AddUtil();
    }

    /// <summary>
    /// 配置服务
    /// </summary>
    public void ConfigureServices( IServiceCollection services ) {
        services.AddLogging( logBuilder => logBuilder.AddXunitOutput() );
        Ioc.SetServiceProviderAction( services.BuildServiceProvider );
    }
}