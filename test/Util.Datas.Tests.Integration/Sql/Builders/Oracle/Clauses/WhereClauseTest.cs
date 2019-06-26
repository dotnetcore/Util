using Util.Datas.Dapper.Oracle;
using Util.Datas.Dapper.SqlServer;
using Util.Datas.Sql.Builders.Clauses;
using Util.Datas.Sql.Builders.Core;
using Util.Datas.Tests.Sql.Builders.Samples;
using Xunit;

namespace Util.Datas.Tests.Sql.Builders.Oracle.Clauses {
    /// <summary>
    /// Where子句测试
    /// </summary>
    public class WhereClauseTest {
        /// <summary>
        /// 参数管理器
        /// </summary>
        private readonly ParameterManager _parameterManager;
        /// <summary>
        /// 表数据库
        /// </summary>
        private readonly TestTableDatabase _database;
        /// <summary>
        /// Sql生成器
        /// </summary>
        private readonly SqlServerBuilder _builder;
        /// <summary>
        /// Where子句
        /// </summary>
        private readonly WhereClause _clause;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public WhereClauseTest() {
            _parameterManager = new ParameterManager( new OracleDialect() );
            _database = new TestTableDatabase();
            _builder = new SqlServerBuilder( new TestEntityMatedata(), null, _parameterManager );
            _clause = new WhereClause( _builder, new OracleDialect(), new EntityResolver(), new EntityAliasRegister(), _parameterManager );
        }

        /// <summary>
        /// 获取Sql语句
        /// </summary>
        private string GetSql() {
            return _clause.ToSql();
        }

        /// <summary>
        /// 设置条件
        /// </summary>
        [Fact]
        public void TestWhere_1() {
            _clause.Where( "Name", "a" );
            Assert.Equal( "Where \"Name\"=:p_0", GetSql() );
        }
    }
}
