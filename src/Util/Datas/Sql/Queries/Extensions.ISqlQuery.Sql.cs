using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Util.Datas.Queries;
using Util.Datas.Sql.Queries.Builders.Abstractions;

namespace Util.Datas.Sql.Queries {
    /// <summary>
    /// Sql查询对象扩展 - 拼接Sql相关
    /// </summary>
    public static partial class Extensions {

        #region Select子句

        /// <summary>
        /// 过滤重复记录
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        public static ISqlQuery Distinct( this ISqlQuery sqlQuery ) {
            var builder = sqlQuery.GetBuilder();
            builder.Distinct();
            return sqlQuery;
        }

        /// <summary>
        /// 求总行数
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="columnAlias">列别名</param>
        public static ISqlQuery Count( this ISqlQuery sqlQuery, string columnAlias = null ) {
            var builder = sqlQuery.GetBuilder();
            builder.Count( columnAlias );
            return sqlQuery;
        }

        /// <summary>
        /// 求和
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="column">列</param>
        /// <param name="columnAlias">列别名</param>
        public static ISqlQuery Sum( this ISqlQuery sqlQuery, string column, string columnAlias = null ) {
            var builder = sqlQuery.GetBuilder();
            builder.Sum( column,columnAlias );
            return sqlQuery;
        }

        /// <summary>
        /// 求和
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="expression">列名表达式</param>
        /// <param name="columnAlias">列别名</param>
        public static ISqlQuery Sum<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, object>> expression, string columnAlias = null ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.Sum( expression, columnAlias );
            return sqlQuery;
        }

        /// <summary>
        /// 求平均值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="column">列</param>
        /// <param name="columnAlias">列别名</param>
        public static ISqlQuery Average( this ISqlQuery sqlQuery, string column, string columnAlias = null ) {
            var builder = sqlQuery.GetBuilder();
            builder.Average( column, columnAlias );
            return sqlQuery;
        }

