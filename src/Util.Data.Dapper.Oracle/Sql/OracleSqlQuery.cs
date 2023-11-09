using Util.Data.Sql;

namespace Util.Data.Dapper.Sql; 

/// <summary>
/// Oracle Sql查询对象
/// </summary>
public class OracleSqlQuery : OracleSqlQueryBase {
    /// <summary>
    /// 初始化Oracle Sql查询对象
    /// </summary>
    /// <param name="serviceProvider">服务提供器</param>
    /// <param name="options">Sql配置</param>
    /// <param name="database">数据库信息,用于接入其它数据源,比如EF DbContext</param>
    public OracleSqlQuery( IServiceProvider serviceProvider, SqlOptions<OracleSqlQuery> options, IDatabase database = null )
        : base( serviceProvider, options, database ) {
    }
}