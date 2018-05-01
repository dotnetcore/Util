using System.Collections.Generic;
using Util.Domains;

namespace Util.Datas.Stores.Operations {
    /// <summary>
    /// 移除实体
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    /// <typeparam name="TKey">对象标识类型</typeparam>
    public interface IRemove<in TEntity, in TKey> where TEntity : class, IKey<TKey>, IVersion {
        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="id">标识</param>
        void Remove( object id );
        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Remove( TEntity entity );
        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="ids">标识集合</param>
        void Remove( IEnumerable<TKey> ids );
        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        void Remove( IEnumerable<TEntity> entities );
    }
}