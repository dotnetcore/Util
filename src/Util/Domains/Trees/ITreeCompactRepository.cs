using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Datas.Stores.Operations;
using Util.Domains.Repositories;

namespace Util.Domains.Trees {
    /// <summary>
    /// 树型仓储
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public interface ITreeCompactRepository<TEntity> : ITreeCompactRepository<TEntity, Guid, Guid?> where TEntity : class, ITreeEntity<TEntity, Guid, Guid?> {
    }

    /// <summary>
    /// 树型仓储
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    /// <typeparam name="TParentId">父标识类型</typeparam>
    public interface ITreeCompactRepository<TEntity, in TKey, in TParentId> : ICompactRepository<TEntity, TKey>,IFindByIdNoTrackingAsync<TEntity,TKey>
        where TEntity : class, ITreeEntity<TEntity, TKey, TParentId> {
        /// <summary>
        /// 生成排序号
        /// </summary>
        /// <param name="parentId">父标识</param>
        Task<int> GenerateSortIdAsync( TParentId parentId );
        /// <summary>
        /// 获取全部下级实体
        /// </summary>
        /// <param name="parent">父实体</param>
        Task<List<TEntity>> GetAllChildrenAsync( TEntity parent );
    }
}
