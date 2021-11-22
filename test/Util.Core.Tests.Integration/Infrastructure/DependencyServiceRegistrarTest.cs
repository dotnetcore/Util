using Util.Dependency;
using Util.Infrastructure;
using Util.Tests.Samples;
using Xunit;

namespace Util.Tests.Infrastructure {
    /// <summary>
    /// 依赖服务注册器测试
    /// </summary>
    public class DependencyServiceRegistrarTest {
        /// <summary>
        /// 测试初始化
        /// </summary>
        public DependencyServiceRegistrarTest() {
            ServiceRegistrarConfig.Instance.Init();
        }

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
            var container = new Container();
            var bootstrapper = new Bootstrapper( container.GetServices() );
            bootstrapper.Start();
            Assert.Equal( typeof( TestService4 ), container.GetService<ITestService5>().GetType() );
            Assert.NotEqual( typeof( TestService4 ), container.GetService<ITestService2>()?.GetType() );
            Assert.NotEqual( typeof( TestService4 ), container.GetService<ITestService3>()?.GetType() );
            Assert.NotEqual( typeof( TestService4 ), container.GetService<ITestService4>()?.GetType() );
            Assert.Equal( typeof( TestService5<A> ), container.GetService<ITestService6<A>>().GetType() );
        }

        /// <summary>
        /// 测试依赖注册器配置比ISingletonDependency自动装配优先级高
        /// </summary>
        [Fact]
        public void TestRegisterDependency_2() {
            var container = new Container();
            var bootstrapper = new Bootstrapper( container.GetServices() );
            bootstrapper.Start();
            Assert.Equal( typeof( TestService8 ), container.GetService<ITestService7>().GetType() );
        }

        /// <summary>
        /// 测试禁用依赖服务注册器
        /// </summary>
        [Fact]
        public void TestDisableDependencyServiceRegistrar() {
            ServiceRegistrarConfig.Instance.DisableDependencyServiceRegistrar();
            var container = new Container();
            var bootstrapper = new Bootstrapper( container.GetServices() );
            bootstrapper.Start();
            Assert.NotEqual( typeof( TestService4 ), container.GetService<ITestService5>()?.GetType() );
        }
    }
}
