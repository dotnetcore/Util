using System;
using System.Data;

namespace Util.Data {
    /// <summary>
    /// 数据库信息
    /// </summary>
    public class DefaultDatabase : IDatabase {
        /// <summary>
        /// 数据库连接
        /// </summary>
        private readonly IDbConnection _connection;

        /// <summary>
        /// 初始化数据库信息
        /// </summary>
        /// <param name="connection">数据库连接</param>
        public DefaultDatabase( IDbConnection connection ) {
            _connection = connection ?? throw new ArgumentNullException( nameof(connection) );
        }

        /// <summary>
        /// 获取数据库连接
        /// </summary>
        public IDbConnection GetConnection() {
            return _connection;
        }
    }
}
