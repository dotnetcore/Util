namespace Util.Data.Sql.Builders.Clauses {
    /// <summary>
    /// Group By子句
    /// </summary>
    public interface IGroupByClause : ISqlClause {
        /// <summary>
        /// 添加分组列
        /// </summary>
        /// <param name="columns">分组字段</param>
        void GroupBy( string columns );
        /// <summary>
        /// 添加分组条件
        /// </summary>
        /// <param name="expression">聚合表达式</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        /// <param name="isParameterization">是否参数化</param>
        void Having( string expression, object value, Operator @operator = Operator.Equal,bool isParameterization = true );
        /// <summary>
        /// 添加到Group By子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加</param>
        void AppendGroupBy( string sql, bool raw );
        /// <summary>
        /// 添加到Having子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加</param>
        void AppendHaving( string sql, bool raw );
        /// <summary>
        /// 清理
        /// </summary>
        void Clear();
        /// <summary>
        /// 复制Group By子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        IGroupByClause Clone( SqlBuilderBase builder );
    }
}
