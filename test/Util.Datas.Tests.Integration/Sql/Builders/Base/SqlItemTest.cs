using Util.Datas.Dapper.MySql;
using Util.Datas.Dapper.PgSql;
using Util.Datas.Dapper.SqlServer;
using Util.Datas.Sql.Builders.Core;
using Util.Datas.Tests.Sql.Builders.Samples;
using Xunit;

namespace Util.Datas.Tests.Sql.Builders.Base {
    /// <summary>
    /// Sql项测试
    /// </summary>
    public class SqlItemTest {
        /// <summary>
        /// 表数据库
        /// </summary>
        private readonly TestTableDatabase _database;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public SqlItemTest() {
            _database = new TestTableDatabase();
        }

        /// <summary>
        /// 只设置名称
        /// </summary>
        [Fact]
        public void Test_1() {
            var item = new SqlItem( "a" );
            Assert.Equal( "a",item.Name );
            Assert.True( item.Prefix.IsEmpty() );
            Assert.True( item.Alias.IsEmpty() );

            //测试复制副本
            var copy = item.Clone();
            Assert.Equal( "a", copy.Name );
            Assert.True( copy.Prefix.IsEmpty() );
            Assert.True( copy.Alias.IsEmpty() );
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
            Assert.Equal( "[t].[a] As [b]", item.ToSql( new SqlServerDialect() ) );
            Assert.Equal( "[test].[t].[a] As [b]", item.ToSql( new SqlServerDialect(),_database ) );
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

        /// <summary>
        /// 带双引号
        /// </summary>
        [Fact]
        public void Test_10() {
            var item = new SqlItem( "\"a\".\"b\"" );
            Assert.Equal( "\"b\"", item.Name );
            Assert.Equal( "\"a\"",item.Prefix );
            Assert.Equal( "[a].[b]", item.ToSql( new SqlServerDialect() ) );
            Assert.Equal( "[test].[a].[b]", item.ToSql( new SqlServerDialect(),_database ) );
            Assert.Equal( "\"a\".\"b\"", item.ToSql( new PgSqlDialect() ) );
            Assert.Equal( "`a`.`b`", item.ToSql( new MySqlDialect() ) );
        }

        /// <summary>
        /// 带`符号
        /// </summary>
        [Fact]
        public void Test_11() {
            var item = new SqlItem( "`a`.`b`" );
            Assert.Equal( "`b`", item.Name );
            Assert.Equal( "`a`", item.Prefix );
            Assert.Equal( "[a].[b]", item.ToSql( new SqlServerDialect() ) );
            Assert.Equal( "\"a\".\"b\"", item.ToSql( new PgSqlDialect() ) );
            Assert.Equal( "`a`.`b`", item.ToSql( new MySqlDialect() ) );
        }

        /// <summary>
        /// 带[]符号
        /// </summary>
        [Fact]
        public void Test_12() {
            var item = new SqlItem( "[a].[b]" );
            Assert.Equal( "[b]", item.Name );
            Assert.Equal( "[a]", item.Prefix );
            Assert.Equal( "[a].[b]", item.ToSql( new SqlServerDialect() ) );
            Assert.Equal( "\"a\".\"b\"", item.ToSql( new PgSqlDialect() ) );
            Assert.Equal( "`a`.`b`", item.ToSql( new MySqlDialect() ) );
        }

        /// <summary>
        /// 带双引号 - 前缀带句点
        /// </summary>
        [Fact]
        public void Test_13() {
            var item = new SqlItem( "\"a.b\".\"c\"" );
            Assert.Equal( "\"c\"", item.Name );
            Assert.Equal( "\"a.b\"", item.Prefix );
            Assert.Equal( "[a.b].[c]", item.ToSql( new SqlServerDialect() ) );
            Assert.Equal( "\"a.b\".\"c\"", item.ToSql( new PgSqlDialect() ) );
            Assert.Equal( "`a.b`.`c`", item.ToSql( new MySqlDialect() ) );
        }

        /// <summary>
        /// 带`符号 - 前缀带句点
        /// </summary>
        [Fact]
        public void Test_14() {
            var item = new SqlItem( "`a.b`.`c`" );
            Assert.Equal( "`c`", item.Name );
            Assert.Equal( "`a.b`", item.Prefix );
            Assert.Equal( "[a.b].[c]", item.ToSql( new SqlServerDialect() ) );
            Assert.Equal( "\"a.b\".\"c\"", item.ToSql( new PgSqlDialect() ) );
            Assert.Equal( "`a.b`.`c`", item.ToSql( new MySqlDialect() ) );
        }

        /// <summary>
        /// 带[]符号 - 前缀带句点
        /// </summary>
        [Fact]
        public void Test_15() {
            var item = new SqlItem( "[a.b].[c]" );
            Assert.Equal( "[c]", item.Name );
            Assert.Equal( "[a.b]", item.Prefix );
            Assert.Equal( "[a.b].[c]", item.ToSql( new SqlServerDialect() ) );
            Assert.Equal( "[test].[a.b].[c]", item.ToSql( new SqlServerDialect(),_database ) );
            Assert.Equal( "\"a.b\".\"c\"", item.ToSql( new PgSqlDialect() ) );
            Assert.Equal( "`a.b`.`c`", item.ToSql( new MySqlDialect() ) );
        }

        /// <summary>
        /// 带[]符号 - 前缀带句点
        /// </summary>
        [Fact]
        public void Test_16() {
            var item = new SqlItem( "a.b.c" );
            Assert.Equal( "c", item.Name );
            Assert.Equal( "b", item.Prefix );
            Assert.Equal( "a", item.DatabaseName );
            Assert.Equal( "[a].[b].[c]", item.ToSql( new SqlServerDialect() ) );
            Assert.Equal( "[a].[b].[c]", item.ToSql( new SqlServerDialect(),_database ) );
            Assert.Equal( "\"a\".\"b\".\"c\"", item.ToSql( new PgSqlDialect() ) );
            Assert.Equal( "`a`.`b`.`c`", item.ToSql( new MySqlDialect() ) );
        }
    }
}
