using Util.Datas.Enums;

namespace Util.Datas.Dapper.Configs {
    /// <summary>
    /// Sql查询配置
    /// </summary>
    public class SqlQueryConfig {
        /// <summary>
        /// 数据库类型，默认为Sql Server
        /// </summary>
        public DatabaseType DatabaseType { get; set; } = DatabaseType.SqlServer;
    }
}
