using MySqlConnector;

namespace Util.Data.Sql {
    /// <summary>
    /// MySql数据库工厂
    /// </summary>
    public class MySqlDatabaseFactory : IDatabaseFactory {
        /// <summary>
        /// 创建数据库信息
        /// </summary>
        /// <param name="connection">数据库连接字符串</param>
        public IDatabase Create( string connection ) {
            return new DefaultDatabase( new MySqlConnection( connection ) );
        }
    }
}
