using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util.FileStorage.Minio.Samples;
using Util.Sessions;
using Xunit.DependencyInjection.Logging;

namespace Util.FileStorage.Minio; 

/// <summary>
/// 启动配置
/// </summary>
public class Startup {
    /// <summary>
    /// 配置主机
    /// </summary>
    public void ConfigureHost( IHostBuilder hostBuilder ) {
        Util.Helpers.Environment.SetDevelopment();
        var minioEndpoint = Util.Helpers.Environment.IsDevelopment() ? "127.0.0.1:9000" : "minio-dev.common:9000";
        hostBuilder.ConfigureDefaults( null )
            .ConfigureWebHostDefaults( webHostBuilder => {
                webHostBuilder.UseTestServer()
                    .ConfigureServices( services => {
                        services.AddControllers();
                        services.AddHttpClient();
                    } )
                    .Configure( t => {
                        t.UseRouting();
                        t.UseEndpoints( endpoints => {
                            endpoints.MapControllers();
                        } );
                    } );
            } )
            .AsBuild()
            .AddMinio( options => options.Endpoint( minioEndpoint )
                .AccessKey( "admin123" ).SecretKey( "admin123" )
                .DefaultBucketName( "Util.FileStorage.Minio.Test" )
                .UseSSL( false )
            )
            .AddUtil();
    }

    /// <summary>
    /// 配置服务
    /// </summary>
    public void ConfigureServices( IServiceCollection services ) {
	    services.AddLogging( logBuilder => logBuilder.AddXunitOutput() );
		services.AddSingleton<ISession, TestSession>();
    }
}