using System;

namespace Util.Data.Sql {
    /// <summary>
    /// PostgreSql Sql查询对象
    /// </summary>
    public class PostgreSqlQuery : PostgreSqlQueryBase {
        /// <summary>
        /// 初始化PostgreSql Sql查询对象
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="options">Sql配置</param>
        /// <param name="database">数据库信息,用于接入其它数据源,比如EF DbContext</param>
        public PostgreSqlQuery( IServiceProvider serviceProvider, SqlOptions<PostgreSqlQuery> options, IDatabase database = null )
            : base( serviceProvider, options, database ) {
        }
    }
}