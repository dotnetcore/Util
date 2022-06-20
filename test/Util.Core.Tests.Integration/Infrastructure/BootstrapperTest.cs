using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util.Dependency;
using Util.Infrastructure;
using Util.Tests.Samples;
using Xunit;

namespace Util.Tests.Infrastructure {
    /// <summary>
    /// 启动器测试
    /// </summary>
    public class BootstrapperTest {
        /// <summary>
        /// 测试启动时解析服务注册器
        /// 说明:
        /// 1. 有两个测试服务注册器TestServiceRegistrar和TestServiceRegistrar2
        /// 2. TestServiceRegistrar的Id更小,所以先执行
        /// 3. TestServiceRegistrar2使用services.TryAddSingleton进行依赖注册,由于之前已经添加过依赖,所以不会再次添加,TestServiceRegistrar的依赖配置生效
        /// </summary>
        [Fact]
        public void TestStart_1() {
            var builder = new HostBuilder();
            var bootstrapper = new Bootstrapper( builder );
            bootstrapper.Start();
            var host = builder.Build();
            Assert.Equal( "a", host.Services.GetService<IA>()?.Value );
            Assert.Equal( "a", host.Services.GetService<ITestService>()?.Value );
        }

        /// <summary>
        /// 测试启动时手工调用Options进行配置
        /// 说明:
        /// 1. 有两个测试依赖注册器TestDependencyRegistrar和TestDependencyRegistrar2
        /// 2. 手工调用options.UseTest的优先级高于依赖注册器
        /// 3. 依赖注册器使用services.TryAddSingleton进行依赖注册,由于之前已经添加过依赖,所以不会再次添加,options.UseTest的依赖配置生效
        /// </summary>
        [Fact]
        public void TestStart_2() {
            var builder = new HostBuilder();
            var bootstrapper = new Bootstrapper( builder, options => options.UseTest() );
            bootstrapper.Start();
            var host = builder.Build();
            Assert.Equal( "Options", host.Services.GetService<ITestService>()?.Value );
        }

        /// <summary>
        /// 测试服务注册器配置的优先级高于Options配置
        /// 说明:
        /// 1. 服务注册器TestServiceRegistrar3注册了ITestService2
        /// 2. 手工调用options.UseTest的优先级低于服务注册器
        /// 3. options.UseTest的依赖配置使用services.TryAddSingleton进行依赖注册,由于之前已经添加过依赖,所以不会再次添加,服务注册器配置生效
        /// </summary>
        [Fact]
        public void TestStart_3() {
            var builder = new HostBuilder();
            var bootstrapper = new Bootstrapper( builder, options => options.UseTest() );
            bootstrapper.Start();
            var host = builder.Build();
            Assert.Equal( "a", host.Services.GetService<ITestService2>()?.Value );
        }

        /// <summary>
        /// 测试服务注册器延迟配置的优先级低于Options配置
        /// 说明:
        /// 1. 服务注册器TestServiceRegistrar4在返回的Action中注册了ITestService3,这是一个延迟注册操作
        /// 2. 手工调用options.UseTest的优先级高于服务注册器延迟注册操作
        /// 3. options.UseTest的依赖配置生效
        /// </summary>
        [Fact]
        public void TestStart_4() {
            var builder = new HostBuilder();
            var bootstrapper = new Bootstrapper( builder, options => options.UseTest() );
            bootstrapper.Start();
            var host = builder.Build();
            Assert.Equal( "Options", host.Services.GetService<ITestService3>()?.Value );
        }
    }
}
