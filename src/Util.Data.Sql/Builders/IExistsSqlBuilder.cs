namespace Util.Data.Sql.Builders {
    /// <summary>
    /// 判断是否存在Sql生成器
    /// </summary>
    public interface IExistsSqlBuilder {
        /// <summary>
        /// 获取Sql语句
        /// </summary>
        string GetSql();
    }
}
