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
            .AddMinio( options => {
                options.Endpoint = Util.Helpers.Config.GetValue( "Minio:Endpoint" );
                options.AccessKey = Util.Helpers.Config.GetValue( "Minio:AccessKey" );
                options.SecretKey = Util.Helpers.Config.GetValue( "Minio:SecretKey" );
                options.DefaultBucketName = "Util.FileStorage.Minio.Test";
                options.UseSSL = false;
            } )
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