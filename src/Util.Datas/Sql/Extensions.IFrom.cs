using System;
using Util.Datas.Sql.Builders;

namespace Util.Datas.Sql {
    /// <summary>
    /// From子句扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 设置表名
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        public static T From<T>( this T source, string table, string alias = null ) where T : IFrom {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.FromClause.From( table, alias );
            return source;
        }

        /// <summary>
        /// 设置子查询表
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="builder">Sql生成器</param>
        /// <param name="alias">表别名</param>
        public static T From<T>( this T source, ISqlBuilder builder, string alias ) where T : IFrom {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
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
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.FromClause.From( action, alias );
            return source;
        }

        /// <summary>
        /// 添加到From子句
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        public static T AppendFrom<T>( this T source, string sql ) where T : IFrom {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.FromClause.AppendSql( sql );
            return source;
        }

        /// <summary>
        /// 添加到From子句
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        /// <param name="condition">该值为true时添加Sql，否则忽略</param>
        public static T AppendFrom<T>( this T source, string sql, bool condition ) where T : IFrom {
            return condition ? AppendFrom( source, sql ) : source;
        }
    }
}