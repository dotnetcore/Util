using System;
using Util.Datas.Sql.Builders;

namespace Util.Datas.Sql {
    /// <summary>
    /// OrderBy子句扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="order">排序列表,范例：a.Id,b.Name desc</param>
        /// <param name="tableAlias">表别名</param>
        public static T OrderBy<T>( this T source, string order, string tableAlias = null ) where T : IOrderBy {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.OrderByClause.OrderBy( order, tableAlias );
            return source;
        }

        /// <summary>
        /// 添加到OrderBy子句
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        public static T AppendOrderBy<T>( this T source, string sql ) where T : IOrderBy {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.OrderByClause.AppendSql( sql );
            return source;
        }

        /// <summary>
        /// 添加到OrderBy子句
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        /// <param name="condition">该值为true时添加Sql，否则忽略</param>
        public static T AppendOrderBy<T>( this T source, string sql, bool condition ) where T : IOrderBy {
            return condition ? AppendOrderBy( source, sql ) : source;
        }
    }
}