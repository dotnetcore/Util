using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Domain.Repositories;

namespace Util.Domain.Trees {
    /// <summary>
    /// 树形仓储
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public interface ITreeRepository<TEntity> : ITreeRepository<TEntity, Guid, Guid?> where TEntity : class, ITreeEntity<TEntity, Guid, Guid?> {
    }

    /// <summary>
    /// 树形仓储
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    /// <typeparam name="TParentId">父标识类型</typeparam>
    public interface ITreeRepository<TEntity, in TKey, in TParentId> : IRepository<TEntity, TKey>
        where TEntity : class,ITreeEntity<TEntity, TKey, TParentId> {
        /// <summary>
        /// 获取全部下级实体
        /// </summary>
        /// <param name="parent">父实体</param>
        Task<List<TEntity>> GetAllChildrenAsync( TEntity parent );
    }
}
