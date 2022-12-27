namespace Util.Data.Sql.Builders.Clauses {
    /// <summary>
    /// 起始子句
    /// </summary>
    public interface IStartClause : ISqlClause {
        /// <summary>
        /// 公用表表达式CTE
        /// </summary>
        /// <param name="name">公用表表达式名称</param>
        /// <param name="builder">Sql生成器</param>
        void Cte( string name, ISqlBuilder builder );
        /// <summary>
        /// 添加到起始位置
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加</param>
        void Append( string sql, bool raw );
        /// <summary>
        /// 添加到起始位置并换行
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加</param>
        void AppendLine( string sql, bool raw );
        /// <summary>
        /// 清理公用表表达式CTE
        /// </summary>
        void ClearCte();
        /// <summary>
        /// 清理
        /// </summary>
        void Clear();
        /// <summary>
        /// 复制起始子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        IStartClause Clone( SqlBuilderBase builder );
    }
}
