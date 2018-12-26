using Util.Datas.Enums;

namespace Util.Datas.Sql.Queries.Configs {
    /// <summary>
    /// Sql查询配置
    /// </summary>
    public class SqlQueryConfig {
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