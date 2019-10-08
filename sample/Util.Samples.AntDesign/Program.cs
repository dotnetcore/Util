using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util.Dependency;

namespace Util.Samples {
    /// <summary>
    /// 应用程序
    /// </summary>
    public class Program {
        /// <summary>
        /// 应用程序入口点
        /// </summary>
        /// <param name="args">入口点参数</param>
        public static void Main( string[] args ) {
            CreateHostBuilder( args ).Build().Run();
        }

        /// <summary>
        /// 创建主机生成器
        /// </summary>
        public static IHostBuilder CreateHostBuilder( string[] args ) =>
            Host.CreateDefaultBuilder( args )
                .UseServiceProviderFactory( new ServiceProviderFactory() )
                .ConfigureServices( services => services.AddHttpContextAccessor() )
                .ConfigureWebHostDefaults( builder => builder.UseStartup<Startup>() );
    }
}
