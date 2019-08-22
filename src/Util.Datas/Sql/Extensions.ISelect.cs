using System;
using Util.Datas.Sql.Builders;

namespace Util.Datas.Sql {
    /// <summary>
    /// Select子句扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 过滤重复记录
        /// </summary>
        /// <param name="source">源</param>
        public static T Distinct<T>( this T source ) where T : ISelect {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.SelectClause.Distinct();
            return source;
        }

        /// <summary>
        /// 求总行数
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="columnAlias">列别名</param>
        public static T Count<T>( this T source, string columnAlias = null ) where T : ISelect {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.SelectClause.Count( columnAlias );
            return source;
        }

        /// <summary>
        /// 求总行数
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="column">列</param>
        /// <param name="columnAlias">列别名</param>
        public static T Count<T>( this T source, string column, string columnAlias ) where T : ISelect {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.SelectClause.Count( column, columnAlias );
            return source;
        }

        /// <summary>
        /// 求和
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="column">列</param>
        /// <param name="columnAlias">列别名</param>
        public static T Sum<T>( this T source, string column, string columnAlias = null ) where T : ISelect {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.SelectClause.Sum( column, columnAlias );
            return source;
        }

        /// <summary>
        /// 求平均值
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="column">列</param>
        /// <param name="columnAlias">列别名</param>
        public static T Avg<T>( this T source, string column, string columnAlias = null ) where T : ISelect {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.SelectClause.Avg( column, columnAlias );
            return source;
        }

        /// <summary>
        /// 求最大值
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="column">列</param>
        /// <param name="columnAlias">列别名</param>
        public static T Max<T>( this T source, string column, string columnAlias = null ) where T : ISelect {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.SelectClause.Max( column, columnAlias );
            return source;
        }

        /// <summary>
        /// 求最小值
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="column">列</param>
        /// <param name="columnAlias">列别名</param>
        public static T Min<T>( this T source, string column, string columnAlias = null ) where T : ISelect {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.SelectClause.Min( column, columnAlias );
            return source;
        }

        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="columns">列名,范例：a.AppId As Id,a.Name</param>
        /// <param name="tableAlias">表别名</param>
        public static T Select<T>( this T source, string columns, string tableAlias = null ) where T : ISelect {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.SelectClause.Select( columns, tableAlias );
            return source;
        }

        /// <summary>
        /// 设置子查询列
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="builder">Sql生成器</param>
        /// <param name="columnAlias">列别名</param>
        public static T Select<T>( this T source, ISqlBuilder builder, string columnAlias ) where T : ISelect {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.SelectClause.Select( builder, columnAlias );
            return source;
        }

        /// <summary>
        /// 设置子查询列
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="action">子查询操作</param>
        /// <param name="columnAlias">列别名</param>
        public static T Select<T>( this T source, Action<ISqlBuilder> action, string columnAlias ) where T : ISelect {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.SelectClause.Select( action, columnAlias );
            return source;
        }

        /// <summary>
        /// 添加到Select子句
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        public static T AppendSelect<T>( this T source, string sql ) where T : ISelect {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.SelectClause.AppendSql( sql );
            return source;
        }

        /// <summary>
        /// 添加到Select子句
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        /// <param name="condition">该值为true时添加Sql，否则忽略</param>
        public static T AppendSelect<T>( this T source, string sql, bool condition ) where T : ISelect {
            return condition ? AppendSelect( source, sql ) : source;
        }

        /// <summary>
        /// 移除列名
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="columns">列名,范例：a.AppId,a.Name</param>
        /// <param name="tableAlias">表别名</param>
        public static T RemoveSelect<T>( this T source, string columns, string tableAlias = null ) where T : ISelect {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.SelectClause.RemoveSelect( columns, tableAlias );
            return source;
        }
    }
}