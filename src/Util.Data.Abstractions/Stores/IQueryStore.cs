using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Util.Data.Filters;
using Util.Dependency;
using Util.Domain;

namespace Util.Data.Stores {
    /// <summary>
    /// 查询存储器
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public interface IQueryStore<TEntity> : IQueryStore<TEntity, Guid> where TEntity : class, IKey<Guid> {
    }

    /// <summary>
    /// 查询存储器
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public interface IQueryStore<TEntity, in TKey> : IFilterOperation,IScopeDependency,IDisposable where TEntity : class, IKey<TKey> {
        /// <summary>
        /// 获取查询对象
        /// </summary>
        IQueryable<TEntity> Find();
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="condition">查询条件</param>
        IQueryable<TEntity> Find( ICondition<TEntity> condition );
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="condition">查询条件</param>
        IQueryable<TEntity> Find( Expression<Func<TEntity, bool>> condition );
        /// <summary>
        /// 通过标识查找实体
        /// </summary>
        /// <param name="id">标识</param>
        TEntity FindById( object id );
        /// <summary>
        /// 通过标识查找实体
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<TEntity> FindByIdAsync( object id, CancellationToken cancellationToken = default );
        /// <summary>
        /// 通过标识列表查找实体列表
        /// </summary>
        /// <param name="ids">标识列表</param>
        List<TEntity> FindByIds( params TKey[] ids );
        /// <summary>
        /// 通过标识列表查找实体列表
        /// </summary>
        /// <param name="ids">标识列表</param>
        List<TEntity> FindByIds( IEnumerable<TKey> ids );
        /// <summary>
        /// 通过标识列表查找实体列表
        /// </summary>
        /// <param name="ids">逗号分隔的标识列表，范例："1,2"</param>
        List<TEntity> FindByIds( string ids );
        /// <summary>
        /// 通过标识列表查找实体列表
        /// </summary>
        /// <param name="ids">标识列表</param>
        Task<List<TEntity>> FindByIdsAsync( params TKey[] ids );
        /// <summary>
        /// 通过标识列表查找实体列表
        /// </summary>
        /// <param name="ids">标识列表</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<List<TEntity>> FindByIdsAsync( IEnumerable<TKey> ids, CancellationToken cancellationToken = default );
        /// <summary>
        /// 通过标识列表查找实体列表
        /// </summary>
        /// <param name="ids">逗号分隔的标识列表，范例："1,2"</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<List<TEntity>> FindByIdsAsync( string ids, CancellationToken cancellationToken = default );
        /// <summary>
        /// 查找单个实体
        /// </summary>
        /// <param name="condition">查询条件</param>
        TEntity Single( Expression<Func<TEntity, bool>> condition );
        /// <summary>
        /// 查找单个实体
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="action">访问IQueryable的回调函数,用于执行Include等操作</param>
        TEntity Single( Expression<Func<TEntity, bool>> condition, Func<IQueryable<TEntity>, IQueryable<TEntity>> action );
        /// <summary>
        /// 查找单个实体
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<TEntity> SingleAsync( Expression<Func<TEntity, bool>> condition, CancellationToken cancellationToken = default );
        /// <summary>
        /// 查找单个实体
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="action">访问IQueryable的回调函数,用于执行Include等操作</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<TEntity> SingleAsync( Expression<Func<TEntity, bool>> condition, Func<IQueryable<TEntity>, IQueryable<TEntity>> action, CancellationToken cancellationToken = default );
        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="condition">查询条件</param>
        List<TEntity> FindAll( Expression<Func<TEntity, bool>> condition = null );
        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<List<TEntity>> FindAllAsync( Expression<Func<TEntity, bool>> condition = null, CancellationToken cancellationToken = default );
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="ids">标识列表</param>
        bool Exists( params TKey[] ids );
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="condition">条件</param>
        bool Exists( Expression<Func<TEntity, bool>> condition );
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="ids">标识列表</param>
        Task<bool> ExistsAsync( params TKey[] ids );
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="condition">条件</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<bool> ExistsAsync( Expression<Func<TEntity, bool>> condition, CancellationToken cancellationToken = default );
        /// <summary>
        /// 查找数量
        /// </summary>
        /// <param name="condition">条件</param>
        int Count( Expression<Func<TEntity, bool>> condition = null );
        /// <summary>
        /// 查找数量
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<int> CountAsync( Expression<Func<TEntity, bool>> condition = null, CancellationToken cancellationToken = default );
    }
}
