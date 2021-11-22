using System;
using Util.Domain.Trees;

namespace Util.Data.EntityFrameworkCore.Trees {
    /// <summary>
    /// 树形仓储
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public abstract class TreeRepositoryBase<TEntity> : TreeRepositoryBase<TEntity, Guid, Guid?>, ITreeRepository<TEntity>
        where TEntity : class, ITreeEntity<TEntity, Guid, Guid?> {
        /// <summary>
        /// 初始化树形仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        protected TreeRepositoryBase( IUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }

    /// <summary>
    /// 树形仓储
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    /// <typeparam name="TParentId">父标识类型</typeparam>
    public abstract class TreeRepositoryBase<TEntity, TKey, TParentId> : RepositoryBase<TEntity, TKey>, ITreeRepository<TEntity, TKey, TParentId>
        where TEntity : class, ITreeEntity<TEntity, TKey, TParentId> {
        /// <summary>
        /// 初始化树形仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        protected TreeRepositoryBase( IUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}
