using System;

namespace Util.Data.Sql {
    /// <summary>
    /// MySql Sql执行器
    /// </summary>
    public class MySqlExecutor : MySqlExecutorBase {
        /// <summary>
        /// 初始化MySql Sql执行器
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="options">Sql配置</param>
        /// <param name="database">数据库信息,用于接入其它数据源,比如EF DbContext</param>
        public MySqlExecutor( IServiceProvider serviceProvider, SqlOptions<MySqlExecutor> options, IDatabase database = null )
            : base( serviceProvider, options, database ) {
        }
    }
}
