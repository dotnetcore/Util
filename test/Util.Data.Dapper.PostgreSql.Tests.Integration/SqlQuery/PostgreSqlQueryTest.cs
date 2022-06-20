using Util.Data.Sql;

namespace Util.Data.Dapper.Tests.SqlQuery {
    /// <summary>
    /// PostgreSql Sql查询对象测试
    /// </summary>
    public partial class PostgreSqlQueryTest {
        /// <summary>
        /// Sql执行器
        /// </summary>
        private readonly ISqlExecutor _sqlExecutor;
        /// <summary>
        /// Sql查询对象
        /// </summary>
        private readonly ISqlQuery _sqlQuery;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public PostgreSqlQueryTest( ISqlExecutor sqlExecutor, ISqlQuery sqlQuery ) {
            _sqlExecutor = sqlExecutor;
            _sqlQuery = sqlQuery;
        }
    }
}
