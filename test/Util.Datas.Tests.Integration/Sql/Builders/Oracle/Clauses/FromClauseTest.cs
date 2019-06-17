using Util.Datas.Dapper.Oracle;
using Util.Datas.Sql.Builders.Clauses;
using Util.Datas.Sql.Builders.Core;
using Util.Datas.Tests.Sql.Builders.Samples;
using Xunit;

namespace Util.Datas.Tests.Sql.Builders.Oracle.Clauses {
    /// <summary>
    /// From子句测试
    /// </summary>
    public class FromClauseTest {
        /// <summary>
        /// From子句
        /// </summary>
        private readonly FromClause _clause;
        /// <summary>
        /// 表数据库
        /// </summary>
        private readonly TestTableDatabase _database;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public FromClauseTest() {
            _database = new TestTableDatabase();
            _clause = new OracleFromClause( null, new OracleDialect(), new EntityResolver(), new EntityAliasRegister(), null );
        }

        /// <summary>
        /// 获取Sql语句
        /// </summary>
        private string GetSql() {
            return _clause.ToSql();
        }

        /// <summary>
        /// 默认输出空
        /// </summary>
        [Fact]
        public void TestDefault() {
            Assert.Null( GetSql() );
        }

        /// <summary>
        /// 设置表
        /// </summary>
        [Fact]
        public void TestFrom_1() {
            _clause.From( "a" );
            Assert.Equal( "From \"a\"", GetSql() );
        }

        /// <summary>
        /// 设置表 - 别名
        /// </summary>
        [Fact]
        public void TestFrom_2() {
            _clause.From( "a", "b" );
            Assert.Equal( "From \"a\" \"b\"", GetSql() );
        }

        /// <summary>
        /// 设置表 - 架构
        /// </summary>
        [Fact]
        public void TestFrom_3() {
            _clause.From( "a.b", "c" );
            Assert.Equal( "From \"a\".\"b\" \"c\"", GetSql() );
        }
    }
}
