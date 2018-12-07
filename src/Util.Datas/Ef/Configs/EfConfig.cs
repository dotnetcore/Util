namespace Util.Datas.Ef.Configs {
    /// <summary>
    /// Ef配置
    /// </summary>
    public class EfConfig {
        /// <summary>
        /// Ef日志级别，默认值：EfLogLevel.Sql，表示仅输出Sql
        /// </summary>
        public EfLogLevel EfLogLevel { get; set; } = EfLogLevel.Sql;
    }
}
