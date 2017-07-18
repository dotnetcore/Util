using Autofac;
using Util.DependencyInjection;
using Util.Helpers;
using Util.Tests.Samples;
using Xunit;

namespace Util.Tests.Helpers {
    /// <summary>
    /// Ioc配置
    /// </summary>
    public class TestIocConfig : ConfigBase {
        /// <summary>
        /// 加载配置
        /// </summary>
        protected override void Load( ContainerBuilder builder ) {
            builder.RegisterType<Sample>().As<ISample>();
        }
    }

    /// <summary>
    /// Ioc测试
    /// </summary>
    public class IocTest {
        /// <summary>
        /// 初始化Ioc测试
        /// </summary>
        public IocTest() {
            Ioc.Register( new TestIocConfig() );
        }

        /// <summary>
        /// 测试创建实例
        /// </summary>
        [Fact]
        public void TestCreate() {
            var sample = Ioc.Create<ISample>();
            Assert.NotNull( sample );
        }

        /// <summary>
        /// 测试创建实例
        /// </summary>
        [Fact]
        public void TestCreate_2() {
            var sample = Ioc.Create(typeof(ISample));
            Assert.NotNull( sample );
        }
    }
}
