using Util.Tests.Samples;
using Xunit;

namespace Util.Tests.Helpers {
    /// <summary>
    /// 配置操作测试
    /// </summary>
    public class ConfigTest {
        /// <summary>
        /// 测试从根目录的appsettings.json文件读取配置
        /// </summary>
        [Fact]
        public void TestGet() {
            TestOptions options = Util.Helpers.Config.Get<TestOptions>( "Test" );
            Assert.Equal( 1,options.Code );
            Assert.Equal( "a", options.Name );
        }

        /// <summary>
        /// 测试从根目录的appsettings2.json文件读取配置
        /// </summary>
        [Fact]
        public void TestGet_2() {
            TestOptions options = Util.Helpers.Config.Get<TestOptions>( "Test", "appsettings2.json" );
            Assert.Equal( 2, options.Code );
            Assert.Equal( "b", options.Name );
        }
    }
}
