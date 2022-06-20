using System.Data.SqlClient;

namespace Util.Data.Sql {
    /// <summary>
    /// Sql Server数据库工厂
    /// </summary>
    public class SqlServerDatabaseFactory : IDatabaseFactory {
        /// <summary>
        /// 创建数据库信息
        /// </summary>
        /// <param name="connection">数据库连接字符串</param>
        public IDatabase Create( string connection ) {
            return new DefaultDatabase( new SqlConnection( connection ) );
        }
    }
}
