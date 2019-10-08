using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util.Dependency;

namespace Util.Samples {
    /// <summary>
    /// Ӧ�ó���
    /// </summary>
    public class Program {
        /// <summary>
        /// Ӧ�ó�����ڵ�
        /// </summary>
        /// <param name="args">��ڵ����</param>
        public static void Main( string[] args ) {
            CreateHostBuilder( args ).Build().Run();
        }

        /// <summary>
        /// ��������������
        /// </summary>
        public static IHostBuilder CreateHostBuilder( string[] args ) =>
            Host.CreateDefaultBuilder( args )
                .UseServiceProviderFactory( new ServiceProviderFactory() )
                .ConfigureServices( services => services.AddHttpContextAccessor() )
                .ConfigureWebHostDefaults( builder => builder.UseStartup<Startup>() );
    }
}
