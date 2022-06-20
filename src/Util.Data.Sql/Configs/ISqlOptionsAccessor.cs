namespace Util.Data.Sql.Configs {
    /// <summary>
    /// Sql配置访问器
    /// </summary>
    public interface ISqlOptionsAccessor {
        /// <summary>
        /// 获取Sql配置
        /// </summary>
        SqlOptions GetOptions();
    }
}
