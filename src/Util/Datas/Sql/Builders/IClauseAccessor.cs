namespace Util.Datas.Sql.Builders {
    /// <summary>
    /// Sql子句访问器
    /// </summary>
    public interface IClauseAccessor {
        /// <summary>
        /// Select子句
        /// </summary>
        ISelectClause SelectClause { get; }
        /// <summary>
        /// From子句
        /// </summary>
        IFromClause FromClause { get; }
        /// <summary>
        /// Join子句
        /// </summary>
        IJoinClause JoinClause { get; }
        /// <summary>
        /// Where子句
        /// </summary>
        IWhereClause WhereClause { get; }
        /// <summary>
        /// GroupBy子句
        /// </summary>
        IGroupByClause GroupByClause { get; }
        /// <summary>
        /// OrderBy子句
        /// </summary>
        IOrderByClause OrderByClause { get; }
    }
}