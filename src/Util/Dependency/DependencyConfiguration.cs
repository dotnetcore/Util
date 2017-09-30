using System;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Util.Helpers;
using Util.Reflections;

namespace Util.Dependency {
    /// <summary>
    /// 依赖配置
    /// </summary>
    public class DependencyConfiguration {
        /// <summary>
        /// 服务集合
        /// </summary>
        private readonly IServiceCollection _services;
        /// <summary>
        /// 依赖配置
        /// </summary>
        private readonly IConfig[] _configs;
        /// <summary>
        /// 容器生成器
        /// </summary>
        private ContainerBuilder _builder;
        /// <summary>
        /// 类型查找器
        /// </summary>
        private IFind _finder;
        /// <summary>
        /// 程序集列表
        /// </summary>
        private List<Assembly> _assemblies;

        /// <summary>
        /// 初始化依赖配置
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="configs">依赖配置</param>
        public DependencyConfiguration( IServiceCollection services, IConfig[] configs ) {
            _services = services;
            _configs = configs;
        }

        /// <summary>
        /// 配置依赖
        /// </summary>
        public IServiceProvider Config() {
            return Ioc.DefaultContainer.Register( _services, RegistServices,_configs );
        }

        /// <summary>
        /// 注册服务集合
        /// </summary>
        private void RegistServices( ContainerBuilder builder ) {
            _builder = builder;
            RegistFinder();
            _assemblies = _finder.GetAssemblies();
            RegistDependency();
        }

        /// <summary>
        /// 注册类型查找器
        /// </summary>
        private void RegistFinder() {
            _finder = new WebFinder();
            _builder.AddSingleton( _finder );
        }

        /// <summary>
        /// 注册依赖
        /// </summary>
        private void RegistDependency() {
            RegistSingletonDependency();
            RegistScopeDependency();
            RegistTransientDependency();
        }

        /// <summary>
        /// 注册单例依赖
        /// </summary>
        private void RegistSingletonDependency() {
            _builder.RegisterTypes( GetTypes<ISingletonDependency>() ).AsImplementedInterfaces().PropertiesAutowired().SingleInstance();
        }

        /// <summary>
        /// 获取类型集合
        /// </summary>
        private Type[] GetTypes<T>() {
            return _finder.Find<T>( _assemblies ).ToArray();
        }

        /// <summary>
        /// 注册作用域依赖
        /// </summary>
        private void RegistScopeDependency() {
            _builder.RegisterTypes( GetTypes<IScopeDependency>() ).AsImplementedInterfaces().PropertiesAutowired().InstancePerLifetimeScope();
        }

        /// <summary>
        /// 注册瞬态依赖
        /// </summary>
        private void RegistTransientDependency() {
            _builder.RegisterTypes( GetTypes<ITransientDependency>() ).AsImplementedInterfaces().PropertiesAutowired().InstancePerDependency();
        }
    }
}
