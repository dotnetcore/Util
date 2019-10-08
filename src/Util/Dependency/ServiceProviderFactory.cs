using System;
using System.Text;
using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Util.Helpers;
using Util.Sessions;

namespace Util.Dependency {
    /// <summary>
    /// 服务提供器工厂
    /// </summary>
    public class ServiceProviderFactory : IServiceProviderFactory<ContainerBuilder> {
        /// <summary>
        /// 创建容器生成器
        /// </summary>
        /// <param name="services">服务列表</param>
        public ContainerBuilder CreateBuilder( IServiceCollection services ) {
            Encoding.RegisterProvider( CodePagesEncodingProvider.Instance );
            services.AddSingleton<ISession, Session>();
            return Bootstrapper.Run( services );
        }

        /// <summary>
        /// 创建服务提供器
        /// </summary>
        /// <param name="containerBuilder">容器生成器</param>
        public IServiceProvider CreateServiceProvider( ContainerBuilder containerBuilder ) {
            if ( containerBuilder == null )
                throw new ArgumentNullException( nameof( containerBuilder ) );
            return Ioc.DefaultContainer.CreateServiceProvider( containerBuilder );
        }
    }
}
