using System;
using System.Linq.Expressions;
using Util.Domains.Repositories;

namespace Util.Datas.Queries {
    /// <summary>
    /// 查询对象
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public interface IQuery<TEntity> : IQuery<TEntity, Guid> where TEntity : class {
    }

    /// <summary>
    /// 查询对象
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public interface IQuery<TEntity, TKey> : IQueryBase<TEntity> where TEntity : class {
        /// <summary>
        /// 添加查询条件
        /// </summary>
        /// <param name="predicate">查询条件</param>
        IQuery<TEntity, TKey> Where( Expression<Func<TEntity, bool>> predicate );
        /// <summary>
        /// 添加查询条件
        /// </summary>
        /// <param name="criteria">查询条件</param>
        IQuery<TEntity, TKey> Where( ICriteria<TEntity> criteria );
        /// <summary>
        /// 添加查询条件
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        IQuery<TEntity, TKey> WhereIf( Expression<Func<TEntity, bool>> predicate, bool condition );
        /// <summary>
        /// 添加查询条件
        /// </summary>
        /// <param name="predicate">查询条件,如果参数值为空，则忽略该查询条件，范例：t => t.Name == ""，该查询条件被忽略。
        /// 注意：一次仅能添加一个条件，范例：t => t.Name == "a" &amp;&amp; t.Mobile == "123"，不支持，将抛出异常</param>
        IQuery<TEntity, TKey> WhereIfNotEmpty( Expression<Func<TEntity, bool>> predicate );
        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="propertyExpression">属性表达式，范例：t => t.Age</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        IQuery<TEntity, TKey> Between<TProperty>( Expression<Func<TEntity, TProperty>> propertyExpression, int? min, int? max, Boundary boundary = Boundary.Both );
        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="propertyExpression">属性表达式，范例：t => t.Age</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        IQuery<TEntity, TKey> Between<TProperty>( Expression<Func<TEntity, TProperty>> propertyExpression, double? min, double? max, Boundary boundary = Boundary.Both );
        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="propertyExpression">属性表达式，范例：t => t.Age</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        IQuery<TEntity, TKey> Between<TProperty>( Expression<Func<TEntity, TProperty>> propertyExpression, decimal? min, decimal? max, Boundary boundary = Boundary.Both );
        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="propertyExpression">属性表达式，范例：t => t.Time</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="includeTime">是否包含时间</param>
        /// <param name="boundary">包含边界</param>
        IQuery<TEntity, TKey> Between<TProperty>( Expression<Func<TEntity, TProperty>> propertyExpression, DateTime? min, DateTime? max,bool includeTime = true, Boundary? boundary = null );
        /// <summary>
        /// 添加排序
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="expression">属性表达式</param>
        /// <param name="desc">是否降序</param>
        IQuery<TEntity, TKey> OrderBy<TProperty>( Expression<Func<TEntity, TProperty>> expression, bool desc = false );
        /// <summary>
        /// 添加排序
        /// </summary>
        /// <param name="propertyName">排序属性</param>
        /// <param name="desc">是否降序</param>
        IQuery<TEntity, TKey> OrderBy( string propertyName, bool desc = false );
        /// <summary>
        /// 与连接
        /// </summary>
        /// <param name="predicate">查询条件</param>
        IQuery<TEntity, TKey> And( Expression<Func<TEntity, bool>> predicate );
        /// <summary>
        /// 与连接
        /// </summary>
        /// <param name="query">查询对象</param>
        IQuery<TEntity, TKey> And( IQuery<TEntity, TKey> query );
        /// <summary>
        /// 或连接
        /// </summary>
        /// <param name="predicates">查询条件</param>
        IQuery<TEntity, TKey> Or( params Expression<Func<TEntity, bool>>[] predicates );
        /// <summary>
        /// 或连接
        /// </summary>
        /// <param name="query">查询对象</param>
        IQuery<TEntity, TKey> Or( IQuery<TEntity, TKey> query );
    }
}
