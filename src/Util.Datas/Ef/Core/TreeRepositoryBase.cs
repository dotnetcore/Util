using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Util.Datas.UnitOfWorks;
using Util.Domains.Trees;

namespace Util.Datas.Ef.Core {
    /// <summary>
    /// 树型仓储
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public abstract partial class TreeRepositoryBase<TEntity> : TreeRepositoryBase<TEntity, Guid, Guid?>, ITreeRepository<TEntity>
        where TEntity : class, ITreeEntity<TEntity, Guid, Guid?> {
        /// <summary>
        /// 初始化树型仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        protected TreeRepositoryBase( IUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }

        /// <summary>
        /// 生成排序号
        /// </summary>
        /// <param name="parentId">父编号</param>
        public override async Task<int> GenerateSortIdAsync( Guid? parentId ) {
            var maxSortId = await Find( t => t.ParentId == parentId ).MaxAsync( t => t.SortId );
            return maxSortId.SafeValue() + 1;
        }
    }

    /// <summary>
    /// 树型仓储
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    /// <typeparam name="TParentId">父标识类型</typeparam>
    public abstract partial class TreeRepositoryBase<TEntity, TKey, TParentId> : RepositoryBase<TEntity, TKey>, ITreeRepository<TEntity, TKey, TParentId>
        where TEntity : class, ITreeEntity<TEntity, TKey, TParentId> {
        /// <summary>
        /// 初始化树型仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        protected TreeRepositoryBase( IUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }

        /// <summary>
        /// 生成排序号
        /// </summary>
        /// <param name="parentId">父编号</param>
        public abstract Task<int> GenerateSortIdAsync( TParentId parentId );

        /// <summary>
        /// 获取全部下级实体
        /// </summary>
        /// <param name="parent">父实体</param>
        public virtual async Task<List<TEntity>> GetAllChildrenAsync( TEntity parent ) {
            var list = await FindAllAsync( t => t.Path.StartsWith( parent.Path ) );
            return list.Where( t => !t.Id.Equals( parent.Id ) ).ToList();
        }
    }
}
