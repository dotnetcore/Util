using System;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Util.Datas.Queries;
using Util.Datas.Sql.Queries.Builders;
using Util.Datas.Sql.Queries.Builders.Conditions;

namespace Util.Datas.Sql.Queries {
    /// <summary>
    /// Sql查询对象
    /// </summary>
    public interface ISqlQuery {
        /// <summary>
        /// 创建Sql生成器
        /// </summary>
        ISqlBuilder NewBuilder();
        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <typeparam name="TResult">实体类型</typeparam>
        /// <param name="connection">数据库连接</param>
        TResult To<TResult>( IDbConnection connection = null );
        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <typeparam name="TResult">实体类型</typeparam>
        /// <param name="connection">数据库连接</param>
        Task<TResult> ToAsync<TResult>( IDbConnection connection = null );
        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="columns">列名</param>
        /// <param name="alias">别名</param>
        ISqlQuery Select( string columns, string alias = null );
        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="columns">列名，范例：t => new object[] { t.A, t.B }</param>
        /// <param name="alias">别名</param>
        ISqlQuery Select<TEntity>( Expression<Func<TEntity, object[]>> columns, string alias = null ) where TEntity : class;
        /// <summary>
        /// 设置表名
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        ISqlQuery From( string table, string alias );
        /// <summary>
        /// 设置表名
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        ISqlQuery From<TEntity>( string alias, string schema = null ) where TEntity : class;
        /// <summary>
        /// And连接条件
        /// </summary>
        /// <param name="condition">查询条件</param>
        ISqlQuery And( ICondition condition );
        /// <summary>
        /// Or连接条件
        /// </summary>
        /// <param name="condition">查询条件</param>
        ISqlQuery Or( ICondition condition );
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">查询条件表达式</param>
        /// <param name="tableAlias">表别名</param>
        ISqlQuery Where<TEntity>( Expression<Func<TEntity, bool>> expression, string tableAlias = null ) where TEntity : class;
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        /// <param name="tableAlias">表别名</param>
        ISqlQuery Where<TEntity>( Expression<Func<TEntity, object>> expression, object value, Operator @operator = Operator.Equal, string tableAlias = null ) where TEntity : class;
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        /// <param name="tableAlias">表别名</param>
        ISqlQuery Where( string column, object value, Operator @operator = Operator.Equal, string tableAlias = null );
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">查询条件表达式</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        /// <param name="tableAlias">表别名</param>
        ISqlQuery WhereIf<TEntity>( Expression<Func<TEntity, bool>> expression, bool condition, string tableAlias = null ) where TEntity : class;
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        /// <param name="operator">运算符</param>
        /// <param name="tableAlias">表别名</param>
        ISqlQuery WhereIf<TEntity>( Expression<Func<TEntity, object>> expression, object value, bool condition, Operator @operator = Operator.Equal, string tableAlias = null ) where TEntity : class;
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        /// <param name="operator">运算符</param>
        /// <param name="tableAlias">表别名</param>
        ISqlQuery WhereIf( string column, object value, bool condition, Operator @operator = Operator.Equal, string tableAlias = null );
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">查询条件表达式,如果参数值为空，则忽略该查询条件</param>
        /// <param name="tableAlias">表别名</param>
        ISqlQuery WhereIfNotEmpty<TEntity>( Expression<Func<TEntity, bool>> expression, string tableAlias = null ) where TEntity : class;
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值,如果值为空，则忽略该查询条件</param>
        /// <param name="operator">运算符</param>
        /// <param name="tableAlias">表别名</param>
        ISqlQuery WhereIfNotEmpty<TEntity>( Expression<Func<TEntity, object>> expression, object value, Operator @operator = Operator.Equal, string tableAlias = null ) where TEntity : class;
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值,如果值为空，则忽略该查询条件</param>
        /// <param name="operator">运算符</param>
        /// <param name="tableAlias">表别名</param>
        ISqlQuery WhereIfNotEmpty( string column, object value, Operator @operator = Operator.Equal, string tableAlias = null );
    }
}
