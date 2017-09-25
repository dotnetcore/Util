using System;
using AspectCore.DynamicProxy.Parameters;
using AspectCore.Extensions.Autofac;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Util.DependencyInjection {
    /// <summary>
    /// Autofac对象容器
    /// </summary>
    internal class Container : IContainer {
        /// <summary>
        /// 容器
        /// </summary>
        private Autofac.IContainer _container;
        /// <summary>
        /// HttpContext访问器
        /// </summary>
        private IHttpContextAccessor _accessor;

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        public T Create<T>() {
            try {
                LoadHttpContextAccessor();
            }
            catch {
                return _container.Resolve<T>();
            }
            if( _accessor?.HttpContext?.RequestServices != null )
                return _accessor.HttpContext.RequestServices.GetService<T>();
            return _container.Resolve<T>();
        }

        /// <summary>
        /// 加载HttpContext访问器
        /// </summary>
        private void LoadHttpContextAccessor() {
            if ( _accessor != null )
                return;
            _accessor = _container.Resolve<IHttpContextAccessor>();
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="type">对象类型</param>
        public object Create( Type type ) {
            try {
                LoadHttpContextAccessor();
            }
            catch {
                return _container.Resolve( type );
            }
            if( _accessor?.HttpContext?.RequestServices != null )
                return _accessor.HttpContext.RequestServices.GetService( type );
            return _container.Resolve( type );
        }

        /// <summary>
        /// 作用域开始
        /// </summary>
        public IScope BeginScope() {
            return new Scope( _container.BeginLifetimeScope() );
        }

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="configs">依赖配置</param>
        public void Register( params IConfig[] configs ) {
            Register( null, null, configs );
        }

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="configs">依赖配置</param>
        public IServiceProvider Register( IServiceCollection services, params IConfig[] configs ) {
            return Register( services, null, configs );
        }

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="actionBefore">注册前操作</param>
        /// <param name="configs">依赖配置</param>
        public IServiceProvider Register( IServiceCollection services, Action<ContainerBuilder> actionBefore, params IConfig[] configs ) {
            var builder = CreateBuilder( services, actionBefore, configs );
            //RegisterAop( builder );
            _container = builder.Build();
            return new AutofacServiceProvider( _container );
        }

        /// <summary>
        /// 创建容器生成器
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="actionBefore">注册前执行的操作</param>
        /// <param name="configs">依赖配置</param>
        public ContainerBuilder CreateBuilder( IServiceCollection services, Action<ContainerBuilder> actionBefore, params IConfig[] configs ) {
            var builder = new ContainerBuilder();
            actionBefore?.Invoke( builder );
            foreach( var config in configs )
                builder.RegisterModule( config );
            if( services != null )
                builder.Populate( services );
            return builder;
        }

        /// <summary>
        /// 注册AOP
        /// </summary>
        private void RegisterAop( ContainerBuilder builder ) {
            builder.RegisterDynamicProxy( config => config.EnableParameterAspect() );
        }

        /// <summary>
        /// 释放容器
        /// </summary>
        public void Dispose() {
            _container.Dispose();
        }
    }
}