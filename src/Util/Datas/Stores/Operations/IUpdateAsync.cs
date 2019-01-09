using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Domains;
using Util.Validations.Aspects;

namespace Util.Datas.Stores.Operations {
    /// <summary>
    /// 修改实体
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    /// <typeparam name="TKey">对象标识类型</typeparam>
    public interface IUpdateAsync<in TEntity, in TKey> where TEntity : class, IKey<TKey> {
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        Task UpdateAsync( [Valid] TEntity entity );
        /// <summary>
        /// 修改实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        Task UpdateAsync( [Valid] IEnumerable<TEntity> entities );
    }
}