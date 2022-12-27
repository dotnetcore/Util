using System.Collections.Generic;
using Util.Tests.Samples;
using Xunit;

namespace Util.Tests.Extensions {
    /// <summary>
    /// 公共扩展测试
    /// </summary>
    public class CommonExtensionsTest {
        /// <summary>
        /// 测试安全获取值
        /// </summary>
        [Fact]
        public void TestSafeValue() {
            int? value = null;
            Assert.Equal( 0, value.SafeValue() );
            value = 1;
            Assert.Equal( 1, value.SafeValue() );
        }

        /// <summary>
        /// 测试获取枚举值
        /// </summary>
        [Fact]
        public void TestValue() {
            Assert.Equal( 2, EnumSample.B.Value() );
            Assert.Equal( "2", EnumSample.B.Value<string>() );
        }

        /// <summary>
        /// 测试获取枚举描述
        /// </summary>
        [Fact]
        public void TestDescription() {
            Assert.Equal( "B2", EnumSample.B.Description() );
        }

        /// <summary>
        /// 转换为用分隔符连接的字符串
        /// </summary>
        [Fact]
        public void TestJoin() {
            Assert.Equal( "1,2,3", new List<int> { 1, 2, 3 }.Join() );
            Assert.Equal( "'1','2','3'", new List<int> { 1, 2, 3 }.Join( "'" ) );
        }
    }
}
