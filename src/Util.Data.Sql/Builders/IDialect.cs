namespace Util.Data.Sql.Builders {
    /// <summary>
    /// Sql方言
    /// </summary>
    public interface IDialect {
        /// <summary>
        /// 获取起始转义标识符
        /// </summary>
        string GetOpeningIdentifier();
        /// <summary>
        /// 获取结束转义标识符
        /// </summary>
        string GetClosingIdentifier();
        /// <summary>
        /// 获取安全名称
        /// </summary>
        /// <param name="name">名称</param>
        string GetSafeName( string name );
        /// <summary>
        /// 获取参数前缀
        /// </summary>
        string GetPrefix();
        /// <summary>
        /// 替换Sql,将[]替换为特定Sql转义符
        /// </summary>
        /// <param name="sql">原始Sql</param>
        string ReplaceSql( string sql );
    }
}
