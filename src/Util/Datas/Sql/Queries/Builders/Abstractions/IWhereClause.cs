using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Util.Datas.Queries;
using Util.Datas.Sql.Queries.Builders.Conditions;

namespace Util.Datas.Sql.Queries.Builders.Abstractions {
    /// <summary>
    /// Where子句
    /// </summary>
    public interface IWhereClause : ICondition {
        /// <summary>
        /// And连接条件
        /// </summary>
        /// <param name="condition">查询条件</param>
        void And( ICondition condition );
        /// <summary>
        /// Or连接条件
        /// </summary>
        /// <param name="condition">查询条件</param>
        void Or( ICondition condition );
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        void Where( string column, object value, Operator @operator = Operator.Equal );
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        void Where<TEntity>( Expression<Func<TEntity, object>> expression, object value, Operator @operator = Operator.Equal ) where TEntity : class;
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">查询条件表达式</param>
        void Where<TEntity>( Expression<Func<TEntity, bool>> expression ) where TEntity : class;
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        /// <param name="operator">运算符</param>
        void WhereIf( string column, object value, bool condition, Operator @operator = Operator.Equal );
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        /// <param name="operator">运算符</param>
        void WhereIf<TEntity>( Expression<Func<TEntity, object>> expression, object value, bool condition, Operator @operator = Operator.Equal ) where TEntity : class;
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">查询条件表达式</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        void WhereIf<TEntity>( Expression<Func<TEntity, bool>> expression, bool condition ) where TEntity : class;
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值,如果值为空，则忽略该查询条件</param>
        /// <param name="operator">运算符</param>
        void WhereIfNotEmpty( string column, object value, Operator @operator = Operator.Equal );
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值,如果值为空，则忽略该查询条件</param>
        /// <param name="operator">运算符</param>
        void WhereIfNotEmpty<TEntity>( Expression<Func<TEntity, object>> expression, object value, Operator @operator = Operator.Equal ) where TEntity : class;
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">查询条件表达式,如果参数值为空，则忽略该查询条件</param>
        void WhereIfNotEmpty<TEntity>( Expression<Func<TEntity, bool>> expression ) where TEntity : class;
        /// <summary>
        /// 添加到Where子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        void AppendSql( string sql );
        /// <summary>
        /// 设置Is Null条件
        /// </summary>
        /// <param name="column">列名</param>
        void IsNull( string column );
        /// <summary>
        /// 设置Is Null条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        void IsNull<TEntity>( Expression<Func<TEntity, object>> expression ) where TEntity : class;
        /// <summary>
        /// 设置Is Not Null条件
        /// </summary>
        /// <param name="column">列名</param>
        void IsNotNull( string column );
        /// <summary>
        /// 设置Is Not Null条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        void IsNotNull<TEntity>( Expression<Func<TEntity, object>> expression ) where TEntity : class;
        /// <summary>
        /// 设置空条件
        /// </summary>
        /// <param name="column">列名</param>
        void IsEmpty( string column );
        /// <summary>
        /// 设置空条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        void IsEmpty<TEntity>( Expression<Func<TEntity, object>> expression ) where TEntity : class;
        /// <summary>
        /// 设置非空条件
        /// </summary>
        /// <param name="column">列名</param>
        void IsNotEmpty( string column );
        /// <summary>
        /// 设置非空条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        void IsNotEmpty<TEntity>( Expression<Func<TEntity, object>> expression ) where TEntity : class;
        /// <summary>
        /// 设置In条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="values">值集合</param>
        void In( string column, IEnumerable<object> values );
        /// <summary>
        /// 设置In条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="values">值集合</param>
        void In<TEntity>( Expression<Func<TEntity, object>> expression, IEnumerable<object> values ) where TEntity : class;
        /// <summary>
        /// 输出Sql
        /// </summary>
        string ToSql();
    }
}
