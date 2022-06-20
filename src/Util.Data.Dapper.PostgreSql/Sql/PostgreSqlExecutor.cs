using System;

namespace Util.Data.Sql {
    /// <summary>
    /// PostgreSql Sql执行器
    /// </summary>
    public class PostgreSqlExecutor : PostgreSqlExecutorBase {
        /// <summary>
        /// 初始化PostgreSql Sql执行器
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="options">Sql配置</param>
        /// <param name="database">数据库信息,用于接入其它数据源,比如EF DbContext</param>
        public PostgreSqlExecutor( IServiceProvider serviceProvider, SqlOptions<PostgreSqlExecutor> options, IDatabase database = null )
            : base( serviceProvider, options, database ) {
        }
    }
}
