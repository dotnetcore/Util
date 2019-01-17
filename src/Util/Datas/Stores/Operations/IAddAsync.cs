using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Util.Domains;
using Util.Validations.Aspects;

namespace Util.Datas.Stores.Operations {
    /// <summary>
    /// 添加实体
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    /// <typeparam name="TKey">对象标识类型</typeparam>
    public interface IAddAsync<in TEntity, in TKey> where TEntity : class, IKey<TKey> {
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
    }
}