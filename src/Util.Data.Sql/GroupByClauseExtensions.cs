using Util.Data.Sql.Builders;
using Util.Data.Sql.Builders.Operations;

namespace Util.Data.Sql {
    /// <summary>
    /// Group By子句操作扩展
    /// </summary>
    public static class GroupByClauseExtensions {

        #region GroupBy(添加分组列)

        /// <summary>
        /// 添加分组列
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="columns">分组字段,范例：a.Id,b.Name</param>
        public static T GroupBy<T>( this T source, string columns ) where T : IGroupBy {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.GroupByClause.GroupBy( columns );
            return source;
        }

        #endregion

        #region Having(添加分组条件)

        /// <summary>
        /// 添加分组条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">聚合表达式</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        /// <param name="isParameterization">是否参数化</param>
        public static T Having<T>( this T source, string expression, object value, Operator @operator = Operator.Equal, bool isParameterization = true ) where T : IGroupBy {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.GroupByClause.Having( expression, value , @operator , isParameterization );
            return source;
        }

        #endregion

        #region AppendGroupBy(添加到Group By子句)

        /// <summary>
        /// 添加到Group By子句
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加,默认会将[]替换为特定Sql转义符</param>
        public static T AppendGroupBy<T>( this T source, string sql, bool raw = false ) where T : IGroupBy {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.GroupByClause.AppendGroupBy( sql, raw );
            return source;
        }

        #endregion

        #region AppendHaving(添加到Having子句)

        /// <summary>
        /// 添加到Having子句
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加,默认会将[]替换为特定Sql转义符</param>
        public static T AppendHaving<T>( this T source, string sql, bool raw = false ) where T : IGroupBy {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.GroupByClause.AppendHaving( sql, raw );
            return source;
        }

        #endregion

        #region ClearGroupBy(清空Group By子句)

        /// <summary>
        /// 清空Group By子句
        /// </summary>
        /// <param name="source">源</param>
        public static T ClearGroupBy<T>( this T source ) where T : IGroupBy {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.GroupByClause.Clear();
            return source;
        }

        #endregion
    }
}
