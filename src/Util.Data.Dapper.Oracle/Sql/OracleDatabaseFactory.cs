namespace Util.Data.Dapper.Sql; 

/// <summary>
/// Oracle数据库工厂
/// </summary>
public class OracleDatabaseFactory : IDatabaseFactory {
    /// <summary>
    /// 创建数据库信息
    /// </summary>
    /// <param name="connection">数据库连接字符串</param>
    public IDatabase Create( string connection ) {
        var con = new OracleConnection( connection );
        return new DefaultDatabase( con );
    }
}