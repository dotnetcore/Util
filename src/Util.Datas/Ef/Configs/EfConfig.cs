using Util.Datas.Sql.Queries.Configs;

namespace Util.Datas.Ef.Configs {
    /// <summary>
    /// Ef配置
    /// </summary>
    public class EfConfig {
        /// <summary>
        /// 初始化Ef配置
        /// </summary>
        public EfConfig() {
            SqlQuery = new SqlQueryConfig();
        }

        /// <summary>
        /// Ef日志级别，默认值：EfLogLevel.Sql，表示仅输出Sql
        /// </summary>
        public EfLogLevel EfLogLevel { get; set; } = EfLogLevel.Sql;

        /// <summary>
        /// Sql查询配置
        /// </summary>
        public SqlQueryConfig SqlQuery { get; set; }
    }
}
