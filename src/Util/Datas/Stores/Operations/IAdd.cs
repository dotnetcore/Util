using System.Collections.Generic;
using Util.Domains;
using Util.Validations.Aspects;

namespace Util.Datas.Stores.Operations {
    /// <summary>
    /// 添加实体
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    /// <typeparam name="TKey">对象标识类型</typeparam>
    public interface IAdd<in TEntity, in TKey> where TEntity : class, IKey<TKey> {
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
    }
}