using Util.Data.Sql.Builders.Clauses;
using Util.Data.Sql.Builders.Params;
using Util.Data.Sql.Builders.Sets;

namespace Util.Data.Sql.Builders {
    /// <summary>
    /// Sql组件访问器
    /// </summary>
    public interface ISqlPartAccessor {
        /// <summary>
        /// Sql方言
        /// </summary>
        IDialect Dialect { get; }
        /// <summary>
        /// 参数管理器
        /// </summary>
        IParameterManager ParameterManager { get; }
        /// <summary>
        /// 起始子句
        /// </summary>
        IStartClause StartClause { get; }
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
        /// <summary>
        /// Insert子句
        /// </summary>
        IInsertClause InsertClause { get; }
        /// <summary>
        /// 结束子句
        /// </summary>
        IEndClause EndClause { get; }
        /// <summary>
        /// Sql生成器集合
        /// </summary>
        ISqlBuilderSet SqlBuilderSet { get; }
    }
}
