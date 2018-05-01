using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Util.Domains;

namespace Util.Datas.Stores.Operations {
    /// <summary>
    /// 移除实体
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    /// <typeparam name="TKey">对象标识类型</typeparam>
    public interface IRemoveAsync<in TEntity, in TKey> where TEntity : class, IKey<TKey>, IVersion {
        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task RemoveAsync( object id, CancellationToken cancellationToken = default( CancellationToken ) );
        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task RemoveAsync( TEntity entity, CancellationToken cancellationToken = default( CancellationToken ) );
        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="ids">标识集合</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task RemoveAsync( IEnumerable<TKey> ids, CancellationToken cancellationToken = default( CancellationToken ) );
        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task RemoveAsync( IEnumerable<TEntity> entities, CancellationToken cancellationToken = default( CancellationToken ) );
    }
}