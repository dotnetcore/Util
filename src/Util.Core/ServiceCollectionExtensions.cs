using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Util.Configs;
using Util.Infrastructure;

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

        /// <summary>
        /// 添加配置
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="setupAction">服务配置操作</param>
        public static IServiceCollection AddOptions<TOptions>( this IServiceCollection services, Action<TOptions> setupAction ) where TOptions : class, new() {
            var options = new TOptions();
            setupAction?.Invoke( options );
            if( options is IOptions conig ) {
                foreach( var extension in conig.Extensions )
                    extension.AddServices( services );
            }
            if( setupAction != null )
                services.Configure( setupAction );
            return services;
        }

        /// <summary>
        /// 注册Util服务 
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="setupAction">服务配置操作</param>
        public static IServiceCollection AddUtil( this IServiceCollection services, Action<Options> setupAction = null ) {
            var configuration = services.GetConfiguration();
            Util.Helpers.Config.SetConfiguration( configuration );
            var bootstrapper = new Bootstrapper( services, setupAction, configuration );
            bootstrapper.Start();
            return services;
        }
    }
}
