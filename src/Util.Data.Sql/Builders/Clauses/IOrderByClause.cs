namespace Util.Data.Sql.Builders.Clauses {
    /// <summary>
    /// Order By子句
    /// </summary>
    public interface IOrderByClause : ISqlClause {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="order">排序列表</param>
        void OrderBy( string order );
        /// <summary>
        /// 添加到Order By子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加</param>
        void AppendSql( string sql, bool raw );
        /// <summary>
        /// 清理
        /// </summary>
        void Clear();
        /// <summary>
        /// 复制Order By子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        IOrderByClause Clone( SqlBuilderBase builder );
    }
}
