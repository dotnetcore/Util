using System.Threading;
using System.Threading.Tasks;
using Util.Domains;

namespace Util.Datas.Stores.Operations {
    /// <summary>
    /// 通过标识查找
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    /// <typeparam name="TKey">对象标识类型</typeparam>
    public interface IFindByIdAsync<TEntity, in TKey> where TEntity : class, IKey<TKey> {
        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<TEntity> FindAsync( object id, CancellationToken cancellationToken = default( CancellationToken ) );
    }
}