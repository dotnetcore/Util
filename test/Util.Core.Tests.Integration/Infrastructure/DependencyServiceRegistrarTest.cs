using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util.Infrastructure;
using Util.Tests.Samples;
using Xunit;

namespace Util.Tests.Infrastructure {
    /// <summary>
    /// 依赖服务注册器测试
    /// </summary>
    public class DependencyServiceRegistrarTest {
        /// <summary>
        /// 测试注册服务
        /// 说明:
        /// 1. 测试类TestService4实现了两个接口ITestService2,ITestService5
        /// 2. ITestService2接口没有继承ISingletonDependency,所以不会把TestService4注册到ITestService2
        /// 3. ITestService5继承ITestService4,ITestService4继承自ITestService3和ISingletonDependency,只有直接接口ITestService5会注册,其它被忽略
        /// 4. ITestService6测试泛型接口自动注册
        /// </summary>
        [Fact]
        public void TestRegisterDependency_1() {
            var builder = new HostBuilder();
            var bootstrapper = new Bootstrapper( builder );
            bootstrapper.Start();
            var host = builder.Build();
            Assert.Equal( typeof( TestService4 ), host.Services.GetService<ITestService5>()?.GetType() );
            Assert.NotEqual( typeof( TestService4 ), host.Services.GetService<ITestService2>()?.GetType() );
            Assert.NotEqual( typeof( TestService4 ), host.Services.GetService<ITestService3>()?.GetType() );
            Assert.NotEqual( typeof( TestService4 ), host.Services.GetService<ITestService4>()?.GetType() );
            Assert.Equal( typeof( TestService5<A> ), host.Services.GetService<ITestService6<A>>()?.GetType() );
        }

        /// <summary>
        /// 测试Ioc特性覆盖实现
        /// </summary>
        [Fact]
        public void TestRegisterDependency_2() {
            var builder = new HostBuilder();
            var bootstrapper = new Bootstrapper( builder );
            bootstrapper.Start();
            var host = builder.Build();
            Assert.Equal( typeof( TestService8 ), host.Services.GetService<ITestService7>()?.GetType() );
            Assert.Equal( typeof( TestService70 ), host.Services.GetService<ITestService70>()?.GetType() );
        }

        /// <summary>
        /// 测试依赖注册器配置比ISingletonDependency自动装配优先级高
        /// </summary>
        [Fact]
        public void TestRegisterDependency_3() {
            var builder = new HostBuilder();
            var bootstrapper = new Bootstrapper( builder );
            bootstrapper.Start();
            var host = builder.Build();
            Assert.Equal( typeof( TestService10 ), host.Services.GetService<ITestService8>()?.GetType() );
        }

        /// <summary>
        /// 测试禁用依赖服务注册器
        /// </summary>
        [Fact]
        public void TestDisableDependencyServiceRegistrar() {
            ServiceRegistrarConfig.Instance.DisableDependencyServiceRegistrar();
            var builder = new HostBuilder();
            var bootstrapper = new Bootstrapper( builder );
            bootstrapper.Start();
            var host = builder.Build();
            Assert.NotEqual( typeof( TestService4 ), host.Services.GetService<ITestService5>()?.GetType() );
            ServiceRegistrarConfig.Instance.EnableDependencyServiceRegistrar();
        }
    }
}
