using Util.Helpers;
using Xunit;

namespace Util.Tests.Helpers {
    /// <summary>
    /// 验证操作测试
    /// </summary>
    public class ValidationTest {
        /// <summary>
        /// 是否数字
        /// </summary>
        [Fact]
        public void TestIsNumber() {
            Assert.False( Validation.IsNumber( "" ) );
            Assert.True( Validation.IsNumber( "1" ) );
            Assert.False( Validation.IsNumber( "1a" ) );
            Assert.True( Validation.IsNumber( "100.04" ) );
            Assert.False( Validation.IsNumber( "100a.01" ) );
        }
    }
}
