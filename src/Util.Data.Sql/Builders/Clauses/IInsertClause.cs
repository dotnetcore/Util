namespace Util.Data.Sql.Builders.Clauses {
    /// <summary>
    /// Insert子句
    /// </summary>
    public interface IInsertClause : ISqlClause {
        /// <summary>
        /// 设置插入的表和列名集合
        /// </summary>
        /// <param name="columns">列名集合</param>
        /// <param name="table">表名</param>
        void Insert( string columns, string table = null );
        /// <summary>
        /// 设置Insert语句插入的值集合
        /// </summary>
        /// <param name="values">值集合</param>
        void Values( params object[] values );
        /// <summary>
        /// 添加到Insert子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加</param>
        void AppendInsert( string sql, bool raw );
        /// <summary>
        /// 添加到Values子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加</param>
        void AppendValues( string sql, bool raw );
        /// <summary>
        /// 清理
        /// </summary>
        void Clear();
        /// <summary>
        /// 复制Insert子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        IInsertClause Clone( SqlBuilderBase builder );
    }
}
