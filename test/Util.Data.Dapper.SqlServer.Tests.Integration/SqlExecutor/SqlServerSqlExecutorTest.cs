using Util.Data.Sql;
using Xunit.Abstractions;

namespace Util.Data.Dapper.Tests.SqlExecutor {
    /// <summary>
    /// Sql Server Sql执行器测试
    /// </summary>
    public partial class SqlServerSqlExecutorTest {
        /// <summary>
        /// 测试输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// Sql执行器
        /// </summary>
        private readonly ISqlExecutor _sqlExecutor;
        /// <summary>
        /// Sql执行器2
        /// </summary>
        private readonly ISqlExecutor _sqlExecutor2;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public SqlServerSqlExecutorTest( ITestOutputHelper output, ISqlExecutor sqlExecutor, ISqlExecutor sqlExecutor2 ) {
            _output = output;
            _sqlExecutor = sqlExecutor;
            _sqlExecutor2 = sqlExecutor2;
        }
    }
}
