using System.Data;

namespace Util.Data.Sql {
    /// <summary>
    /// Sql配置扩展
    /// </summary>
    public static class SqlOptionsExtensions {

        #region ConnectionString(设置数据库连接字符串)

        /// <summary>
        /// 设置数据库连接字符串
        /// </summary>
        /// <param name="options">源</param>
        /// <param name="connectionString">数据库连接字符串</param>
        public static SqlOptions ConnectionString( this SqlOptions options, string connectionString ) {
            options.CheckNull( nameof(options) );
            options.ConnectionString = connectionString;
            return options;
        }

        #endregion

        #region Connection(设置数据库连接)

        /// <summary>
        /// 设置数据库连接
        /// </summary>
        /// <param name="options">源</param>
        /// <param name="connection">数据库连接</param>
        public static SqlOptions Connection( this SqlOptions options, IDbConnection connection ) {
            options.CheckNull( nameof( options ) );
            options.Connection = connection;
            return options;
        }

        #endregion

        #region LogCategory(设置日志类别)

        /// <summary>
        /// 设置日志类别
        /// </summary>
        /// <param name="options">源</param>
        /// <param name="logCategory">日志类别</param>
        public static SqlOptions LogCategory( this SqlOptions options, string logCategory ) {
            options.CheckNull( nameof( options ) );
            options.LogCategory = logCategory;
            return options;
        }

        #endregion
    }
}
