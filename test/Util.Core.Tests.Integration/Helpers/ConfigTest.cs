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
    }
}
