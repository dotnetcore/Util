using Util.Data.Sql.Builders;
using Util.Data.Sql.Builders.Operations;

namespace Util.Data.Sql {
    /// <summary>
    /// OrderBy子句操作扩展
    /// </summary>
    public static class OrderByClauseExtensions {

        #region OrderBy(排序)

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="order">排序列表,范例：a.Id,b.Name desc</param>
        public static T OrderBy<T>( this T source, string order ) where T : IOrderBy {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.OrderByClause.OrderBy( order );
            return source;
        }

        #endregion

        #region AppendOrderBy(添加到Order By子句)

        /// <summary>
        /// 添加到Order By子句
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加,默认会将[]替换为特定Sql转义符</param>
        public static T AppendOrderBy<T>( this T source, string sql, bool raw = false ) where T : IOrderBy {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.OrderByClause.AppendSql( sql, raw );
            return source;
        }

        #endregion

        #region ClearOrderBy(清空Order By子句)

        /// <summary>
        /// 清空Order By子句
        /// </summary>
        /// <param name="source">源</param>
        public static T ClearOrderBy<T>( this T source ) where T : IOrderBy {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.OrderByClause.Clear();
            return source;
        }

        #endregion
    }
}