        /// <summary>
        /// 求平均值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="expression">列名表达式</param>
        /// <param name="columnAlias">列别名</param>
        public static ISqlQuery Average<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, object>> expression, string columnAlias = null ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.Average( expression, columnAlias );
            return sqlQuery;
        }

        /// <summary>
        /// 求最大值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="column">列</param>
        /// <param name="columnAlias">列别名</param>
        public static ISqlQuery Max( this ISqlQuery sqlQuery, string column, string columnAlias = null ) {
            var builder = sqlQuery.GetBuilder();
            builder.Max( column, columnAlias );
            return sqlQuery;
        }

        /// <summary>
        /// 求最大值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="expression">列名表达式</param>
        /// <param name="columnAlias">列别名</param>
        public static ISqlQuery Max<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, object>> expression, string columnAlias = null ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.Max( expression, columnAlias );
            return sqlQuery;
        }

        /// <summary>
        /// 求最小值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="column">列</param>
        /// <param name="columnAlias">列别名</param>
        public static ISqlQuery Min( this ISqlQuery sqlQuery, string column, string columnAlias = null ) {
            var builder = sqlQuery.GetBuilder();
            builder.Min( column, columnAlias );
            return sqlQuery;
        }

        /// <summary>
        /// 求最小值
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="expression">列名表达式</param>
        /// <param name="columnAlias">列别名</param>
        public static ISqlQuery Min<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, object>> expression, string columnAlias = null ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.Min( expression, columnAlias );
            return sqlQuery;
        }

        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="columns">列名,范例：a.AppId As Id,a.Name</param>
        /// <param name="tableAlias">表别名</param>
        public static ISqlQuery Select( this ISqlQuery sqlQuery, string columns, string tableAlias = null ) {
            var builder = sqlQuery.GetBuilder();
            builder.Select( columns, tableAlias );
            return sqlQuery;
        }

        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="columns">列名,范例：t => new object[] { t.Id, t.Name }</param>
        /// <param name="propertyAsAlias">是否将属性名映射为列别名</param>
        public static ISqlQuery Select<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, object[]>> columns, bool propertyAsAlias = false ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.Select( columns, propertyAsAlias );
            return sqlQuery;
        }

        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="column">列名,范例：t => t.Name，支持字典批量设置列和列别名，
        /// 范例：Select&lt;Sample&gt;( t => new Dictionary&lt;object, string&gt; { { t.Email, "e" }, { t.Url, "u" } } );</param>
        /// <param name="columnAlias">列别名</param>
        public static ISqlQuery Select<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, object>> column, string columnAlias = null ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.Select( column, columnAlias );
            return sqlQuery;
        }

        /// <summary>
        /// 添加到Select子句
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        public static ISqlQuery AppendSelect( this ISqlQuery sqlQuery, string sql ) {
            var builder = sqlQuery.GetBuilder();
            builder.AppendSelect( sql );
            return sqlQuery;
        }

        /// <summary>
        /// 添加到Select子句
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="sqlBuilder">Sql生成器</param>
        /// <param name="columnAlias">列别名</param>
        public static ISqlQuery AppendSelect( this ISqlQuery sqlQuery, ISqlBuilder sqlBuilder, string columnAlias ) {
            var builder = sqlQuery.GetBuilder();
            builder.AppendSelect( sqlBuilder, columnAlias );
            return sqlQuery;
        }

        /// <summary>
        /// 添加到Select子句
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="action">子查询操作</param>
        /// <param name="columnAlias">列别名</param>
        public static ISqlQuery AppendSelect( this ISqlQuery sqlQuery, Action<ISqlBuilder> action, string columnAlias ) {
            var builder = sqlQuery.GetBuilder();
            builder.AppendSelect( action, columnAlias );
            return sqlQuery;
        }

        /// <summary>
        /// 添加到Select子句
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        /// <param name="condition">该值为true时添加Sql，否则忽略</param>
        public static ISqlQuery AppendSelect( this ISqlQuery sqlQuery, string sql, bool condition ) {
            var builder = sqlQuery.GetBuilder();
            builder.AppendSelect( sql, condition );
            return sqlQuery;
        }

        #endregion

        #region From子句

        /// <summary>
        /// 设置表名
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        public static ISqlQuery From( this ISqlQuery sqlQuery, string table, string alias = null ) {
            var builder = sqlQuery.GetBuilder();
            builder.From( table, alias );
            return sqlQuery;
        }

        /// <summary>
        /// 设置表名
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        public static ISqlQuery From<TEntity>( this ISqlQuery sqlQuery, string alias = null, string schema = null ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.From<TEntity>( alias, schema );
            return sqlQuery;
        }

        /// <summary>
        /// 添加到From子句
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        public static ISqlQuery AppendFrom( this ISqlQuery sqlQuery, string sql ) {
            var builder = sqlQuery.GetBuilder();
            builder.AppendFrom( sql );
            return sqlQuery;
        }

        /// <summary>
        /// 添加到From子句
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        /// <param name="condition">该值为true时添加Sql，否则忽略</param>
        public static ISqlQuery AppendFrom( this ISqlQuery sqlQuery, string sql, bool condition ) {
            var builder = sqlQuery.GetBuilder();
            builder.AppendFrom( sql, condition );
            return sqlQuery;
        }

        #endregion

        #region Join子句

        /// <summary>
        /// 内连接
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        public static ISqlQuery Join( this ISqlQuery sqlQuery, string table, string alias = null ) {
            var builder = sqlQuery.GetBuilder();
            builder.Join( table, alias );
            return sqlQuery;
        }

        /// <summary>
        /// 内连接
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        public static ISqlQuery Join<TEntity>( this ISqlQuery sqlQuery, string alias = null, string schema = null ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.Join<TEntity>( alias, schema );
            return sqlQuery;
        }

        /// <summary>
        /// 添加到内连接子句
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        public static ISqlQuery AppendJoin( this ISqlQuery sqlQuery, string sql ) {
            var builder = sqlQuery.GetBuilder();
            builder.AppendJoin( sql );
            return sqlQuery;
        }

        /// <summary>
        /// 添加到内连接子句
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="sqlBuilder">Sql生成器</param>
        /// <param name="alias">表别名</param>
        public static ISqlQuery AppendJoin( this ISqlQuery sqlQuery, ISqlBuilder sqlBuilder, string alias ) {
            var builder = sqlQuery.GetBuilder();
            builder.AppendJoin( sqlBuilder, alias );
            return sqlQuery;
        }

        /// <summary>
        /// 添加到内连接子句
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="action">子查询操作</param>
        /// <param name="alias">表别名</param>
        public static ISqlQuery AppendJoin( this ISqlQuery sqlQuery, Action<ISqlBuilder> action, string alias ) {
            var builder = sqlQuery.GetBuilder();
            builder.AppendJoin( action, alias );
            return sqlQuery;
        }

        /// <summary>
        /// 添加到内连接子句
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        /// <param name="condition">该值为true时添加Sql，否则忽略</param>
        public static ISqlQuery AppendJoin( this ISqlQuery sqlQuery, string sql, bool condition ) {
            var builder = sqlQuery.GetBuilder();
            builder.AppendJoin( sql, condition );
            return sqlQuery;
        }

        /// <summary>
        /// 左外连接
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        public static ISqlQuery LeftJoin( this ISqlQuery sqlQuery, string table, string alias = null ) {
            var builder = sqlQuery.GetBuilder();
            builder.LeftJoin( table, alias );
            return sqlQuery;
        }

        /// <summary>
        /// 左外连接
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        public static ISqlQuery LeftJoin<TEntity>( this ISqlQuery sqlQuery, string alias = null, string schema = null ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.LeftJoin<TEntity>( alias, schema );
            return sqlQuery;
        }

        /// <summary>
        /// 添加到左外连接子句
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        public static ISqlQuery AppendLeftJoin( this ISqlQuery sqlQuery, string sql ) {
            var builder = sqlQuery.GetBuilder();
            builder.AppendLeftJoin( sql );
            return sqlQuery;
        }

        /// <summary>
        /// 添加到左外连接子句
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="sqlBuilder">Sql生成器</param>
        /// <param name="alias">表别名</param>
        public static ISqlQuery AppendLeftJoin( this ISqlQuery sqlQuery, ISqlBuilder sqlBuilder, string alias ) {
            var builder = sqlQuery.GetBuilder();
            builder.AppendLeftJoin( sqlBuilder, alias );
            return sqlQuery;
        }

        /// <summary>
        /// 添加到左外连接子句
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="action">子查询操作</param>
        /// <param name="alias">表别名</param>
        public static ISqlQuery AppendLeftJoin( this ISqlQuery sqlQuery, Action<ISqlBuilder> action, string alias ) {
            var builder = sqlQuery.GetBuilder();
            builder.AppendLeftJoin( action, alias );
            return sqlQuery;
        }

        /// <summary>
        /// 添加到左外连接子句
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        /// <param name="condition">该值为true时添加Sql，否则忽略</param>
        public static ISqlQuery AppendLeftJoin( this ISqlQuery sqlQuery, string sql, bool condition ) {
            var builder = sqlQuery.GetBuilder();
            builder.AppendLeftJoin( sql, condition );
            return sqlQuery;
        }

        /// <summary>
        /// 右外连接
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        public static ISqlQuery RightJoin( this ISqlQuery sqlQuery, string table, string alias = null ) {
            var builder = sqlQuery.GetBuilder();
            builder.RightJoin( table, alias );
            return sqlQuery;
        }

        /// <summary>
        /// 右外连接
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        public static ISqlQuery RightJoin<TEntity>( this ISqlQuery sqlQuery, string alias = null, string schema = null ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.RightJoin<TEntity>( alias, schema );
            return sqlQuery;
        }

        /// <summary>
        /// 添加到右外连接子句
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        public static ISqlQuery AppendRightJoin( this ISqlQuery sqlQuery, string sql ) {
            var builder = sqlQuery.GetBuilder();
            builder.AppendRightJoin( sql );
            return sqlQuery;
        }

        /// <summary>
        /// 添加到右外连接子句
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="sqlBuilder">Sql生成器</param>
        /// <param name="alias">表别名</param>
        public static ISqlQuery AppendRightJoin( this ISqlQuery sqlQuery, ISqlBuilder sqlBuilder, string alias ) {
            var builder = sqlQuery.GetBuilder();
            builder.AppendRightJoin( sqlBuilder, alias );
            return sqlQuery;
        }

        /// <summary>
        /// 添加到右外连接子句
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="action">子查询操作</param>
        /// <param name="alias">表别名</param>
        public static ISqlQuery AppendRightJoin( this ISqlQuery sqlQuery, Action<ISqlBuilder> action, string alias ) {
            var builder = sqlQuery.GetBuilder();
            builder.AppendRightJoin( action, alias );
            return sqlQuery;
        }

        /// <summary>
        /// 添加到右外连接子句
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        /// <param name="condition">该值为true时添加Sql，否则忽略</param>
        public static ISqlQuery AppendRightJoin( this ISqlQuery sqlQuery, string sql, bool condition ) {
            var builder = sqlQuery.GetBuilder();
            builder.AppendRightJoin( sql, condition );
            return sqlQuery;
        }

        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="left">左表列名</param>
        /// <param name="right">右表列名</param>
        /// <param name="operator">条件运算符</param>
        public static ISqlQuery On( this ISqlQuery sqlQuery, string left, string right, Operator @operator = Operator.Equal ) {
            var builder = sqlQuery.GetBuilder();
            builder.On( left, right, @operator );
            return sqlQuery;
        }

        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="left">左表列名,范例：t => t.Name</param>
        /// <param name="right">右表列名,范例：t => t.Name</param>
        /// <param name="operator">条件运算符</param>
        public static ISqlQuery On<TLeft, TRight>( this ISqlQuery sqlQuery, Expression<Func<TLeft, object>> left, Expression<Func<TRight, object>> right,
            Operator @operator = Operator.Equal ) where TLeft : class where TRight : class {
            var builder = sqlQuery.GetBuilder();
            builder.On( left, right, @operator );
            return sqlQuery;
        }

        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="expression">条件表达式,范例：(l,r) => l.Id == r.OrderId</param>
        public static ISqlQuery On<TLeft, TRight>( this ISqlQuery sqlQuery, Expression<Func<TLeft, TRight, bool>> expression ) where TLeft : class where TRight : class {
            var builder = sqlQuery.GetBuilder();
            builder.On( expression );
            return sqlQuery;
        }

        #endregion

        #region Where子句

        /// <summary>
        /// And连接条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="condition">查询条件</param>
        public static ISqlQuery And( this ISqlQuery sqlQuery, ICondition condition ) {
            var builder = sqlQuery.GetBuilder();
            builder.And( condition );
            return sqlQuery;
        }

        /// <summary>
        /// Or连接条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="condition">查询条件</param>
        public static ISqlQuery Or( this ISqlQuery sqlQuery, ICondition condition ) {
            var builder = sqlQuery.GetBuilder();
            builder.Or( condition );
            return sqlQuery;
        }

        /// <summary>
        /// Or连接条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="conditions">查询条件</param>
        public static ISqlQuery Or<TEntity>( this ISqlQuery sqlQuery, params Expression<Func<TEntity, bool>>[] conditions ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.Or( conditions );
            return sqlQuery;
        }

        /// <summary>
        /// Or连接条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="conditions">查询条件,如果表达式中的值为空，则忽略该查询条件</param>
        public static ISqlQuery OrIfNotEmpty<TEntity>( this ISqlQuery sqlQuery, params Expression<Func<TEntity, bool>>[] conditions ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.OrIfNotEmpty( conditions );
            return sqlQuery;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="condition">查询条件</param>
        public static ISqlQuery Where( this ISqlQuery sqlQuery, ICondition condition ) {
            var builder = sqlQuery.GetBuilder();
            builder.Where( condition );
            return sqlQuery;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        public static ISqlQuery Where( this ISqlQuery sqlQuery, string column, object value, Operator @operator = Operator.Equal ) {
            var builder = sqlQuery.GetBuilder();
            builder.Where( column, value, @operator );
            return sqlQuery;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        public static ISqlQuery Where<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, object>> expression, object value, Operator @operator = Operator.Equal ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.Where( expression, value, @operator );
            return sqlQuery;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="expression">查询条件表达式,范例：t => t.Name.Contains("a") &amp;&amp; ( t.Code == "b" || t.Age > 1 )</param>
        public static ISqlQuery Where<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, bool>> expression ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.Where( expression );
            return sqlQuery;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        /// <param name="operator">运算符</param>
        public static ISqlQuery WhereIf( this ISqlQuery sqlQuery, string column, object value, bool condition, Operator @operator = Operator.Equal ) {
            var builder = sqlQuery.GetBuilder();
            builder.WhereIf( column, value, condition, @operator );
            return sqlQuery;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        /// <param name="operator">运算符</param>
        public static ISqlQuery WhereIf<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, object>> expression, object value,
            bool condition, Operator @operator = Operator.Equal ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.WhereIf( expression, value, condition, @operator );
            return sqlQuery;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="expression">查询条件表达式,范例：t => t.Name.Contains("a") &amp;&amp; ( t.Code == "b" || t.Age > 1 )</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        public static ISqlQuery WhereIf<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, bool>> expression, bool condition ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.WhereIf( expression, condition );
            return sqlQuery;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="column">列名</param>
        /// <param name="value">值,如果值为空，则忽略该查询条件</param>
        /// <param name="operator">运算符</param>
        public static ISqlQuery WhereIfNotEmpty( this ISqlQuery sqlQuery, string column, object value, Operator @operator = Operator.Equal ) {
            var builder = sqlQuery.GetBuilder();
            builder.WhereIfNotEmpty( column, value, @operator );
            return sqlQuery;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值,如果值为空，则忽略该查询条件</param>
        /// <param name="operator">运算符</param>
        public static ISqlQuery WhereIfNotEmpty<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, object>> expression,
            object value, Operator @operator = Operator.Equal ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.WhereIfNotEmpty( expression, value, @operator );
            return sqlQuery;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="expression">查询条件表达式,如果参数值为空，则忽略该查询条件</param>
        public static ISqlQuery WhereIfNotEmpty<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, bool>> expression ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.WhereIfNotEmpty( expression );
            return sqlQuery;
        }

        /// <summary>
        /// 设置相等查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        public static ISqlQuery Equal( this ISqlQuery sqlQuery, string column, object value ) {
            var builder = sqlQuery.GetBuilder();
            builder.Equal( column, value );
            return sqlQuery;
        }

        /// <summary>
        /// 设置相等查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        public static ISqlQuery Equal<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.Equal( expression, value );
            return sqlQuery;
        }

        /// <summary>
        /// 设置不相等查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        public static ISqlQuery NotEqual( this ISqlQuery sqlQuery, string column, object value ) {
            var builder = sqlQuery.GetBuilder();
            builder.NotEqual( column, value );
            return sqlQuery;
        }

        /// <summary>
        /// 设置不相等查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        public static ISqlQuery NotEqual<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.NotEqual( expression, value );
            return sqlQuery;
        }

        /// <summary>
        /// 设置大于查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        public static ISqlQuery Greater( this ISqlQuery sqlQuery, string column, object value ) {
            var builder = sqlQuery.GetBuilder();
            builder.Greater( column, value );
            return sqlQuery;
        }

        /// <summary>
        /// 设置大于查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        public static ISqlQuery Greater<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.Greater( expression, value );
            return sqlQuery;
        }

        /// <summary>
        /// 设置小于查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        public static ISqlQuery Less( this ISqlQuery sqlQuery, string column, object value ) {
            var builder = sqlQuery.GetBuilder();
            builder.Less( column, value );
            return sqlQuery;
        }

        /// <summary>
        /// 设置小于查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        public static ISqlQuery Less<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.Less( expression, value );
            return sqlQuery;
        }

        /// <summary>
        /// 设置大于等于查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        public static ISqlQuery GreaterEqual( this ISqlQuery sqlQuery, string column, object value ) {
            var builder = sqlQuery.GetBuilder();
            builder.GreaterEqual( column, value );
            return sqlQuery;
        }

        /// <summary>
        /// 设置大于等于查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        public static ISqlQuery GreaterEqual<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.GreaterEqual( expression, value );
            return sqlQuery;
        }

        /// <summary>
        /// 设置小于等于查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        public static ISqlQuery LessEqual( this ISqlQuery sqlQuery, string column, object value ) {
            var builder = sqlQuery.GetBuilder();
            builder.LessEqual( column, value );
            return sqlQuery;
        }

        /// <summary>
        /// 设置小于等于查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        public static ISqlQuery LessEqual<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.LessEqual( expression, value );
            return sqlQuery;
        }

        /// <summary>
        /// 设置模糊匹配查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        public static ISqlQuery Contains( this ISqlQuery sqlQuery, string column, object value ) {
            var builder = sqlQuery.GetBuilder();
            builder.Contains( column, value );
            return sqlQuery;
        }

        /// <summary>
        /// 设置模糊匹配查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        public static ISqlQuery Contains<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.Contains( expression, value );
            return sqlQuery;
        }

        /// <summary>
        /// 设置头匹配查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        public static ISqlQuery Starts( this ISqlQuery sqlQuery, string column, object value ) {
            var builder = sqlQuery.GetBuilder();
            builder.Starts( column, value );
            return sqlQuery;
        }

        /// <summary>
        /// 设置头匹配查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        public static ISqlQuery Starts<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.Starts( expression, value );
            return sqlQuery;
        }

        /// <summary>
        /// 设置尾匹配查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        public static ISqlQuery Ends( this ISqlQuery sqlQuery, string column, object value ) {
            var builder = sqlQuery.GetBuilder();
            builder.Ends( column, value );
            return sqlQuery;
        }

        /// <summary>
        /// 设置尾匹配查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        public static ISqlQuery Ends<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.Ends( expression, value );
            return sqlQuery;
        }

        /// <summary>
        /// 设置Is Null查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="column">列名</param>
        public static ISqlQuery IsNull( this ISqlQuery sqlQuery, string column ) {
            var builder = sqlQuery.GetBuilder();
            builder.IsNull( column );
            return sqlQuery;
        }

        /// <summary>
        /// 设置Is Null查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        public static ISqlQuery IsNull<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, object>> expression ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.IsNull( expression );
            return sqlQuery;
        }

        /// <summary>
        /// 设置Is Not Null查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="column">列名</param>
        public static ISqlQuery IsNotNull( this ISqlQuery sqlQuery, string column ) {
            var builder = sqlQuery.GetBuilder();
            builder.IsNotNull( column );
            return sqlQuery;
        }

        /// <summary>
        /// 设置Is Not Null查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        public static ISqlQuery IsNotNull<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, object>> expression ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.IsNotNull( expression );
            return sqlQuery;
        }

        /// <summary>
        /// 设置空条件，范例：[Name] Is Null Or [Name]=''
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="column">列名</param>
        public static ISqlQuery IsEmpty( this ISqlQuery sqlQuery, string column ) {
            var builder = sqlQuery.GetBuilder();
            builder.IsEmpty( column );
            return sqlQuery;
        }

        /// <summary>
        /// 设置空条件，范例：[Name] Is Null Or [Name]=''
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        public static ISqlQuery IsEmpty<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, object>> expression ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.IsEmpty( expression );
            return sqlQuery;
        }

        /// <summary>
        /// 设置非空条件，范例：[Name] Is Not Null And [Name]&lt;&gt;''
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="column">列名</param>
        public static ISqlQuery IsNotEmpty( this ISqlQuery sqlQuery, string column ) {
            var builder = sqlQuery.GetBuilder();
            builder.IsNotEmpty( column );
            return sqlQuery;
        }

        /// <summary>
        /// 设置非空条件，范例：[Name] Is Not Null And [Name]&lt;&gt;''
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        public static ISqlQuery IsNotEmpty<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, object>> expression ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.IsNotEmpty( expression );
            return sqlQuery;
        }

        /// <summary>
        /// 设置In条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="column">列名</param>
        /// <param name="values">值集合</param>
        public static ISqlQuery In( this ISqlQuery sqlQuery, string column, IEnumerable<object> values ) {
            var builder = sqlQuery.GetBuilder();
            builder.In( column, values );
            return sqlQuery;
        }

        /// <summary>
        /// 设置In条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="values">值集合</param>
        public static ISqlQuery In<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, object>> expression, IEnumerable<object> values ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.In( expression, values );
            return sqlQuery;
        }

        /// <summary>
        /// 设置Not In条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="column">列名</param>
        /// <param name="values">值集合</param>
        public static ISqlQuery NotIn( this ISqlQuery sqlQuery, string column, IEnumerable<object> values ) {
            var builder = sqlQuery.GetBuilder();
            builder.NotIn( column, values );
            return sqlQuery;
        }

        /// <summary>
        /// 设置Not In条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="values">值集合</param>
        public static ISqlQuery NotIn<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, object>> expression, IEnumerable<object> values ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.NotIn( expression, values );
            return sqlQuery;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public static ISqlQuery Between<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, object>> expression, int? min, int? max,
            Boundary boundary = Boundary.Both ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.Between( expression, min, max, boundary );
            return sqlQuery;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public static ISqlQuery Between<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, object>> expression, double? min, double? max,
            Boundary boundary = Boundary.Both ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.Between( expression, min, max, boundary );
            return sqlQuery;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public static ISqlQuery Between<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, object>> expression, decimal? min, decimal? max,
            Boundary boundary = Boundary.Both ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.Between( expression, min, max, boundary );
            return sqlQuery;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="includeTime">是否包含时间</param>
        /// <param name="boundary">包含边界</param>
        public static ISqlQuery Between<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, object>> expression, DateTime? min, DateTime? max, bool includeTime = true, Boundary? boundary = null ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.Between( expression, min, max, includeTime, boundary );
            return sqlQuery;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="column">列名</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public static ISqlQuery Between( this ISqlQuery sqlQuery, string column, int? min, int? max, Boundary boundary = Boundary.Both ) {
            var builder = sqlQuery.GetBuilder();
            builder.Between( column, min, max, boundary );
            return sqlQuery;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="column">列名</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public static ISqlQuery Between( this ISqlQuery sqlQuery, string column, double? min, double? max, Boundary boundary = Boundary.Both ) {
            var builder = sqlQuery.GetBuilder();
            builder.Between( column, min, max, boundary );
            return sqlQuery;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="column">列名</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public static ISqlQuery Between( this ISqlQuery sqlQuery, string column, decimal? min, decimal? max, Boundary boundary = Boundary.Both ) {
            var builder = sqlQuery.GetBuilder();
            builder.Between( column, min, max, boundary );
            return sqlQuery;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="column">列名</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="includeTime">是否包含时间</param>
        /// <param name="boundary">包含边界</param>
        public static ISqlQuery Between( this ISqlQuery sqlQuery, string column, DateTime? min, DateTime? max, bool includeTime = true, Boundary? boundary = null ) {
            var builder = sqlQuery.GetBuilder();
            builder.Between( column, min, max, includeTime, boundary );
            return sqlQuery;
        }

        /// <summary>
        /// 添加到Where子句
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        public static ISqlQuery AppendWhere( this ISqlQuery sqlQuery, string sql ) {
            var builder = sqlQuery.GetBuilder();
            builder.AppendWhere( sql );
            return sqlQuery;
        }

        /// <summary>
        /// 添加到Where子句
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        /// <param name="condition">该值为true时添加Sql，否则忽略</param>
        public static ISqlQuery AppendWhere( this ISqlQuery sqlQuery, string sql, bool condition ) {
            var builder = sqlQuery.GetBuilder();
            builder.AppendWhere( sql, condition );
            return sqlQuery;
        }

        #endregion

        #region GroupBy子句

        /// <summary>
        /// 分组
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="columns">分组字段,范例：a.Id,b.Name</param>
        /// <param name="having">分组条件,范例：Count(*) > 1</param>
        public static ISqlQuery GroupBy( this ISqlQuery sqlQuery, string columns, string having = null ) {
            var builder = sqlQuery.GetBuilder();
            builder.GroupBy( columns, having );
            return sqlQuery;
        }

        /// <summary>
        /// 分组
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="columns">分组字段</param>
        public static ISqlQuery GroupBy<TEntity>( this ISqlQuery sqlQuery, params Expression<Func<TEntity, object>>[] columns ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.GroupBy( columns );
            return sqlQuery;
        }

        /// <summary>
        /// 分组
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="column">分组字段,范例：t => t.Name</param>
        /// <param name="having">分组条件,范例：Count(*) > 1</param>
        public static ISqlQuery GroupBy<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, object>> column, string having = null ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.GroupBy( column, having );
            return sqlQuery;
        }

        /// <summary>
        /// 添加到GroupBy子句
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        public static ISqlQuery AppendGroupBy( this ISqlQuery sqlQuery, string sql ) {
            var builder = sqlQuery.GetBuilder();
            builder.AppendGroupBy( sql );
            return sqlQuery;
        }

        /// <summary>
        /// 添加到GroupBy子句
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        /// <param name="condition">该值为true时添加Sql，否则忽略</param>
        public static ISqlQuery AppendGroupBy( this ISqlQuery sqlQuery, string sql, bool condition ) {
            var builder = sqlQuery.GetBuilder();
            builder.AppendGroupBy( sql, condition );
            return sqlQuery;
        }

        #endregion

        #region OrderBy子句

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="order">排序列表,范例：a.Id,b.Name desc</param>
        /// <param name="tableAlias">表别名</param>
        public static ISqlQuery OrderBy( this ISqlQuery sqlQuery, string order, string tableAlias = null ) {
            var builder = sqlQuery.GetBuilder();
            builder.OrderBy( order, tableAlias );
            return sqlQuery;
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="column">排序列,范例：t => t.Name</param>
        /// <param name="desc">是否倒排</param>
        public static ISqlQuery OrderBy<TEntity>( this ISqlQuery sqlQuery, Expression<Func<TEntity, object>> column, bool desc = false ) where TEntity : class {
            var builder = sqlQuery.GetBuilder();
            builder.OrderBy( column, desc );
            return sqlQuery;
        }

        /// <summary>
        /// 添加到OrderBy子句
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        public static ISqlQuery AppendOrderBy( this ISqlQuery sqlQuery, string sql ) {
            var builder = sqlQuery.GetBuilder();
            builder.AppendOrderBy( sql );
            return sqlQuery;
        }

        /// <summary>
        /// 添加到OrderBy子句
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="sql">Sql语句，说明：原样添加到Sql中，不会进行任何处理</param>
        /// <param name="condition">该值为true时添加Sql，否则忽略</param>
        public static ISqlQuery AppendOrderBy( this ISqlQuery sqlQuery, string sql, bool condition ) {
            var builder = sqlQuery.GetBuilder();
            builder.AppendOrderBy( sql, condition );
            return sqlQuery;
        }

        #endregion
    }
}
