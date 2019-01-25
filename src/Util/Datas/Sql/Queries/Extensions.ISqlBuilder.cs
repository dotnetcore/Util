using System;
using System.Linq.Expressions;
using Util.Datas.Queries;
using Util.Datas.Sql.Queries.Builders.Abstractions;

namespace Util.Datas.Sql.Queries {
    /// <summary>
    /// Sql生成器扩展
    /// </summary>
    public static partial class Extensions {

        #region AppendIf(添加子句)

        /// <summary>
        /// 添加到Select子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="condition">该值为true时添加Sql，否则忽略</param>
        public static ISqlBuilder AppendSelect( this ISqlBuilder builder, string sql, bool condition ) {
            if( condition )
                builder.AppendSelect( sql );
            return builder;
        }

        /// <summary>
        /// 添加到From子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="condition">该值为true时添加Sql，否则忽略</param>
        public static ISqlBuilder AppendFrom( this ISqlBuilder builder, string sql, bool condition ) {
            if( condition )
                builder.AppendFrom( sql );
            return builder;
        }

        /// <summary>
        /// 添加到内连接子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="condition">该值为true时添加Sql，否则忽略</param>
        public static ISqlBuilder AppendJoin( this ISqlBuilder builder, string sql, bool condition ) {
            if( condition )
                builder.AppendJoin( sql );
            return builder;
        }

        /// <summary>
        /// 添加到左外连接子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="condition">该值为true时添加Sql，否则忽略</param>
        public static ISqlBuilder AppendLeftJoin( this ISqlBuilder builder, string sql, bool condition ) {
            if( condition )
                builder.AppendLeftJoin( sql );
            return builder;
        }

        /// <summary>
        /// 添加到右外连接子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="condition">该值为true时添加Sql，否则忽略</param>
        public static ISqlBuilder AppendRightJoin( this ISqlBuilder builder, string sql, bool condition ) {
            if( condition )
                builder.AppendRightJoin( sql );
            return builder;
        }

        /// <summary>
        /// 添加到Where子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="condition">该值为true时添加Sql，否则忽略</param>
        public static ISqlBuilder AppendWhere( this ISqlBuilder builder, string sql, bool condition ) {
            if( condition )
                builder.AppendWhere( sql );
            return builder;
        }

        /// <summary>
        /// 添加到GroupBy子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="condition">该值为true时添加Sql，否则忽略</param>
        public static ISqlBuilder AppendGroupBy( this ISqlBuilder builder, string sql, bool condition ) {
            if( condition )
                builder.AppendGroupBy( sql );
            return builder;
        }

        /// <summary>
        /// 添加到OrderBy子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="condition">该值为true时添加Sql，否则忽略</param>
        public static ISqlBuilder AppendOrderBy( this ISqlBuilder builder, string sql, bool condition ) {
            if( condition )
                builder.AppendOrderBy( sql );
            return builder;
        }

        #endregion

        #region OrIf(或连接条件)

        /// <summary>
        /// Or连接条件
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="predicate">查询条件</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        public static ISqlBuilder OrIf( this ISqlBuilder builder, ICondition predicate, bool condition ) {
            if( condition )
                builder.Or( predicate );
            return builder;
        }

        /// <summary>
        /// Or连接条件
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="predicate">查询条件</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        public static ISqlBuilder OrIf<TEntity>( this ISqlBuilder builder, Expression<Func<TEntity, bool>> predicate, bool condition ) where TEntity : class {
            return OrIf( builder, condition, predicate );
        }

        /// <summary>
        /// Or连接条件
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="predicates">查询条件</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        public static ISqlBuilder OrIf<TEntity>( this ISqlBuilder builder, bool condition, params Expression<Func<TEntity, bool>>[] predicates ) where TEntity : class {
            if( condition )
                builder.Or( predicates );
            return builder;
        }

        #endregion

        #region WhereIf(设置查询条件)

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        /// <param name="operator">运算符</param>
        public static ISqlBuilder WhereIf( this ISqlBuilder builder, string column, object value, bool condition, Operator @operator = Operator.Equal ) {
            if( condition )
                builder.Where( column, value, @operator );
            return builder;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        /// <param name="operator">运算符</param>
        public static ISqlBuilder WhereIf<TEntity>( this ISqlBuilder builder, Expression<Func<TEntity, object>> expression, object value, bool condition, Operator @operator = Operator.Equal ) where TEntity : class {
            if( condition )
                builder.Where( expression, value, @operator );
            return builder;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="expression">查询条件表达式,范例：t => t.Name.Contains("a") &amp;&amp; ( t.Code == "b" || t.Age > 1 )</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        public static ISqlBuilder WhereIf<TEntity>( this ISqlBuilder builder, Expression<Func<TEntity, bool>> expression, bool condition ) where TEntity : class {
            if( condition )
                builder.Where( expression );
            return builder;
        }

        /// <summary>
        /// 设置子查询条件
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="column">列名</param>
        /// <param name="subBuilder">子查询Sql生成器</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        /// <param name="operator">运算符</param>
        public static ISqlBuilder WhereIf( this ISqlBuilder builder, string column, ISqlBuilder subBuilder, bool condition, Operator @operator = Operator.Equal ) {
            if( condition )
                builder.Where( column, subBuilder, @operator );
            return builder;
        }

        /// <summary>
        /// 设置子查询条件
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="subBuilder">子查询Sql生成器</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        /// <param name="operator">运算符</param>
        public static ISqlBuilder WhereIf<TEntity>( this ISqlBuilder builder, Expression<Func<TEntity, object>> expression, ISqlBuilder subBuilder, 
            bool condition, Operator @operator = Operator.Equal ) where TEntity : class {
            if( condition )
                builder.Where( expression, subBuilder, @operator );
            return builder;
        }

        /// <summary>
        /// 设置子查询条件
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="column">列名</param>
        /// <param name="action">子查询操作</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        /// <param name="operator">运算符</param>
        public static ISqlBuilder WhereIf( this ISqlBuilder builder, string column, Action<ISqlBuilder> action, bool condition, Operator @operator = Operator.Equal ) {
            if( condition )
                builder.Where( column, action, @operator );
            return builder;
        }

        /// <summary>
        /// 设置子查询条件
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="action">子查询操作</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        /// <param name="operator">运算符</param>
        public static ISqlBuilder WhereIf<TEntity>( this ISqlBuilder builder, Expression<Func<TEntity, object>> expression, Action<ISqlBuilder> action,
            bool condition, Operator @operator = Operator.Equal ) where TEntity : class {
            if( condition )
                builder.Where( expression, action, @operator );
            return builder;
        }

        #endregion
    }
}