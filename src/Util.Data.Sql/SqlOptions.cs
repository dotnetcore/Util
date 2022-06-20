using System.Data;

namespace Util.Data.Sql {
    /// <summary>
    /// Sql配置
    /// </summary>
    public class SqlOptions<T> : SqlOptions where T: class {
    }

    /// <summary>
    /// Sql配置
    /// </summary>
    public class SqlOptions {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// 数据库连接
        /// </summary>
        public IDbConnection Connection { get; set; }
        /// <summary>
        /// 日志类别
        /// </summary>
        public string LogCategory { get; set; } = "Util.Data.Sql";
    }
}
