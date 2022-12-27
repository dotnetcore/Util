using System;
using Util.Data.Sql.Builders;
using Util.Data.Sql.Builders.Operations;

namespace Util.Data.Sql {
    /// <summary>
    /// From子句操作扩展
    /// </summary>
    public static class FromClauseExtensions {

        #region From(设置表)

        /// <summary>
        /// 设置表名
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="table">表名</param>
        public static T From<T>( this T source, string table ) where T : IFrom {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.FromClause.From( table );
            return source;
        }

        /// <summary>
        /// 设置子查询表
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="builder">Sql生成器</param>
        /// <param name="alias">表别名</param>
        public static T From<T>( this T source, ISqlBuilder builder, string alias ) where T : IFrom {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.FromClause.From( builder, alias );
            return source;
        }

        /// <summary>
        /// 设置子查询表
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="action">子查询操作</param>
        /// <param name="alias">表别名</param>
        public static T From<T>( this T source, Action<ISqlBuilder> action, string alias ) where T : IFrom {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.FromClause.From( action, alias );
            return source;
        }

        #endregion

        #region AppendFrom(添加到From子句)

        /// <summary>
        /// 添加到From子句
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加,默认会将[]替换为特定Sql转义符</param>
        public static T AppendFrom<T>( this T source, string sql,bool raw = false ) where T : IFrom {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.FromClause.AppendSql( sql, raw );
            return source;
        }

        #endregion

        #region ClearFrom(清空From子句)

        /// <summary>
        /// 清空From子句
        /// </summary>
        /// <param name="source">源</param>
        public static T ClearFrom<T>( this T source ) where T : IFrom {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.FromClause.Clear();
            return source;
        }

        #endregion
    }
}
