using Util.Data.Sql.Builders.Core;
using Xunit;

namespace Util.Data.Sql.Tests.Builders.Core {
    /// <summary>
    /// 排序项测试
    /// </summary>
    public class OrderByItemTest {
        /// <summary>
        /// 测试初始化
        /// </summary>
        public OrderByItemTest() {
        }

        /// <summary>
        /// 测试解析排序列
        /// </summary>
        [Fact]
        public void Test_1() {
            var item = new OrderByItem( "a.B" );
            Assert.Equal( "a.B", item.Column );
            Assert.False( item.Desc );
        }

        /// <summary>
        /// 测试解析排序列 - 前后有空格
        /// </summary>
        [Fact]
        public void Test_2() {
            var item = new OrderByItem( " a.B " );
            Assert.Equal( "a.B", item.Column );
            Assert.False( item.Desc );
        }

        /// <summary>
        /// 测试解析排序列 - 带ASC
        /// </summary>
        [Fact]
        public void Test_3() {
            var item = new OrderByItem( "a.B Asc" );
            Assert.Equal( "a.B", item.Column );
            Assert.False( item.Desc );
        }

        /// <summary>
        /// 测试解析排序列 - 列名为ASC
        /// </summary>
        [Fact]
        public void Test_4() {
            var item = new OrderByItem( "Asc" );
            Assert.Equal( "Asc", item.Column );
            Assert.False( item.Desc );
        }

        /// <summary>
        /// 测试解析排序列 - 列名为ASC,前后有空格
        /// </summary>
        [Fact]
        public void Test_5() {
            var item = new OrderByItem( " Asc " );
            Assert.Equal( "Asc", item.Column );
            Assert.False( item.Desc );
        }

        /// <summary>
        /// 测试解析排序列 - 降序
        /// </summary>
        [Fact]
        public void Test_6() {
            var item = new OrderByItem( "a.B Desc" );
            Assert.Equal( "a.B", item.Column );
            Assert.True( item.Desc );
        }

        /// <summary>
        /// 测试解析排序列 - 降序,前后添加空格
        /// </summary>
        [Fact]
        public void Test_7() {
            var item = new OrderByItem( " a.B desc " );
            Assert.Equal( "a.B", item.Column );
            Assert.True( item.Desc );
        }

        /// <summary>
        /// 测试解析排序列 - 列名为Desc
        /// </summary>
        [Fact]
        public void Test_8() {
            var item = new OrderByItem( "Desc" );
            Assert.Equal( "Desc", item.Column );
            Assert.False( item.Desc );
        }

        /// <summary>
        /// 测试解析排序列 - 列名为Desc,前后有空格
        /// </summary>
        [Fact]
        public void Test_9() {
            var item = new OrderByItem( " Desc " );
            Assert.Equal( "Desc", item.Column );
            Assert.False( item.Desc );
        }
    }
}
