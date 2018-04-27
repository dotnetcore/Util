using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Util.Validations.Aspects;

namespace Util.Domains.Repositories {
    /// <summary>
    /// 仓储
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public interface IRepository<TEntity> : IRepository<TEntity, Guid>, IReadableRepository<TEntity> where TEntity : class, IAggregateRoot {
    }

    /// <summary>
    /// 仓储
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public interface IRepository<TEntity, in TKey> : IReadableRepository<TEntity, TKey> where TEntity : class, IAggregateRoot {
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Add( [Valid] TEntity entity );
        /// <summary>
        /// 添加实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        void Add( [Valid] IEnumerable<TEntity> entities );
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task AddAsync( [Valid] TEntity entity, CancellationToken cancellationToken = default( CancellationToken ) );
        /// <summary>
        /// 添加实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task AddAsync( [Valid] IEnumerable<TEntity> entities, CancellationToken cancellationToken = default( CancellationToken ) );
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Update( [Valid] TEntity entity );
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entities">实体集合</param>
        void Update( [Valid] IEnumerable<TEntity> entities );
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        Task UpdateAsync( [Valid] TEntity entity );
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entities">实体集合</param>
        Task UpdateAsync( [Valid] IEnumerable<TEntity> entities );
        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="id">实体标识</param>
        void Remove( TKey id );
        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="id">实体标识</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task RemoveAsync( TKey id, CancellationToken cancellationToken = default( CancellationToken ) );
        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Remove( TEntity entity );
        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task RemoveAsync( TEntity entity, CancellationToken cancellationToken = default( CancellationToken ) );
        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="ids">实体编号集合</param>
        void Remove( IEnumerable<TKey> ids );
        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="ids">实体编号集合</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task RemoveAsync( IEnumerable<TKey> ids, CancellationToken cancellationToken = default( CancellationToken ) );
        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        void Remove( IEnumerable<TEntity> entities );
        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task RemoveAsync( IEnumerable<TEntity> entities, CancellationToken cancellationToken = default( CancellationToken ) );
    }
}
