using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Util {
    /// <summary>
    /// 服务扩展
    /// </summary>
    public static class ServiceCollectionExtensions {
        /// <summary>
        /// 获取配置实例
        /// </summary>
        /// <param name="services">服务集合</param>
        public static IConfiguration GetConfiguration( this IServiceCollection services ) {
            return services.GetSingletonInstance<IConfiguration>();
        }

        /// <summary>
        /// 获取单例实例
        /// </summary>
        /// <param name="services">服务集合</param>
        public static T GetSingletonInstance<T>( this IServiceCollection services ) {
            var descriptor = services.FirstOrDefault( t => t.ServiceType == typeof( T ) && t.Lifetime == ServiceLifetime.Singleton );
            if( descriptor == null )
                return default;
            if( descriptor.ImplementationInstance != null )
                return (T)descriptor.ImplementationInstance;
            if( descriptor.ImplementationFactory != null )
                return (T)descriptor.ImplementationFactory.Invoke( null );
            return default;
        }
    }
}
