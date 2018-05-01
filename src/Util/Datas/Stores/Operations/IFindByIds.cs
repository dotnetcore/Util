using System.Collections.Generic;
using Util.Domains;

namespace Util.Datas.Stores.Operations {
    /// <summary>
    /// 通过标识列表查找
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    /// <typeparam name="TKey">对象标识类型</typeparam>
    public interface IFindByIds<TEntity, in TKey> where TEntity : class, IKey<TKey> {
        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="ids">标识列表</param>
        List<TEntity> FindByIds( params TKey[] ids );
        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="ids">标识列表</param>
        List<TEntity> FindByIds( IEnumerable<TKey> ids );
        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="ids">逗号分隔的标识列表，范例："1,2"</param>
        List<TEntity> FindByIds( string ids );
    }
}
