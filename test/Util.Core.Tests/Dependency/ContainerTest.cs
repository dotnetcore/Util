using Microsoft.Extensions.DependencyInjection;
using Util.Dependency;
using Util.Tests.Samples;
using Xunit;

namespace Util.Tests.Dependency {
    /// <summary>
    /// 容器测试
    /// </summary>
    public class ContainerTest {
        /// <summary>
        /// 容器
        /// </summary>
        private readonly Container _container;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ContainerTest() {
            _container = new Container();
        }

        /// <summary>
        /// 测试获取服务集合
        /// </summary>
        [Fact]
        public void TestGetServices() {
            Assert.NotNull( _container.GetServices() );
        }

        /// <summary>
        /// 测试获取服务
        /// </summary>
        [Fact]
        public void TestGetService() {
            var services = _container.GetServices();
            services.AddSingleton<ISample, Sample>();
            var result = _container.GetService<ISample>();
            Assert.Equal( typeof( Sample ), result.GetType() );
        }

        /// <summary>
        /// 测试获取服务 - 传入类型参数
        /// </summary>
        [Fact]
        public void TestGetService_Type() {
            var services = _container.GetServices();
            services.AddSingleton<ISample, Sample>();
            var result = _container.GetService<ISample>(typeof( ISample ) );
            Assert.Equal( typeof( Sample ), result.GetType() );
        }
    }
}
