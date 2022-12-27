using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Util.Dependency;
using Util.Reflections;

namespace Util.Infrastructure {
    /// <summary>
    /// 依赖服务注册器 - 用于扫描注册ISingletonDependency,IScopeDependency,ITransientDependency
    /// </summary>
    public class DependencyServiceRegistrar : IServiceRegistrar {
        /// <summary>
        /// 获取标识
        /// </summary>
        public static int GetId() => 100;
        
        /// <summary>
        /// 标识
        /// </summary>
        public int Id => GetId();

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled => ServiceRegistrarConfig.Instance.IsEnabled( GetId() );

        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="serviceContext">服务上下文</param>
        public Action Register( ServiceContext serviceContext ) {
            return () => {
                serviceContext.HostBuilder.ConfigureServices( ( context, services ) => {
                    RegisterDependency<ISingletonDependency>( services, serviceContext.TypeFinder, ServiceLifetime.Singleton );
                    RegisterDependency<IScopeDependency>( services, serviceContext.TypeFinder, ServiceLifetime.Scoped );
                    RegisterDependency<ITransientDependency>( services, serviceContext.TypeFinder, ServiceLifetime.Transient );
                } );
            };
        }

        /// <summary>
        /// 注册依赖
        /// </summary>
        private void RegisterDependency<TDependencyInterface>( IServiceCollection services, ITypeFinder finder, ServiceLifetime lifetime ) {
            var types = finder.Find<TDependencyInterface>();
            foreach ( var type in types ) {
                var interfaceTypes = Util.Helpers.Reflection.GetDirectInterfaceTypes( type,typeof( TDependencyInterface ) );
                RegisterType( services, type, interfaceTypes, lifetime );
            }
        }

        /// <summary>
        /// 注册类型
        /// </summary>
        private void RegisterType( IServiceCollection services, Type type,List<Type> interfaceTypes, ServiceLifetime lifetime ) {
            interfaceTypes.ForEach( interfaceType => {
                var descriptor = new ServiceDescriptor( interfaceType, type, lifetime );
                services.TryAdd( descriptor );
            } );
        }
    }
}
