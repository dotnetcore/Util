using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Util.Dependency;

namespace Util.Tests.Samples {
    /// <summary>
    /// 测试依赖注册器
    /// </summary>
    public class TestDependencyRegistrar : IDependencyRegistrar {
        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="services">服务集合</param>
        public void Register( IServiceCollection services ) {
            var service = new TestService { Value = "a" };
            services.TryAddSingleton<ITestService>( service );
        }

        /// <summary>
        /// 注册序号
        /// </summary>
        public int Order => 1;
    }

    /// <summary>
    /// 测试依赖注册器2
    /// </summary>
    public class TestDependencyRegistrar2 : IDependencyRegistrar {
        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="services">服务集合</param>
        public void Register( IServiceCollection services ) {
            var service = new TestService { Value = "b" };
            services.TryAddSingleton<ITestService>( service );
        }

        /// <summary>
        /// 注册序号
        /// </summary>
        public int Order => 2;
    }

    /// <summary>
    /// 测试依赖注册器3
    /// </summary>
    public class TestDependencyRegistrar3 : IDependencyRegistrar {
        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="services">服务集合</param>
        public void Register( IServiceCollection services ) {
            services.TryAddSingleton<ITestService8, TestService10>();
        }

        /// <summary>
        /// 注册序号
        /// </summary>
        public int Order => 3;
    }
}
