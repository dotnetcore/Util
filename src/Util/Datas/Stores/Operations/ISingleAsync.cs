using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Util.Domains;

namespace Util.Datas.Stores.Operations {
    /// <summary>
    /// 查找单个实体
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    /// <typeparam name="TKey">对象标识类型</typeparam>
    public interface ISingleAsync<TEntity, in TKey> where TEntity : class, IKey<TKey> {
        /// <summary>
        /// 查找单个实体
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<TEntity> SingleAsync( Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default( CancellationToken ) );
    }
}