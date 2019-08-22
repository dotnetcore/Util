using System;
using System.Linq.Expressions;

namespace Util.Datas.Sql.Builders {
    /// <summary>
    /// Select子句
    /// </summary>
    public interface ISelectClause {
        /// <summary>
        /// 复制Select子句
        /// </summary>
        /// <param name="sqlBuilder">Sql生成器</param>
        /// <param name="register">实体别名注册器</param>
        ISelectClause Clone( ISqlBuilder sqlBuilder, IEntityAliasRegister register );
        /// <summary>
        /// 过滤重复记录
        /// </summary>
        void Distinct();
        /// <summary>
        /// 求总行数
        /// </summary>
        /// <param name="columnAlias">列别名</param>
        void Count( string columnAlias = null );
        /// <summary>
        /// 求总行数
        /// </summary>
        /// <param name="column">列</param>
        /// <param name="columnAlias">列别名</param>
        void Count( string column, string columnAlias );
        /// <summary>
        /// 求总行数
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="columnAlias">列别名</param>
        void Count<TEntity>( Expression<Func<TEntity, object>> expression, string columnAlias = null ) where TEntity : class;
        /// <summary>
        /// 求和
        /// </summary>
        /// <param name="column">列</param>
        /// <param name="columnAlias">列别名</param>
        void Sum( string column, string columnAlias = null );
        /// <summary>
        /// 求和
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="columnAlias">列别名</param>
        void Sum<TEntity>( Expression<Func<TEntity, object>> expression, string columnAlias = null ) where TEntity : class;
        /// <summary>
        /// 求平均值
        /// </summary>
        /// <param name="column">列</param>
        /// <param name="columnAlias">列别名</param>
        void Avg( string column, string columnAlias = null );
        /// <summary>
        /// 求平均值
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="columnAlias">列别名</param>
        void Avg<TEntity>( Expression<Func<TEntity, object>> expression, string columnAlias = null ) where TEntity : class;
        /// <summary>
        /// 求最大值
        /// </summary>
        /// <param name="column">列</param>
        /// <param name="columnAlias">列别名</param>
        void Max( string column, string columnAlias = null );
        /// <summary>
        /// 求最大值
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="columnAlias">列别名</param>
        void Max<TEntity>( Expression<Func<TEntity, object>> expression, string columnAlias = null ) where TEntity : class;
        /// <summary>
        /// 求最小值
        /// </summary>
        /// <param name="column">列</param>
        /// <param name="columnAlias">列别名</param>
        void Min( string column, string columnAlias = null );
        /// <summary>
        /// 求最小值
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="columnAlias">列别名</param>
        void Min<TEntity>( Expression<Func<TEntity, object>> expression, string columnAlias = null ) where TEntity : class;
        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="columns">列名</param>
        /// <param name="tableAlias">表别名</param>
        void Select( string columns, string tableAlias = null );
        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="propertyAsAlias">是否将属性名映射为列别名</param>
        void Select<TEntity>( bool propertyAsAlias = false );
        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="columns">列名</param>
        /// <param name="propertyAsAlias">是否将属性名映射为列别名</param>
        void Select<TEntity>( Expression<Func<TEntity, object[]>> columns, bool propertyAsAlias = false ) where TEntity : class;
        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="columnAlias">列别名</param>
        void Select<TEntity>( Expression<Func<TEntity, object>> column, string columnAlias = null ) where TEntity : class;
        /// <summary>
        /// 设置子查询列
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="columnAlias">列别名</param>
        void Select( ISqlBuilder builder, string columnAlias );
        /// <summary>
        /// 设置子查询列
        /// </summary>
        /// <param name="action">子查询操作</param>
        /// <param name="columnAlias">列别名</param>
        void Select( Action<ISqlBuilder> action, string columnAlias );
        /// <summary>
        /// 添加到Select子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="columnAlias">列别名</param>
        void AppendSql( string sql, string columnAlias = null );
        /// <summary>
        /// 移除列名
        /// </summary>
        /// <param name="columns">列名</param>
        /// <param name="tableAlias">表别名</param>
        void RemoveSelect( string columns, string tableAlias = null );
        /// <summary>
        /// 移除列名
        /// </summary>
        /// <param name="expression">列名表达式</param>
        void RemoveSelect<TEntity>( Expression<Func<TEntity, object[]>> expression ) where TEntity : class;
        /// <summary>
        /// 移除列名
        /// </summary>
        /// <param name="expression">列名表达式</param>
        void RemoveSelect<TEntity>( Expression<Func<TEntity, object>> expression ) where TEntity : class;
        /// <summary>
        /// 输出Sql
        /// </summary>
        string ToSql();
    }
}
