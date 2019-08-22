using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Util.Datas.Queries;
using Util.Datas.Sql.Builders;

namespace Util.Datas.Sql {
    /// <summary>
    /// Sql生成器扩展
    /// </summary>
    public static partial class Extensions {

        #region Select子句

        /// <summary>
        /// 求总行数
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式</param>
        /// <param name="columnAlias">列别名</param>
        public static ISqlBuilder Count<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression, string columnAlias = null ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.SelectClause.Count( expression, columnAlias );
            return source;
        }

        /// <summary>
        /// 求和
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式</param>
        /// <param name="columnAlias">列别名</param>
        public static ISqlBuilder Sum<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression, string columnAlias = null ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.SelectClause.Sum( expression, columnAlias );
            return source;
        }

        /// <summary>
        /// 求平均值
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式</param>
        /// <param name="columnAlias">列别名</param>
        public static ISqlBuilder Avg<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression, string columnAlias = null ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.SelectClause.Avg( expression, columnAlias );
            return source;
        }

        /// <summary>
        /// 求最大值
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式</param>
        /// <param name="columnAlias">列别名</param>
        public static ISqlBuilder Max<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression, string columnAlias = null ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.SelectClause.Max( expression, columnAlias );
            return source;
        }

        /// <summary>
        /// 求最小值
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式</param>
        /// <param name="columnAlias">列别名</param>
        public static ISqlBuilder Min<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression, string columnAlias = null ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.SelectClause.Min( expression, columnAlias );
            return source;
        }

        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="propertyAsAlias">是否将属性名映射为列别名</param>
        public static ISqlBuilder Select<TEntity>( this ISqlBuilder source, bool propertyAsAlias = false ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.SelectClause.Select<TEntity>( propertyAsAlias );
            return source;
        }

        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="columns">列名,范例：t => new object[] { t.Id, t.Name }</param>
        /// <param name="propertyAsAlias">是否将属性名映射为列别名</param>
        public static ISqlBuilder Select<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object[]>> columns, bool propertyAsAlias = false ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.SelectClause.Select( columns, propertyAsAlias );
            return source;
        }

        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="column">列名,范例：t => t.Name，支持字典批量设置列和列别名，
        /// 范例：Select&lt;Sample&gt;( t => new Dictionary&lt;object, string&gt; { { t.Email, "e" }, { t.Url, "u" } } );</param>
        /// <param name="columnAlias">列别名</param>
        public static ISqlBuilder Select<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> column, string columnAlias = null ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.SelectClause.Select( column, columnAlias );
            return source;
        }

        /// <summary>
        /// 移除列名
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="columns">列名,范例：t => new object[] { t.Id, t.Name }</param>
        public static ISqlBuilder RemoveSelect<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object[]>> columns ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.SelectClause.RemoveSelect( columns );
            return source;
        }

        /// <summary>
        /// 移除列名
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="column">列名,范例：t => t.Name，支持字典批量设置列和列别名</param>
        public static ISqlBuilder RemoveSelect<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> column ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.SelectClause.RemoveSelect( column );
            return source;
        }

        #endregion

        #region From子句

        /// <summary>
        /// 设置表名
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        public static ISqlBuilder From<TEntity>( this ISqlBuilder source, string alias = null, string schema = null ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.FromClause.From<TEntity>( alias, schema );
            return source;
        }

        #endregion

        #region Join子句

        /// <summary>
        /// 内连接
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        public static ISqlBuilder Join<TEntity>( this ISqlBuilder source, string alias = null, string schema = null ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.JoinClause.Join<TEntity>( alias, schema );
            return source;
        }

        /// <summary>
        /// 左外连接
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        public static ISqlBuilder LeftJoin<TEntity>( this ISqlBuilder source, string alias = null, string schema = null ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.JoinClause.LeftJoin<TEntity>( alias, schema );
            return source;
        }

        /// <summary>
        /// 右外连接
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        public static ISqlBuilder RightJoin<TEntity>( this ISqlBuilder source, string alias = null, string schema = null ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.JoinClause.RightJoin<TEntity>( alias, schema );
            return source;
        }

        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="left">左表列名,范例：t => t.Name</param>
        /// <param name="right">右表列名,范例：t => t.Name</param>
        /// <param name="operator">条件运算符</param>
        public static ISqlBuilder On<TLeft, TRight>( this ISqlBuilder source, Expression<Func<TLeft, object>> left, Expression<Func<TRight, object>> right,
            Operator @operator = Operator.Equal ) where TLeft : class where TRight : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.JoinClause.On( left, right, @operator );
            return source;
        }

        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">条件表达式,范例：(l,r) => l.Id == r.OrderId</param>
        public static ISqlBuilder On<TLeft, TRight>( this ISqlBuilder source, Expression<Func<TLeft, TRight, bool>> expression ) where TLeft : class where TRight : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.JoinClause.On( expression );
            return source;
        }

        #endregion

        #region Where子句

        /// <summary>
        /// Or连接条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="conditions">查询条件</param>
        public static ISqlBuilder Or<TEntity>( this ISqlBuilder source, params Expression<Func<TEntity, bool>>[] conditions ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.WhereClause.Or( conditions );
            return source;
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
            return condition ? builder.Or( predicates ) : builder;
        }

        /// <summary>
        /// Or连接条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="conditions">查询条件,如果表达式中的值为空，则忽略该查询条件</param>
        public static ISqlBuilder OrIfNotEmpty<TEntity>( this ISqlBuilder source, params Expression<Func<TEntity, bool>>[] conditions ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.WhereClause.OrIfNotEmpty( conditions );
            return source;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        public static ISqlBuilder Where<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression,
            object value, Operator @operator = Operator.Equal ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.WhereClause.Where( expression, value, @operator );
            return source;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">查询条件表达式,范例：t => t.Name.Contains("a") &amp;&amp; ( t.Code == "b" || t.Age > 1 )</param>
        public static ISqlBuilder Where<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, bool>> expression ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.WhereClause.Where( expression );
            return source;
        }

        /// <summary>
        /// 设置子查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式</param>
        /// <param name="builder">子查询Sql生成器</param>
        /// <param name="operator">运算符</param>
        public static ISqlBuilder Where<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression, ISqlBuilder builder,
            Operator @operator = Operator.Equal ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.WhereClause.Where( expression, builder, @operator );
            return source;
        }

        /// <summary>
        /// 设置子查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式</param>
        /// <param name="action">子查询操作</param>
        /// <param name="operator">运算符</param>
        public static ISqlBuilder Where<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression,
            Action<ISqlBuilder> action, Operator @operator = Operator.Equal ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.WhereClause.Where( expression, action, @operator );
            return source;
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
            return condition ? builder.Where( expression, value, @operator ) : builder;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="expression">查询条件表达式,范例：t => t.Name.Contains("a") &amp;&amp; ( t.Code == "b" || t.Age > 1 )</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        public static ISqlBuilder WhereIf<TEntity>( this ISqlBuilder builder, Expression<Func<TEntity, bool>> expression, bool condition ) where TEntity : class {
            return condition ? builder.Where( expression ) : builder;
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
            return condition ? builder.Where( expression, subBuilder, @operator ) : builder;
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
            return condition ? builder.Where( expression, action, @operator ) : builder;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值,如果值为空，则忽略该查询条件</param>
        /// <param name="operator">运算符</param>
        public static ISqlBuilder WhereIfNotEmpty<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression, object value, Operator @operator = Operator.Equal ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.WhereClause.WhereIfNotEmpty( expression, value, @operator );
            return source;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">查询条件表达式,如果参数值为空，则忽略该查询条件</param>
        public static ISqlBuilder WhereIfNotEmpty<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, bool>> expression ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.WhereClause.WhereIfNotEmpty( expression );
            return source;
        }

        /// <summary>
        /// 设置相等查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        public static ISqlBuilder Equal<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            return source.Where( expression, value );
        }

        /// <summary>
        /// 设置不相等查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        public static ISqlBuilder NotEqual<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            return source.Where( expression, value, Operator.NotEqual );
        }

        /// <summary>
        /// 设置大于查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        public static ISqlBuilder Greater<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            return source.Where( expression, value, Operator.Greater );
        }

        /// <summary>
        /// 设置小于查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        public static ISqlBuilder Less<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            return source.Where( expression, value, Operator.Less );
        }

        /// <summary>
        /// 设置大于等于查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        public static ISqlBuilder GreaterEqual<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            return source.Where( expression, value, Operator.GreaterEqual );
        }

        /// <summary>
        /// 设置小于等于查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        public static ISqlBuilder LessEqual<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            return source.Where( expression, value, Operator.LessEqual );
        }

        /// <summary>
        /// 设置模糊匹配查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        public static ISqlBuilder Contains<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            return source.Where( expression, value, Operator.Contains );
        }

        /// <summary>
        /// 设置头匹配查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        public static ISqlBuilder Starts<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            return source.Where( expression, value, Operator.Starts );
        }

        /// <summary>
        /// 设置尾匹配查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="value">值</param>
        public static ISqlBuilder Ends<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            return source.Where( expression, value, Operator.Ends );
        }

        /// <summary>
        /// 设置Is Null查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        public static ISqlBuilder IsNull<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.WhereClause.IsNull( expression );
            return source;
        }

        /// <summary>
        /// 设置Is Not Null查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        public static ISqlBuilder IsNotNull<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.WhereClause.IsNotNull( expression );
            return source;
        }

        /// <summary>
        /// 设置空条件，范例：[Name] Is Null Or [Name]=''
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        public static ISqlBuilder IsEmpty<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.WhereClause.IsEmpty( expression );
            return source;
        }

        /// <summary>
        /// 设置非空条件，范例：[Name] Is Not Null And [Name]&lt;&gt;''
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        public static ISqlBuilder IsNotEmpty<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.WhereClause.IsNotEmpty( expression );
            return source;
        }

        /// <summary>
        /// 设置In条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="values">值集合</param>
        public static ISqlBuilder In<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression, IEnumerable<object> values ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.WhereClause.In( expression, values );
            return source;
        }

        /// <summary>
        /// 设置In条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式</param>
        /// <param name="builder">Sql生成器</param>
        public static ISqlBuilder In<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression, ISqlBuilder builder ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.WhereClause.In( expression, builder );
            return source;
        }

        /// <summary>
        /// 设置In条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式</param>
        /// <param name="action">子查询操作</param>
        public static ISqlBuilder In<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression, Action<ISqlBuilder> action ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.WhereClause.In( expression, action );
            return source;
        }

        /// <summary>
        /// 设置Not In条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="values">值集合</param>
        public static ISqlBuilder NotIn<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression, IEnumerable<object> values ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.WhereClause.NotIn( expression, values );
            return source;
        }

        /// <summary>
        /// 设置Not In条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式</param>
        /// <param name="builder">Sql生成器</param>
        public static ISqlBuilder NotIn<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression, ISqlBuilder builder ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.WhereClause.NotIn( expression, builder );
            return source;
        }

        /// <summary>
        /// 设置Not In条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式</param>
        /// <param name="action">子查询操作</param>
        public static ISqlBuilder NotIn<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression, Action<ISqlBuilder> action ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.WhereClause.NotIn( expression, action );
            return source;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public static ISqlBuilder Between<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression, int? min, int? max, Boundary boundary = Boundary.Both ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.WhereClause.Between( expression, min, max, boundary );
            return source;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public static ISqlBuilder Between<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression, double? min, double? max, Boundary boundary = Boundary.Both ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.WhereClause.Between( expression, min, max, boundary );
            return source;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public static ISqlBuilder Between<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression, decimal? min, decimal? max, Boundary boundary = Boundary.Both ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.WhereClause.Between( expression, min, max, boundary );
            return source;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="expression">列名表达式,范例：t => t.Name</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="includeTime">是否包含时间</param>
        /// <param name="boundary">包含边界</param>
        public static ISqlBuilder Between<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> expression, DateTime? min, DateTime? max,
            bool includeTime = true, Boundary? boundary = null ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.WhereClause.Between( expression, min, max, includeTime, boundary );
            return source;
        }

        #endregion

        #region GroupBy子句

        /// <summary>
        /// 分组
        /// </summary>
        /// <param name="source">源</param>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="column">分组字段,范例：t => t.Name</param>
        /// <param name="having">分组条件,范例：Count(*) > 1</param>
        public static ISqlBuilder GroupBy<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> column, string having = null ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.GroupByClause.GroupBy( column, having );
            return source;
        }

        /// <summary>
        /// 分组
        /// </summary>
        /// <param name="source">源</param>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="columns">分组字段</param>
        public static ISqlBuilder GroupBy<TEntity>( this ISqlBuilder source, params Expression<Func<TEntity, object>>[] columns ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.GroupByClause.GroupBy( columns );
            return source;
        }

        #endregion

        #region OrderBy子句

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="source">源</param>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="column">排序列,范例：t => t.Name</param>
        /// <param name="desc">是否倒排</param>
        public static ISqlBuilder OrderBy<TEntity>( this ISqlBuilder source, Expression<Func<TEntity, object>> column, bool desc = false ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( source is IClauseAccessor accessor )
                accessor.OrderByClause.OrderBy( column, desc );
            return source;
        }

        #endregion
    }
}