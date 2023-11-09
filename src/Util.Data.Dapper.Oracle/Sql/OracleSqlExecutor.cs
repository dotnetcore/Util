using Util.Data.Sql;

namespace Util.Data.Dapper.Sql; 

/// <summary>
/// Oracle Sql执行器
/// </summary>
public class OracleSqlExecutor : OracleSqlExecutorBase {
    /// <summary>
    /// 初始化Oracle Sql执行器
    /// </summary>
    /// <param name="serviceProvider">服务提供器</param>
    /// <param name="options">Sql配置</param>
    /// <param name="database">数据库信息,用于接入其它数据源,比如EF DbContext</param>
    public OracleSqlExecutor( IServiceProvider serviceProvider, SqlOptions<OracleSqlExecutor> options, IDatabase database = null )
        : base( serviceProvider, options, database ) {
    }
}