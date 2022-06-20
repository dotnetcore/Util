using System;
using Util.Data.Sql.Builders;
using Util.Data.Sql.Builders.Operations;

namespace Util.Data.Sql {
    /// <summary>
    /// Join子句操作扩展
    /// </summary>
    public static class JoinClauseExtensions {

        #region Join(内连接)

        /// <summary>
        /// 内连接
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="table">表名</param>
        public static T Join<T>( this T source, string table ) where T : IJoin {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.JoinClause.Join( table );
            return source;
        }

        /// <summary>
        /// 内连接子查询
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="builder">Sql生成器</param>
        /// <param name="alias">表别名</param>
        public static T Join<T>( this T source, ISqlBuilder builder, string alias ) where T : IJoin {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
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
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.JoinClause.Join( action, alias );
            return source;
        }

        #endregion

        #region LeftJoin(左外连接)

        /// <summary>
        /// 左外连接
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="table">表名</param>
        public static T LeftJoin<T>( this T source, string table ) where T : IJoin {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.JoinClause.LeftJoin( table );
            return source;
        }

        /// <summary>
        /// 左外连接子查询
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="builder">Sql生成器</param>
        /// <param name="alias">表别名</param>
        public static T LeftJoin<T>( this T source, ISqlBuilder builder, string alias ) where T : IJoin {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
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
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.JoinClause.LeftJoin( action, alias );
            return source;
        }

        #endregion

        #region RightJoin(右外连接)

        /// <summary>
        /// 右外连接
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="table">表名</param>
        public static T RightJoin<T>( this T source, string table ) where T : IJoin {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.JoinClause.RightJoin( table );
            return source;
        }

        /// <summary>
        /// 右外连接子查询
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="builder">Sql生成器</param>
        /// <param name="alias">表别名</param>
        public static T RightJoin<T>( this T source, ISqlBuilder builder, string alias ) where T : IJoin {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
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
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.JoinClause.RightJoin( action, alias );
            return source;
        }

        #endregion

        #region On(设置连接条件)

        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        /// <param name="isParameterization">是否参数化</param>
        public static T On<T>( this T source, string column, object value, Operator @operator = Operator.Equal, bool isParameterization = false ) where T : IJoin {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.JoinClause.On( column, value, @operator, isParameterization );
            return source;
        }

        #endregion

        #region AppendJoin(添加到内连接子句)

        /// <summary>
        /// 添加到内连接子句
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加,默认会将[]替换为特定Sql转义符</param>
        public static T AppendJoin<T>( this T source, string sql, bool raw = false ) where T : IJoin {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.JoinClause.AppendJoin( sql, raw );
            return source;
        }

        #endregion

        #region AppendLeftJoin(添加到左外连接子句)

        /// <summary>
        /// 添加到左外连接子句
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加,默认会将[]替换为特定Sql转义符</param>
        public static T AppendLeftJoin<T>( this T source, string sql, bool raw = false ) where T : IJoin {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.JoinClause.AppendLeftJoin( sql, raw );
            return source;
        }

        #endregion

        #region AppendRightJoin(添加到右外连接子句)

        /// <summary>
        /// 添加到右外连接子句
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加,默认会将[]替换为特定Sql转义符</param>
        public static T AppendRightJoin<T>( this T source, string sql, bool raw = false ) where T : IJoin {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.JoinClause.AppendRightJoin( sql, raw );
            return source;
        }

        #endregion

        #region AppendOn(添加到On子句)

        /// <summary>
        /// 添加到On子句
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加,默认会将[]替换为特定Sql转义符</param>
        public static T AppendOn<T>( this T source, string sql, bool raw = false ) where T : IJoin {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.JoinClause.AppendOn( sql, raw );
            return source;
        }

        #endregion

        #region ClearJoin(清空Join子句)

        /// <summary>
        /// 清空Join子句
        /// </summary>
        /// <param name="source">源</param>
        public static T ClearJoin<T>( this T source ) where T : IJoin {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.JoinClause.Clear();
            return source;
        }

        #endregion
    }
}
