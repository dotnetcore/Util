using System.Collections.Generic;
using Util.Helpers;
using Util.Tenants.Resolvers;

namespace Util.Tenants.Tests;

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
                        t.UseTenant();
                        t.UseRouting();
                        t.UseEndpoints( endpoints => {
                            endpoints.MapControllers();
                        } );
                    } );
            } )
            .AsBuild()
            .AddAop()
            .AddTenant( t => {
                var map = new Dictionary<string, string> { { "b.test.com", "b1" } };
                t.Resolvers.Add( new DomainTenantResolver( map ) { Priority = 90 } );
                t.Resolvers.Add( "a", new DomainTenantResolver( "{0}.a.test.com" ) { Priority = 80 } );
                map = new Dictionary<string, string> { { "c.test.com", "c1" } };
                t.Resolvers.Add( "b", new DomainTenantResolver( map ) { Priority = 70 } );
                t.Resolvers.Add( "c", new DomainTenantResolver( "{0}.b.test.com" ) { Priority = 100 } );
            } )
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
    }
}