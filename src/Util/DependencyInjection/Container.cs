using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Util.DependencyInjection {
    /// <summary>
    /// Autofac对象容器
    /// </summary>
    internal static class Container {
        /// <summary>
        /// 容器
        /// </summary>
        private static IContainer _container;

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        public static T Create<T>() {
            return _container.Resolve<T>();
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="type">对象类型</param>
        public static object Create( Type type ) {
            return _container.Resolve( type );
        }

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="actionBefore">注册前操作</param>
        /// <param name="configs">依赖配置</param>
        public static IServiceProvider Register( IServiceCollection services, Action<ContainerBuilder> actionBefore, params ConfigBase[] configs ) {
            var builder = CreateBuilder( services, actionBefore, configs );
            _container = builder.Build();
            return new AutofacServiceProvider( _container );
        }

        /// <summary>
        /// 创建容器生成器
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="action">注册前执行的操作</param>
        /// <param name="configs">依赖配置</param>
        public static ContainerBuilder CreateBuilder( IServiceCollection services, Action<ContainerBuilder> action, params ConfigBase[] configs ) {
            var builder = new ContainerBuilder();
            action?.Invoke( builder );
            foreach( var module in configs )
                builder.RegisterModule( module );
            if( services != null )
                builder.Populate( services );
            return builder;
        }
    }
}