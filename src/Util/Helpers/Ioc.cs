using System;
using Microsoft.Extensions.DependencyInjection;
using Util.DependencyInjection;
using Container = Util.DependencyInjection.Container;

namespace Util.Helpers {
    /// <summary>
    /// 容器
    /// </summary>
    public static class Ioc {
        /// <summary>
        /// 默认容器
        /// </summary>
        private static readonly Container DefaultContainer = new Container();

        /// <summary>
        /// 创建容器
        /// </summary>
        /// <param name="configs">依赖配置</param>
        public static IContainer CreateContainer( params IConfig[] configs ) {
            var container = new Container();
            container.Register( configs );
            return container;
        }

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <typeparam name="T">实例类型</typeparam>
        public static T Create<T>() {
            return DefaultContainer.Create<T>();
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="type">对象类型</param>
        public static object Create( Type type ) {
            return DefaultContainer.Create( type );
        }

        /// <summary>
        /// 作用域开始
        /// </summary>
        public static IScope BeginScope() {
            return DefaultContainer.BeginScope();
        }

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="configs">依赖配置</param>
        public static void Register( params IConfig[] configs ) {
            DefaultContainer.Register( null, null, configs );
        }

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="configs">依赖配置</param>
        public static IServiceProvider Register( IServiceCollection services, params IConfig[] configs ) {
            return DefaultContainer.Register( services, null, configs );
        }

        /// <summary>
        /// 释放容器
        /// </summary>
        public static void Dispose() {
            DefaultContainer.Dispose();
        }
    }
}
