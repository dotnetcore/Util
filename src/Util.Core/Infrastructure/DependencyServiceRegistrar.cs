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
        /// 获取服务名
        /// </summary>
        public static string ServiceName => "Util.Infrastructure.DependencyServiceRegistrar";

        /// <summary>
        /// 排序号
        /// </summary>
        public int OrderId => 100;

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled => ServiceRegistrarConfig.IsEnabled( ServiceName );

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
