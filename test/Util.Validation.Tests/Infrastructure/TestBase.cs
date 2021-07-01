using System;
using AspectCore.Extensions.DependencyInjection;
using Util.Helpers;
using Xunit;

namespace Util.Validation.Tests.Infrastructure {
    /// <summary>
    /// 测试基类
    /// </summary>
    [Collection( "GlobalConfig" )]
    public abstract class TestBase {
        /// <summary>
        /// 服务提供器
        /// </summary>
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// 初始化测试基类
        /// </summary>
        protected TestBase() {
            _serviceProvider = Ioc.GetServices().BuildDynamicProxyProvider();
        }

        /// <summary>
        /// 获取服务
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        protected T GetService<T>() {
            return (T)_serviceProvider.GetService( typeof(T) );
        }
    }
}
