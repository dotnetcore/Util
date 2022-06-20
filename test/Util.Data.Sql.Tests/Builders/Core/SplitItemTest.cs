using Util.Data.Sql.Builders.Core;
using Xunit;

namespace Util.Data.Sql.Tests.Builders.Core {
    /// <summary>
    /// 拆分项测试
    /// </summary>
    public class SplitItemTest {
        /// <summary>
        /// 测试设置单个字符
        /// </summary>
        [Fact]
        public void Test_1() {
            var item = new SplitItem( "a" );
            Assert.Equal( "a", item.Left );
            Assert.Null( item.Right );
        }

        /// <summary>
        /// 测试设置空字符
        /// </summary>
        [Fact]
        public void Test_2() {
            var item = new SplitItem( "" );
            Assert.Null( item.Left );
            Assert.Null( item.Right );
        }

        /// <summary>
        /// 测试设置null
        /// </summary>
        [Fact]
        public void Test_3() {
            var item = new SplitItem( null );
            Assert.Null( item.Left );
            Assert.Null( item.Right );
        }

        /// <summary>
        /// 测试默认使用空格拆分
        /// </summary>
        [Fact]
        public void Test_4() {
            var item = new SplitItem( "a b" );
            Assert.Equal( "a", item.Left );
            Assert.Equal( "b", item.Right );
        }

        /// <summary>
        /// 测试设置.进行拆分
        /// </summary>
        [Fact]
        public void Test_5() {
            var item = new SplitItem( "a.b","." );
            Assert.Equal( "a", item.Left );
            Assert.Equal( "b", item.Right );
        }

        /// <summary>
        /// 测试去掉两端空格
        /// </summary>
        [Fact]
        public void Test_6() {
            var item = new SplitItem( " a.b ", "." );
            Assert.Equal( "a", item.Left );
            Assert.Equal( "b", item.Right );
        }
    }
}
