using Util.FileStorage.Aliyun.Samples;

namespace Util.FileStorage.Aliyun;

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
            .AddAliyunOss( options => {
                options.Endpoint = Util.Helpers.Config.GetValue( "AliyunOss:Endpoint" );
                options.AccessKeyId = Util.Helpers.Config.GetValue( "AliyunOss:AccessKeyId" );
                options.AccessKeySecret = Util.Helpers.Config.GetValue( "AliyunOss:AccessKeySecret" );
                options.DefaultBucketName = "Util.AliyunOss.Test";
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