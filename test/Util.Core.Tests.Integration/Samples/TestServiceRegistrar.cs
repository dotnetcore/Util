using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Util.Infrastructure;
using Util.Reflections;

namespace Util.Tests.Samples {
    /// <summary>
    /// 测试服务注册器
    /// </summary>
    public class TestServiceRegistrar : IServiceRegistrar {
        /// <summary>
        /// 注册服务
        /// </summary>
        public Action Register( IServiceCollection services, IConfiguration configuration, ITypeFinder finder ) {
            A a = new A { Value = "a" };
            services.TryAddSingleton<IA>( a );
            return null;
        }

        /// <summary>
        /// 标识
        /// </summary>
        public int Id => 100;

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled => ServiceRegistrarConfig.Instance.IsEnabled( Id );
    }

    /// <summary>
    /// 测试服务注册器2
    /// </summary>
    public class TestServiceRegistrar2 : IServiceRegistrar {
        /// <summary>
        /// 注册服务
        /// </summary>
        public Action Register( IServiceCollection services, IConfiguration configuration, ITypeFinder finder ) {
            A a = new A { Value = "b" };
            services.TryAddSingleton<IA>( a );
            return null;
        }

        /// <summary>
        /// 标识
        /// </summary>
        public int Id => 200;

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled => ServiceRegistrarConfig.Instance.IsEnabled( Id );
    }

    /// <summary>
    /// 测试服务注册器
    /// </summary>
    public class TestServiceRegistrar3 : IServiceRegistrar {
        /// <summary>
        /// 注册服务
        /// </summary>
        public Action Register( IServiceCollection services, IConfiguration configuration, ITypeFinder finder ) {
            var service = new TestService2 { Value = "a" };
            services.TryAddSingleton<ITestService2>( service );
            return null;
        }

        /// <summary>
        /// 标识
        /// </summary>
        public int Id => 300;

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled => ServiceRegistrarConfig.Instance.IsEnabled( Id );
    }

    /// <summary>
    /// 测试服务注册器
    /// </summary>
    public class TestServiceRegistrar4 : IServiceRegistrar {
        /// <summary>
        /// 注册服务
        /// </summary>
        public Action Register( IServiceCollection services, IConfiguration configuration, ITypeFinder finder ) {
            return () => {
                var service = new TestService3 { Value = "a" };
                services.TryAddSingleton<ITestService3>( service );
            };
        }

        /// <summary>
        /// 标识
        /// </summary>
        public int Id => 400;

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled => ServiceRegistrarConfig.Instance.IsEnabled( Id );
    }
}
