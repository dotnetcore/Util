using Util.Ui.Configs;
using Xunit;

namespace Util.Ui.Tests.Configs {
    /// <summary>
    /// 配置测试
    /// </summary>
    public class ConfigTest {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化配置测试
        /// </summary>
        public ConfigTest() {
            _config = new Config();
        }

        /// <summary>
        /// 添加类
        /// </summary>
        [Fact]
        public void TestAddClass() {
            Assert.Equal( 0,_config.GetClassList().Count );
            _config.AddClass( "" );
            _config.AddClass( " " );
            Assert.Equal( 0, _config.GetClassList().Count );
            _config.AddClass( "a" );
            Assert.Equal( 1, _config.GetClassList().Count );
            Assert.Equal( "a", _config.GetClassList()[0] );
            _config.AddClass( "a" );
            Assert.Equal( 1, _config.GetClassList().Count );
            _config.AddClass( "b" );
            Assert.Equal( 2, _config.GetClassList().Count );
        }
    }
}
