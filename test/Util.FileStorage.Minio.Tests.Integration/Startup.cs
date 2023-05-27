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
            .AddUtil( options => {
                Util.Helpers.Environment.SetDevelopment();
                var minioEndpoint = Util.Helpers.Environment.IsDevelopment() ? "minio-endpoint.a.com" : "minio-dev.common:9000";
                options.UseMinio( minioOptions => minioOptions.Endpoint( minioEndpoint )
                    .AccessKey( "rfgzi0KnOhM3CCrc" ).SecretKey( "2x0wzz6f1QzwrvJONXda2Y59rZ1WdvTG" )
                    .DefaultBucketName( "Util.FileStorage.Minio.Test" )
                    .UseSSL( Util.Helpers.Environment.IsDevelopment() )
                );
            } );
    }

    /// <summary>
    /// 配置服务
    /// </summary>
    public void ConfigureServices( IServiceCollection services ) {
	    services.AddLogging( logBuilder => logBuilder.AddXunitOutput() );
		services.AddSingleton<ISession, TestSession>();
    }
}