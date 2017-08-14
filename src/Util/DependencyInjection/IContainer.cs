using System;
using Microsoft.Extensions.DependencyInjection;

namespace Util.DependencyInjection {
    /// <summary>
    /// 容器
    /// </summary>
    public interface IContainer {
        /// <summary>
        /// 创建实例
        /// </summary>
        /// <typeparam name="T">实例类型</typeparam>
        T Create<T>();

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="type">对象类型</param>
        object Create( Type type );

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="configs">依赖配置</param>
        void Register( params IConfig[] configs );

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="configs">依赖配置</param>
        IServiceProvider Register( IServiceCollection services, params IConfig[] configs );

        /// <summary>
        /// 释放容器
        /// </summary>
        void Dispose();
    }
}
