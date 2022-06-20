using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Util.Domain;
using Util.Validation;

namespace Util.Data.Stores {
    /// <summary>
    /// 存储器
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    public interface IStore<TEntity> : IStore<TEntity, Guid>, IQueryStore<TEntity>
        where TEntity : class, IKey<Guid> {
    }

    /// <summary>
    /// 存储器
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    /// <typeparam name="TKey">对象标识类型</typeparam>
    public interface IStore<TEntity, in TKey> : IQueryStore<TEntity, TKey> where TEntity : class, IKey<TKey> {
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task AddAsync( [Valid] TEntity entity, CancellationToken cancellationToken = default );
        /// <summary>
        /// 添加实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task AddAsync( [Valid] IEnumerable<TEntity> entities, CancellationToken cancellationToken = default );
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task UpdateAsync( [Valid] TEntity entity, CancellationToken cancellationToken = default );
        /// <summary>
        /// 修改实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task UpdateAsync( [Valid] IEnumerable<TEntity> entities, CancellationToken cancellationToken = default );
        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task RemoveAsync( object id, CancellationToken cancellationToken = default );
        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task RemoveAsync( TEntity entity, CancellationToken cancellationToken = default );
        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="ids">标识集合</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task RemoveAsync( IEnumerable<TKey> ids, CancellationToken cancellationToken = default );
        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task RemoveAsync( IEnumerable<TEntity> entities, CancellationToken cancellationToken = default );
    }
}
