using Util.Datas.Enums;

namespace Util.Datas.Sql.Configs {
    /// <summary>
    /// Sql配置
    /// </summary>
    public class SqlOptions {
        /// <summary>
        /// 数据库类型，默认为Sql Server
        /// </summary>
        public DatabaseType DatabaseType { get; set; } = DatabaseType.SqlServer;
        /// <summary>
        /// 是否在执行之后清空Sql和参数，默认为 true
        /// </summary>
        public bool IsClearAfterExecution { get; set; } = true;
    }
}