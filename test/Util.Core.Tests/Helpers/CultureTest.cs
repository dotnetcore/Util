using System.Globalization;
using Xunit;

namespace Util.Tests.Helpers {
    /// <summary>
    /// 区域文化测试
    /// </summary>
    public class CultureTest {
        /// <summary>
        /// 测试获取区域文化信息列表
        /// </summary>
        [Fact]
        public void TestGetCultures() {
            var culture = new CultureInfo( "zh-CN" );
            var cultures = Util.Helpers.Culture.GetCultures( culture );
            Assert.Equal( 3, cultures.Count );
            Assert.Equal( "zh-CN", cultures[0].Name );
            Assert.Equal( "zh-Hans", cultures[1].Name );
            Assert.Equal( "zh", cultures[2].Name );
        }
    }
}
