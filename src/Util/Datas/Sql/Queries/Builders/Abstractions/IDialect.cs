namespace Util.Datas.Sql.Queries.Builders.Abstractions {
    /// <summary>
    /// Sql方言
    /// </summary>
    public interface IDialect {
        /// <summary>
        /// 安全名称
        /// </summary>
        /// <param name="name">名称</param>
        string SafeName( string name );
        /// <summary>
        /// 获取参数前缀
        /// </summary>
        string GetPrefix();
    }
}
