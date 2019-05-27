using System;
using Util.Datas.Queries;
using Util.Datas.Sql.Builders;

namespace Util.Datas.Sql {
    /// <summary>
    /// From子句扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 内连接
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        public static T Join<T>( this T source, string table, string alias = null ) where T : IJoin {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.JoinClause.Join( table, alias );
            return source;
        }

        /// <summary>
        /// 内连接子查询
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="builder">Sql生成器</param>
        /// <param name="alias">表别名</param>
        public static T Join<T>( this T source, ISqlBuilder builder, string alias ) where T : IJoin {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.JoinClause.Join( builder, alias );
            return source;
        }

        /// <summary>
        /// 内连接子查询
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="action">子查询操作</param>
        /// <param name="alias">表别名</param>
        public static T Join<T>( this T source, Action<ISqlBuilder> action, string alias ) where T : IJoin {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.JoinClause.Join( action, alias );
            return source;
        }

        /// <summary>
        /// 添加到内连接子句
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        public static T AppendJoin<T>( this T source, string sql ) where T : IJoin {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.JoinClause.AppendJoin( sql );
            return source;
        }

        /// <summary>
        /// 添加到内连接子句
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        /// <param name="condition">该值为true时添加Sql，否则忽略</param>
        public static T AppendJoin<T>( this T source, string sql, bool condition ) where T : IJoin {
            return condition ? AppendJoin( source, sql ) : source;
        }

        /// <summary>
        /// 左外连接
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        public static T LeftJoin<T>( this T source, string table, string alias = null ) where T : IJoin {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.JoinClause.LeftJoin( table, alias );
            return source;
        }

        /// <summary>
        /// 左外连接子查询
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="builder">Sql生成器</param>
        /// <param name="alias">表别名</param>
        public static T LeftJoin<T>( this T source, ISqlBuilder builder, string alias ) where T : IJoin {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.JoinClause.LeftJoin( builder, alias );
            return source;
        }

        /// <summary>
        /// 左外连接子查询
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="action">子查询操作</param>
        /// <param name="alias">表别名</param>
        public static T LeftJoin<T>( this T source, Action<ISqlBuilder> action, string alias ) where T : IJoin {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.JoinClause.LeftJoin( action, alias );
            return source;
        }

        /// <summary>
        /// 添加到左外连接子句
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        public static T AppendLeftJoin<T>( this T source, string sql ) where T : IJoin {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.JoinClause.AppendLeftJoin( sql );
            return source;
        }

        /// <summary>
        /// 添加到左外连接子句
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        /// <param name="condition">该值为true时添加Sql，否则忽略</param>
        public static T AppendLeftJoin<T>( this T source, string sql, bool condition ) where T : IJoin {
            return condition ? AppendLeftJoin( source, sql ) : source;
        }

        /// <summary>
        /// 右外连接
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        public static T RightJoin<T>( this T source, string table, string alias = null ) where T : IJoin {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.JoinClause.RightJoin( table, alias );
            return source;
        }

        /// <summary>
        /// 右外连接子查询
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="builder">Sql生成器</param>
        /// <param name="alias">表别名</param>
        public static T RightJoin<T>( this T source, ISqlBuilder builder, string alias ) where T : IJoin {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.JoinClause.RightJoin( builder, alias );
            return source;
        }

        /// <summary>
        /// 右外连接子查询
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="action">子查询操作</param>
        /// <param name="alias">表别名</param>
        public static T RightJoin<T>( this T source, Action<ISqlBuilder> action, string alias ) where T : IJoin {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.JoinClause.RightJoin( action, alias );
            return source;
        }

        /// <summary>
        /// 添加到右外连接子句
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        public static T AppendRightJoin<T>( this T source, string sql ) where T : IJoin {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.JoinClause.AppendRightJoin( sql );
            return source;
        }

        /// <summary>
        /// 添加到右外连接子句
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        /// <param name="condition">该值为true时添加Sql，否则忽略</param>
        public static T AppendRightJoin<T>( this T source, string sql, bool condition ) where T : IJoin {
            return condition ? AppendRightJoin( source, sql ) : source;
        }

        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="condition">连接条件</param>
        public static T On<T>( this T source, ICondition condition ) where T : IJoin {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.JoinClause.On( condition );
            return source;
        }

        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        public static T On<T>( this T source, string column, object value, Operator @operator = Operator.Equal ) where T : IJoin {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.JoinClause.On( column, value, @operator );
            return source;
        }

        /// <summary>
        /// 添加到On子句
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="sql">Sql语句</param>
        public static T AppendOn<T>( this T source, string sql ) where T : IJoin {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.JoinClause.AppendOn( sql );
            return source;
        }
    }
}