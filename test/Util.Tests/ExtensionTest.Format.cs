using System;
using Util.Helpers;
using Xunit;

namespace Util.Tests {
    /// <summary>
    /// 扩展测试 - 格式化
    /// </summary>
    public partial class ExtensionTest {
        /// <summary>
        /// 测试获取布尔值描述
        /// </summary>
        [Fact]
        public void TestDescription_Bool() {
            bool? value = null;
            Assert.Equal( "", value.Description() );
            Assert.Equal( "是", true.Description() );
            Assert.Equal( "否", false.Description() );
        }

        /// <summary>
        /// 测试获取时间间隔描述
        /// </summary>
        [Fact]
        public void TestDescription_Span() {
            TimeSpan span = new DateTime( 2000, 1, 1, 1, 0, 1 ) - new DateTime( 2000, 1, 1, 1, 0, 0 );
            Assert.Equal( "1秒", span.Description() );
            span = new DateTime( 2000, 1, 1, 1, 1, 0 ) - new DateTime( 2000, 1, 1, 1, 0, 0 );
            Assert.Equal( "1分", span.Description() );
            span = new DateTime( 2000, 1, 1, 1, 0, 0 ) - new DateTime( 2000, 1, 1, 0, 0, 0 );
            Assert.Equal( "1小时", span.Description() );
            span = new DateTime( 2000, 1, 2, 0, 0, 0 ) - new DateTime( 2000, 1, 1, 0, 0, 0 );
            Assert.Equal( "1天", span.Description() );
            span = new DateTime( 2000, 1, 2, 0, 2, 0 ) - new DateTime( 2000, 1, 1, 0, 0, 0 );
            Assert.Equal( "1天2分", span.Description() );
        }
    }
}
