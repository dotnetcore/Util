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
        /// 创建实例
        /// </summary>
        /// <typeparam name="T">实例类型</typeparam>
        public static T Create<T>() {
            return Container.Create<T>();
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="type">对象类型</param>
        public static object Create( Type type ) {
            return Container.Create( type );
        }

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="configs">依赖配置</param>
        public static void Register( params IConfig[] configs ) {
            Container.Register( null, null, configs );
        }

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="configs">依赖配置</param>
        public static IServiceProvider Register( IServiceCollection services, params IConfig[] configs ) {
            return Container.Register( services, null, configs );
        }
    }
}
