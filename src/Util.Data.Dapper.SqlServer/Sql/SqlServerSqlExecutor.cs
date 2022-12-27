using System;

namespace Util.Data.Sql {
    /// <summary>
    /// Sql Server Sql执行器
    /// </summary>
    public class SqlServerSqlExecutor : SqlServerSqlExecutorBase {
        /// <summary>
        /// 初始化Sql Server Sql执行器
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="options">Sql配置</param>
        /// <param name="database">数据库信息,用于接入其它数据源,比如EF DbContext</param>
        public SqlServerSqlExecutor( IServiceProvider serviceProvider, SqlOptions<SqlServerSqlExecutor> options, IDatabase database = null )
            : base( serviceProvider, options, database ) {
        }
    }
}
