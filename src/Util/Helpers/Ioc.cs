using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Util.Dependency;

namespace Util.Helpers {
    /// <summary>
    /// 容器
    /// </summary>
    public static partial class Ioc {
        /// <summary>
        /// 默认容器
        /// </summary>
        internal static readonly Container DefaultContainer = new Container();

        /// <summary>
        /// 创建容器
        /// </summary>
        /// <param name="configs">依赖配置</param>
        public static IContainer CreateContainer( params IConfig[] configs ) {
            var container = new Container();
            container.Register( null, builder => builder.EnableAop(), configs );
            return container;
        }

        /// <summary>
        /// 创建集合
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">服务名称</param>
        public static List<T> CreateList<T>( string name = null ) {
            return DefaultContainer.CreateList<T>( name );
        }

        /// <summary>
        /// 创建集合
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="type">对象类型</param>
        /// <param name="name">服务名称</param>
        public static List<T> CreateList<T>( Type type, string name = null ) {
            return ( (IEnumerable<T>)DefaultContainer.CreateList( type, name ) ).ToList();
        }

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">服务名称</param>
        public static T Create<T>( string name = null ) {
            return DefaultContainer.Create<T>( name );
        }

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="type">对象类型</param>
        /// <param name="name">服务名称</param>
        public static T Create<T>( Type type, string name = null ) {
            return (T)DefaultContainer.Create( type, name );
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
            DefaultContainer.Register( null, builder => builder.EnableAop(), configs );
        }

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="configs">依赖配置</param>
        public static IServiceProvider Register( IServiceCollection services, params IConfig[] configs ) {
            return DefaultContainer.Register( services, builder => builder.EnableAop(), configs );
        }

        /// <summary>
        /// 释放容器
        /// </summary>
        public static void Dispose() {
            DefaultContainer.Dispose();
        }
    }
}
