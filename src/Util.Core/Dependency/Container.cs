using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Util.Dependency {
    /// <summary>
    /// 容器
    /// </summary>
    public class Container {
        /// <summary>
        /// 服务集合
        /// </summary>
        private readonly ServiceCollection _services;
        /// <summary>
        /// 服务提供器
        /// </summary>
        private IServiceProvider _provider;

        /// <summary>
        /// 容器实例
        /// </summary>
        public static readonly Container Instance = new Container();

        /// <summary>
        /// 初始化容器
        /// </summary>
        public Container() {
            _services = new ServiceCollection();
        }

        /// <summary>
        /// 获取服务集合
        /// </summary>
        public ServiceCollection GetServices() {
            return _services;
        }

        /// <summary>
        /// 获取服务
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        public T GetService<T>() {
            return GetService<T>( typeof(T) );
        }

        /// <summary>
        /// 获取服务
        /// </summary>
        /// <typeparam name="T">返回对象类型</typeparam>
        /// <param name="type">对象类型</param>
        public T GetService<T>( Type type ) {
            var service = GetService( type );
            if ( service == null )
                return default;
            return (T)service;
        }

        /// <summary>
        /// 获取服务
        /// </summary>
        /// <typeparam name="T">返回对象类型</typeparam>
        /// <param name="type">对象类型</param>
        public object GetService( Type type ) {
            _provider ??= _services.BuildServiceProvider();
            return _provider.GetService( type );
        }

        /// <summary>
        /// 获取服务列表
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        public List<T> GetServiceList<T>() {
            return GetServiceList<T>( typeof( T ) );
        }

        /// <summary>
        /// 获取服务列表
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        public List<T> GetServiceList<T>( Type type ) {
            Type serviceType = typeof( IEnumerable<> ).MakeGenericType( type );
            var result = GetService( serviceType );
            if( result == null )
                return new List<T>();
            return ( (IEnumerable<T>)result ).ToList();
        }
    }
}
