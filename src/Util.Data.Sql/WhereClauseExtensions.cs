using System;
using System.Collections;
using Util.Data.Queries;
using Util.Data.Sql.Builders;
using Util.Data.Sql.Builders.Operations;

namespace Util.Data.Sql {
    /// <summary>
    /// Where子句操作扩展
    /// </summary>
    public static class WhereClauseExtensions {

        #region Where

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="condition">查询条件</param>
        public static T Where<T>( this T source, ISqlCondition condition ) where T : IWhere {
            source.CheckNull( nameof( source ) );
            if ( source is ISqlPartAccessor accessor )
                accessor.WhereClause.And( condition );
            return source;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        public static T Where<T>( this T source, string column, object value, Operator @operator = Operator.Equal ) where T : IWhere {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.WhereClause.Where( column, value, @operator );
            return source;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="column">列名</param>
        /// <param name="builder">子查询Sql生成器</param>
        /// <param name="operator">运算符</param>
        public static T Where<T>( this T source, string column, ISqlBuilder builder, Operator @operator = Operator.Equal ) where T : IWhere {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.WhereClause.Where( column, builder, @operator );
            return source;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="column">列名</param>
        /// <param name="action">子查询操作</param>
        /// <param name="operator">运算符</param>
        public static T Where<T>( this T source, string column, Action<ISqlBuilder> action, Operator @operator = Operator.Equal ) where T : IWhere {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.WhereClause.Where( column, action, @operator );
            return source;
        }

        #endregion

        #region In

        /// <summary>
        /// 设置In查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="column">列名</param>
        /// <param name="values">值集合</param>
        public static T In<T>( this T source, string column, IEnumerable values ) where T : IWhere {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.WhereClause.Where( column, values,Operator.In );
            return source;
        }

        /// <summary>
        /// 设置In子查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="column">列名</param>
        /// <param name="builder">子查询Sql生成器</param>
        public static T In<T>( this T source, string column, ISqlBuilder builder ) where T : IWhere {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.WhereClause.Where( column, builder, Operator.In );
            return source;
        }

        /// <summary>
        /// 设置In子查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="column">列名</param>
        /// <param name="action">子查询操作</param>
        public static T In<T>( this T source, string column, Action<ISqlBuilder> action ) where T : IWhere {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.WhereClause.Where( column, action, Operator.In );
            return source;
        }

        #endregion

        #region NotIn

        /// <summary>
        /// 设置Not In查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="column">列名</param>
        /// <param name="values">值集合</param>
        public static T NotIn<T>( this T source, string column, IEnumerable values ) where T : IWhere {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.WhereClause.Where( column, values, Operator.NotIn );
            return source;
        }

        /// <summary>
        /// 设置Not In子查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="column">列名</param>
        /// <param name="builder">子查询Sql生成器</param>
        public static T NotIn<T>( this T source, string column, ISqlBuilder builder ) where T : IWhere {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.WhereClause.Where( column, builder, Operator.NotIn );
            return source;
        }

        /// <summary>
        /// 设置Not In子查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="column">列名</param>
        /// <param name="action">子查询操作</param>
        public static T NotIn<T>( this T source, string column, Action<ISqlBuilder> action ) where T : IWhere {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.WhereClause.Where( column, action, Operator.NotIn );
            return source;
        }

        #endregion

        #region IsNull

        /// <summary>
        /// 设置Is Null查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="column">列名</param>
        public static T IsNull<T>( this T source, string column ) where T : IWhere {
            source.CheckNull( nameof( source ) );
            if ( source is ISqlPartAccessor accessor )
                accessor.WhereClause.IsNull( column );
            return source;
        }

        #endregion

        #region IsNotNull

        /// <summary>
        /// 设置Is Not Null查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="column">列名</param>
        public static T IsNotNull<T>( this T source, string column ) where T : IWhere {
            source.CheckNull( nameof( source ) );
            if ( source is ISqlPartAccessor accessor )
                accessor.WhereClause.IsNotNull( column );
            return source;
        }

        #endregion

        #region IsEmpty

        /// <summary>
        /// 设置空条件，范例：[Name] Is Null Or [Name]=''
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="column">列名</param>
        public static T IsEmpty<T>( this T source, string column ) where T : IWhere {
            source.CheckNull( nameof( source ) );
            if ( source is ISqlPartAccessor accessor )
                accessor.WhereClause.IsEmpty( column );
            return source;
        }

        #endregion

        #region IsNotEmpty

        /// <summary>
        /// 设置非空条件，范例：[Name] Is Not Null And [Name]&lt;&gt;''
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="column">列名</param>
        public static T IsNotEmpty<T>( this T source, string column ) where T : IWhere {
            source.CheckNull( nameof( source ) );
            if ( source is ISqlPartAccessor accessor )
                accessor.WhereClause.IsNotEmpty( column );
            return source;
        }

        #endregion

        #region Between

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="column">列名</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public static T Between<T>( this T source, string column, int? min, int? max, Boundary boundary = Boundary.Both ) where T : IWhere {
            source.CheckNull( nameof( source ) );
            if ( source is ISqlPartAccessor accessor )
                accessor.WhereClause.Between( column, min, max, boundary );
            return source;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="column">列名</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public static T Between<T>( this T source, string column, double? min, double? max, Boundary boundary = Boundary.Both ) where T : IWhere {
            source.CheckNull( nameof( source ) );
            if ( source is ISqlPartAccessor accessor )
                accessor.WhereClause.Between( column, min, max, boundary );
            return source;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="column">列名</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public static T Between<T>( this T source, string column, decimal? min, decimal? max, Boundary boundary = Boundary.Both ) where T : IWhere {
            source.CheckNull( nameof( source ) );
            if ( source is ISqlPartAccessor accessor )
                accessor.WhereClause.Between( column, min, max, boundary );
            return source;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="column">列名</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="includeTime">是否包含时间</param>
        /// <param name="boundary">包含边界</param>
        public static T Between<T>( this T source, string column, DateTime? min, DateTime? max, bool includeTime = true, Boundary? boundary = null ) where T : IWhere {
            source.CheckNull( nameof( source ) );
            if ( source is ISqlPartAccessor accessor )
                accessor.WhereClause.Between( column, min, max, includeTime, boundary );
            return source;
        }

        #endregion

        #region Exists

        /// <summary>
        /// 设置Exists查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="builder">子查询Sql生成器</param>
        public static T Exists<T>( this T source, ISqlBuilder builder ) where T : IWhere {
            source.CheckNull( nameof( source ) );
            if ( source is ISqlPartAccessor accessor )
                accessor.WhereClause.Exists( builder );
            return source;
        }

        /// <summary>
        /// 设置Exists查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="action">子查询操作</param>
        public static T Exists<T>( this T source, Action<ISqlBuilder> action ) where T : IWhere {
            source.CheckNull( nameof( source ) );
            if ( source is ISqlPartAccessor accessor )
                accessor.WhereClause.Exists( action );
            return source;
        }

        #endregion

        #region NotExists

        /// <summary>
        /// 设置Not Exists查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="builder">子查询Sql生成器</param>
        public static T NotExists<T>( this T source, ISqlBuilder builder ) where T : IWhere {
            source.CheckNull( nameof( source ) );
            if ( source is ISqlPartAccessor accessor )
                accessor.WhereClause.NotExists( builder );
            return source;
        }

        /// <summary>
        /// 设置Not Exists查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="action">子查询操作</param>
        public static T NotExists<T>( this T source, Action<ISqlBuilder> action ) where T : IWhere {
            source.CheckNull( nameof( source ) );
            if ( source is ISqlPartAccessor accessor )
                accessor.WhereClause.NotExists( action );
            return source;
        }

        #endregion

        #region AppendWhere

        /// <summary>
        /// 添加到Where子句
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加,默认会将[]替换为特定Sql转义符</param>
        public static T AppendWhere<T>( this T source, string sql, bool raw = false ) where T : IWhere {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.WhereClause.AppendSql( sql, raw );
            return source;
        }

        #endregion

        #region ClearWhere

        /// <summary>
        /// 清空Where子句
        /// </summary>
        /// <param name="source">源</param>
        public static T ClearWhere<T>( this T source ) where T : IWhere {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.WhereClause.Clear();
            return source;
        }

        #endregion
    }
}
