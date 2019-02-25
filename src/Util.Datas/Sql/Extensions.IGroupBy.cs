using System;
using Util.Datas.Sql.Builders;

namespace Util.Datas.Sql {
    /// <summary>
    /// GroupBy子句扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 分组
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="columns">分组字段,范例：a.Id,b.Name</param>
        /// <param name="having">分组条件,范例：Count(*) > 1</param>
        public static T GroupBy<T>( this T source, string columns, string having = null ) where T : IGroupBy {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.GroupByClause.GroupBy( columns, having );
            return source;
        }

        /// <summary>
        /// 添加到GroupBy子句
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        public static T AppendGroupBy<T>( this T source, string sql ) where T : IGroupBy {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.GroupByClause.AppendSql( sql );
            return source;
        }

        /// <summary>
        /// 添加到GroupBy子句
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        /// <param name="condition">该值为true时添加Sql，否则忽略</param>
        public static T AppendGroupBy<T>( this T source, string sql, bool condition ) where T : IGroupBy {
            return condition ? AppendGroupBy( source, sql ) : source;
        }
    }
}