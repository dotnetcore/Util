using Util.Datas.Dapper.PgSql;
using Util.Datas.Sql.Builders.Clauses;
using Util.Datas.Sql.Builders.Core;
using Xunit;

namespace Util.Datas.Tests.Sql.Builders.PgSql.Clauses {
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
            _clause = new SelectClause( new PgSqlBuilder(), new PgSqlDialect(), new EntityResolver(), new EntityAliasRegister() );
        }

        /// <summary>
        /// 获取Sql语句
        /// </summary>
        private string GetSql() {
            return _clause.ToSql();
        }

        /// <summary>
        /// 添加select子句
        /// </summary>
        [Fact]
        public void TestAppendSql_1() {
            _clause.AppendSql( "a" );
            Assert.Equal( "Select a", GetSql() );
        }

        /// <summary>
        /// 添加select子句 - 带方括号
        /// </summary>
        [Fact]
        public void TestAppendSql_2() {
            _clause.AppendSql( "[a].[b]" );
            Assert.Equal( "Select \"a\".\"b\"", GetSql() );
        }
    }
}
