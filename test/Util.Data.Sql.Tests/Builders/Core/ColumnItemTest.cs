using Util.Data.Sql.Builders;
using Util.Data.Sql.Builders.Core;
using Util.Data.Sql.Tests.Samples;
using Xunit;

namespace Util.Data.Sql.Tests.Builders.Core {
    /// <summary>
    /// 列测试
    /// </summary>
    public class ColumnItemTest {
        /// <summary>
        /// Sql方言
        /// </summary>
        private readonly IDialect _dialect;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ColumnItemTest() {
            _dialect = TestDialect.Instance;
        }

        /// <summary>
        /// 测试解析简单列名
        /// </summary>
        [Fact]
        public void Test_1() {
            var item = new ColumnItem( _dialect,"a" );
            Assert.Null( item.TableAlias );
            Assert.Equal( "a", item.Name );
        }

        /// <summary>
        /// 测试解析带表别名的列
        /// </summary>
        [Fact]
        public void Test_2() {
            var item = new ColumnItem( _dialect, "a.b" );
            Assert.Equal( "a", item.TableAlias );
            Assert.Equal( "b", item.Name );
        }

        /// <summary>
        /// 测试解析带表别名和列别名的列 - 使用as关键字
        /// </summary>
        [Fact]
        public void Test_3() {
            var item = new ColumnItem( _dialect, "a.b as c" );
            Assert.Equal( "a", item.TableAlias );
            Assert.Equal( "b", item.Name );
            Assert.Equal( "c", item.ColumnAlias );
        }

        /// <summary>
        /// 测试解析带表别名和列别名的列 - 使用As关键字
        /// </summary>
        [Fact]
        public void Test_4() {
            var item = new ColumnItem( _dialect, "a.b As c" );
            Assert.Equal( "a", item.TableAlias );
            Assert.Equal( "b", item.Name );
            Assert.Equal( "c", item.ColumnAlias );
        }

        /// <summary>
        /// 测试解析带表别名和列别名的列 - 使用空格
        /// </summary>
        [Fact]
        public void Test_5() {
            var item = new ColumnItem( _dialect, "a.b c" );
            Assert.Equal( "a", item.TableAlias );
            Assert.Equal( "b", item.Name );
            Assert.Equal( "c", item.ColumnAlias );
        }

        /// <summary>
        /// 测试.前有空格
        /// </summary>
        [Fact]
        public void Test_6() {
            var item = new ColumnItem( _dialect, "a .b" );
            Assert.Equal( "a", item.TableAlias );
            Assert.Equal( "b", item.Name );
        }

        /// <summary>
        /// 测试.后有空格
        /// </summary>
        [Fact]
        public void Test_7() {
            var item = new ColumnItem( _dialect, "a. b" );
            Assert.Equal( "a", item.TableAlias );
            Assert.Equal( "b", item.Name );
        }

        /// <summary>
        /// 测试.后有空格
        /// </summary>
        [Fact]
        public void Test_8() {
            var item = new ColumnItem( _dialect, "a . b" );
            Assert.Equal( "a", item.TableAlias );
            Assert.Equal( "b", item.Name );
        }

        /// <summary>
        /// 测试多个空格
        /// </summary>
        [Fact]
        public void Test_9() {
            var item = new ColumnItem( _dialect, " a . b  As    c   " );
            Assert.Equal( "a", item.TableAlias );
            Assert.Equal( "b", item.Name );
            Assert.Equal( "c", item.ColumnAlias );
        }

        /// <summary>
        /// 测试添加了转义符
        /// </summary>
        [Fact]
        public void Test_10() {
            var item = new ColumnItem( _dialect, "[a].[b] as [c]" );
            Assert.Equal( "[a]", item.TableAlias );
            Assert.Equal( "[b]", item.Name );
            Assert.Equal( "[c]", item.ColumnAlias );
        }

        /// <summary>
        /// 测试获取Sql结果 - 简单列名
        /// </summary>
        [Fact]
        public void TestToSql_1() {
            var item = new ColumnItem( _dialect, "a" );
            Assert.Equal( "[a]", item.ToResult() );
        }

        /// <summary>
        /// 测试获取Sql结果 - 带表别名的列
        /// </summary>
        [Fact]
        public void TestToSql_2() {
            var item = new ColumnItem( _dialect, "a.b" );
            Assert.Equal( "[a].[b]", item.ToResult() );
        }

        /// <summary>
        /// 测试获取Sql结果 - 带表别名和列别名的列
        /// </summary>
        [Fact]
        public void TestToSql_3() {
            var item = new ColumnItem( _dialect, "a.b as c" );
            Assert.Equal( "[a].[b] As [c]", item.ToResult() );
        }

        /// <summary>
        /// 测试获取Sql结果 - 添加了转义符和多余的空格
        /// </summary>
        [Fact]
        public void TestToSql_4() {
            var item = new ColumnItem( _dialect, "  [a] . [b]  as  [c] " );
            Assert.Equal( "[a].[b] As [c]", item.ToResult() );
        }
    }
}
