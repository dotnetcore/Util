using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util.Aop;
using Util.Data.EntityFrameworkCore;
using Util.Dates;
using Util.Helpers;
using Util.Http;
using Util.Tests.UnitOfWorks;
using Xunit.DependencyInjection.Logging;

namespace Util.Applications; 

/// <summary>
/// 启动配置
/// </summary>
public class Startup {
    /// <summary>
    /// 配置主机
    /// </summary>
    public void ConfigureHost( IHostBuilder hostBuilder ) {
        Environment.SetDevelopment();
        hostBuilder.ConfigureDefaults( null )
            .ConfigureWebHostDefaults( webHostBuilder => {
                webHostBuilder.UseTestServer()
                    .Configure( t => {
                        t.UseRouting();
                        t.UseEndpoints( endpoints => {
                            endpoints.MapControllers();
                        } );
                    } );
            } )
            .AsBuild()
            .AddUtc()
            .AddAop()
            .AddPgSqlUnitOfWork<ITestUnitOfWork, PgSqlUnitOfWork>( Config.GetConnectionString( "connection" ) )
            .AddUtil();
    }

    /// <summary>
    /// 配置服务
    /// </summary>
    public void ConfigureServices( IServiceCollection services ) {
        services.AddLogging( logBuilder => logBuilder.AddXunitOutput() );
        services.AddControllers();
        services.AddTransient<IHttpClient>( t => {
            var client = new HttpClientService();
            client.SetHttpClient( t.GetService<IHost>().GetTestClient() );
            return client;
        } );
        InitDatabase( services );
    }

    /// <summary>
    /// 初始化数据库
    /// </summary>
    private void InitDatabase( IServiceCollection services ) {
        var unitOfWork = services.BuildServiceProvider().GetService<ITestUnitOfWork>();
        unitOfWork.EnsureDeleted();
        unitOfWork.EnsureCreated();
    }
}