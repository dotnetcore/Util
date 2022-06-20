namespace Util.Data.Sql.Builders.Clauses {
    /// <summary>
    /// Sql子句
    /// </summary>
    public interface ISqlClause : ISqlContent {
        /// <summary>
        /// 验证
        /// </summary>
        bool Validate();
    }
}
