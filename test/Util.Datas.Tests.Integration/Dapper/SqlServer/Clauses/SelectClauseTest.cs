using Util.Datas.Dapper.SqlServer;
using Util.Datas.Sql.Queries.Builders.Clauses;
using Util.Datas.Sql.Queries.Builders.Core;
using Util.Datas.Tests.Dapper.SqlServer.Samples;
using Util.Datas.Tests.Samples;
using Xunit;

namespace Util.Datas.Tests.Dapper.SqlServer.Clauses {
    /// <summary>
    /// Select子句测试
    /// </summary>
    public class SelectClauseTest {
        /// <summary>
        /// Select子句
        /// </summary>
        private SelectClause _clause;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public SelectClauseTest() {
            _clause = new SelectClause( new SqlServerDialect(), new EntityResolver(), new EntityAliasRegister() );
        }

        /// <summary>
        /// 获取Sql语句
        /// </summary>
        private string GetSql() {
            return _clause.ToSql();
        }

        /// <summary>
        /// 设置列 - 默认使用*
        /// </summary>
        [Fact]
        public void TestSelect_1() {
            Assert.Equal( "Select *", GetSql() );
        }

        /// <summary>
        /// 设置列
        /// </summary>
        [Fact]
        public void TestSelect_2() {
            _clause.Select( "a" );
            Assert.Equal( "Select [a]", GetSql() );
        }

        /// <summary>
        /// 设置列 - 设置表别名
        /// </summary>
        [Fact]
        public void TestSelect_3() {
            _clause.Select( "a","b" );
            Assert.Equal( "Select [b].[a]", _clause.ToSql() );
        }

        /// <summary>
        /// 设置列 - 列带前缀
        /// </summary>
        [Fact]
        public void TestSelect_4() {
            _clause.Select( "a.b" );
            Assert.Equal( "Select [a].[b]", _clause.ToSql() );
        }

        /// <summary>
        /// 设置列 - 列具有中括号
        /// </summary>
        [Fact]
        public void TestSelect_5() {
            _clause.Select( "[a]" );
            Assert.Equal( "Select [a]", GetSql() );
        }

        /// <summary>
        /// 设置列 - 多列
        /// </summary>
        [Fact]
        public void TestSelect_6() {
            _clause.Select( "a,[b]" );
            Assert.Equal( "Select [a],[b]", GetSql() );
        }

        /// <summary>
        /// 设置列 - 多列 - 设置表别名
        /// </summary>
        [Fact]
        public void TestSelect_7() {
            _clause.Select( "a,[b]","c" );
            Assert.Equal( "Select [c].[a],[c].[b]", GetSql() );
        }

        /// <summary>
        /// 设置列 - 多列 - 设置表别名 - 列带前缀
        /// </summary>
        [Fact]
        public void TestSelect_8() {
            _clause.Select( "d.a,[b]", "c" );
            Assert.Equal( "Select [d].[a],[c].[b]", GetSql() );
        }

        /// <summary>
        /// 设置列 - lambda表达式
        /// </summary>
        [Fact]
        public void TestSelect_9() {
            _clause.Select<Sample>( t => new object[] { t.Email, t.IntValue } );
            Assert.Equal( "Select [Email],[IntValue]", GetSql() );
        }

        /// <summary>
        /// 设置列 - 多个Select
        /// </summary>
        [Fact]
        public void TestSelect_10() {
            _clause.Select( "a" );
            _clause.Select( "b" );
            Assert.Equal( "Select [a],[b]", GetSql() );
        }

        /// <summary>
        /// 设置列 - 每个Select使用不同的别名
        /// </summary>
        [Fact]
        public void TestSelect_11() {
            _clause.Select( "a,b", "j" );
            _clause.Select( "c,d", "k" );
            Assert.Equal( "Select [j].[a],[j].[b],[k].[c],[k].[d]", GetSql() );
        }

        /// <summary>
        /// 设置列 - 多个*
        /// </summary>
        [Fact]
        public void TestSelect_12() {
            _clause.Select( "a.*,b.*" );
            Assert.Equal( "Select [a].*,[b].*", GetSql() );
        }

        /// <summary>
        /// 设置列 - lambda表达式
        /// </summary>
        [Fact]
        public void TestSelect_13() {
            _clause.Select<Sample>( t => new object[] {t.Email, t.IntValue} );
            _clause.Select<Sample2>( t => new object[] {t.Description, t.Display} );
            Assert.Equal( "Select [Email],[IntValue],[Description],[Display]", GetSql() );
        }

        /// <summary>
        /// 设置列 - 设置列别名
        /// </summary>
        [Fact]
        public void TestSelect_14() {
            _clause.Select( "t.a As e,[b],f.g", "k" );
            _clause.Select( "n" );
            Assert.Equal( "Select [t].[a] As [e],[k].[b],[f].[g],[n]", _clause.ToSql() );
        }

        /// <summary>
        /// 设置列 - 设置列别名，增加了空格
        /// </summary>
        [Fact]
        public void TestSelect_15() {
            _clause.Select( "t.[a]    As     [e]      ,        b aS          f ","d" );
            Assert.Equal( "Select [t].[a] As [e],[d].[b] As [f]", GetSql() );
        }

        /// <summary>
        /// 设置列 - 添加select子句，不进行修改
        /// </summary>
        [Fact]
        public void TestSelect_16() {
            _clause.AppendSql( "a" );
            Assert.Equal( "Select a", GetSql() );
        }

        /// <summary>
        /// 设置列
        /// </summary>
        [Fact]
        public void TestSelect_17() {
            _clause.Select( "a.[b],c,[d]","o" );
            _clause.AppendSql( "e=1" );
            _clause.Select( "f" );
            _clause.AppendSql( "g" );
            Assert.Equal( "Select [a].[b],[o].[c],[o].[d],e=1,[f],g", GetSql() );
        }

        /// <summary>
        /// 测试实体解析器
        /// </summary>
        [Fact]
        public void TestSelect_18() {
            _clause = new SelectClause( new SqlServerDialect(), new TestEntityResolver(), new EntityAliasRegister() );
            _clause.Select<Sample>( t => new object[] { t.Email, t.IntValue } );
            Assert.Equal( "Select [t_Email],[t_IntValue]", GetSql() );
        }

        /// <summary>
        /// 测试实体别名注册器
        /// </summary>
        [Fact]
        public void TestSelect_19() {
            _clause = new SelectClause( new SqlServerDialect(), new TestEntityResolver(), new TestEntityAliasRegister() );
            _clause.Select<Sample>( t => new object[] { t.Email, t.IntValue } );
            var result = _clause.ToSql();
            Assert.Equal( "Select [as_Sample].[t_Email],[as_Sample].[t_IntValue]", result );
        }

        /// <summary>
        /// 设置列 - lambda表达式 - 设置单个列名
        /// </summary>
        [Fact]
        public void TestSelect_20() {
            _clause.Select<Sample>( t => t.Email );
            Assert.Equal( "Select [Email]", GetSql() );
        }

        /// <summary>
        /// 设置列 - lambda表达式 - 设置单个列名和列别名
        /// </summary>
        [Fact]
        public void TestSelect_21() {
            _clause.Select<Sample>( t => t.Email, "e" );
            Assert.Equal( "Select [Email] As [e]", GetSql() );
        }
    }
}
