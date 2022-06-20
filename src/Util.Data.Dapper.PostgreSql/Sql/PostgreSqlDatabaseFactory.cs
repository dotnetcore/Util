using Npgsql;

namespace Util.Data.Sql {
    /// <summary>
    /// PostgreSql数据库工厂
    /// </summary>
    public class PostgreSqlDatabaseFactory : IDatabaseFactory {
        /// <summary>
        /// 创建数据库信息
        /// </summary>
        /// <param name="connection">数据库连接字符串</param>
        public IDatabase Create( string connection ) {
            return new DefaultDatabase( new NpgsqlConnection( connection ) );
        }
    }
}
