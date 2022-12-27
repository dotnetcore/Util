using System;
using Util.Data.Sql.Builders;
using Util.Data.Sql.Builders.Operations;

namespace Util.Data.Sql {
    /// <summary>
    /// Select子句操作扩展
    /// </summary>
    public static class SelectClauseExtensions {

        #region Select(设置列)

        /// <summary>
        /// 设置星号*列
        /// </summary>
        /// <param name="source">源</param>
        public static T Select<T>( this T source ) where T : ISelect {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.SelectClause.Select();
            return source;
        }

        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="columns">列名,范例：a.AppId As Id,a.Name</param>
        public static T Select<T>( this T source, string columns ) where T : ISelect {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.SelectClause.Select( columns );
            return source;
        }

        /// <summary>
        /// 设置子查询列
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="builder">Sql生成器</param>
        /// <param name="alias">列别名</param>
        public static T Select<T>( this T source, ISqlBuilder builder, string alias ) where T : ISelect {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.SelectClause.Select( builder, alias );
            return source;
        }

        /// <summary>
        /// 设置子查询列
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="action">子查询操作</param>
        /// <param name="alias">列别名</param>
        public static T Select<T>( this T source, Action<ISqlBuilder> action, string alias ) where T : ISelect {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.SelectClause.Select( action, alias );
            return source;
        }

        #endregion

        #region AppendSelect(添加到Select子句)

        /// <summary>
        /// 添加到Select子句
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加,默认会将[]替换为特定Sql转义符</param>
        public static T AppendSelect<T>( this T source, string sql, bool raw = false ) where T : ISelect {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.SelectClause.AppendSql( sql, raw );
            return source;
        }

        /// <summary>
        /// 添加子查询到Select子句
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="builder">Sql生成器</param>
        public static T AppendSelect<T>( this T source, ISqlBuilder builder ) where T : ISelect {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.SelectClause.AppendSql( builder );
            return source;
        }

        /// <summary>
        /// 添加子查询到Select子句
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="action">子查询操作</param>
        public static T AppendSelect<T>( this T source, Action<ISqlBuilder> action ) where T : ISelect {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.SelectClause.AppendSql( action );
            return source;
        }

        #endregion

        #region ClearSelect(清空Select子句)

        /// <summary>
        /// 清空Select子句
        /// </summary>
        /// <param name="source">源</param>
        public static T ClearSelect<T>( this T source ) where T : ISelect {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.SelectClause.Clear();
            return source;
        }

        #endregion
    }
}
