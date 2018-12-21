using Util.Datas.Sql.Queries.Builders.Core;
using Xunit;

namespace Util.Tests.Datas.Sql {
    /// <summary>
    /// Sql项测试
    /// </summary>
    public class SqlItemTest {
        /// <summary>
        /// 只设置名称
        /// </summary>
        [Fact]
        public void Test_1() {
            var item = new SqlItem( "a" );
            Assert.Equal( "a",item.Name );
            Assert.True( item.Prefix.IsEmpty() );
            Assert.True( item.Alias.IsEmpty() );
        }

        /// <summary>
        /// 设置名称和前缀
        /// </summary>
        [Fact]
        public void Test_2() {
            var item = new SqlItem( "t.a" );
            Assert.Equal( "a", item.Name );
            Assert.Equal( "t", item.Prefix );
            Assert.True( item.Alias.IsEmpty() );
        }

        /// <summary>
        /// 设置名称和前缀 - 增加空格
        /// </summary>
        [Fact]
        public void Test_3() {
            var item = new SqlItem( "  t  .  a  " );
            Assert.Equal( "a", item.Name );
            Assert.Equal( "t", item.Prefix );
            Assert.True( item.Alias.IsEmpty() );
        }

        /// <summary>
        /// 名称中带别名
        /// </summary>
        [Fact]
        public void Test_4() {
            var item = new SqlItem( "t . a   aS   b " );
            Assert.Equal( "a", item.Name );
            Assert.Equal( "t", item.Prefix );
            Assert.Equal( "b",item.Alias );
        }

        /// <summary>
        /// 设置别名
        /// </summary>
        [Fact]
        public void Test_5() {
            var item = new SqlItem( "a",alias:"b" );
            Assert.Equal( "a", item.Name );
            Assert.True( item.Prefix.IsEmpty() );
            Assert.Equal( "b", item.Alias );
        }

        /// <summary>
        /// 设置别名
        /// </summary>
        [Fact]
        public void Test_6() {
            var item = new SqlItem( "a as c",alias: "b" );
            Assert.Equal( "a", item.Name );
            Assert.True( item.Prefix.IsEmpty() );
            Assert.Equal( "c", item.Alias );
        }

        /// <summary>
        /// 设置前缀
        /// </summary>
        [Fact]
        public void Test_7() {
            var item = new SqlItem( "a as c", "d", "b" );
            Assert.Equal( "a", item.Name );
            Assert.Equal( "d", item.Prefix );
            Assert.Equal( "c", item.Alias );
        }

        /// <summary>
        /// 只设置名称 - 不分割名称
        /// </summary>
        [Fact]
        public void Test_8() {
            var item = new SqlItem( "a",isSplit:false );
            Assert.Equal( "a", item.Name );
            Assert.True( item.Prefix.IsEmpty() );
            Assert.True( item.Alias.IsEmpty() );
        }

        /// <summary>
        /// 只设置名称 - 不分割名称 - 名称带句点
        /// </summary>
        [Fact]
        public void Test_9() {
            var item = new SqlItem( "a.b", isSplit: false );
            Assert.Equal( "a.b", item.Name );
            Assert.True( item.Prefix.IsEmpty() );
            Assert.True( item.Alias.IsEmpty() );
        }
    }
}
