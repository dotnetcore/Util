using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Util.Datas.Stores;
using Util.Domains;
using Util.Domains.Trees;

namespace Util.Datas.Ef.Core {
    /// <summary>
    /// 树型仓储
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TPo">持久化对象类型</typeparam>
    public abstract partial class TreeCompactRepositoryBase<TEntity, TPo> 
        : TreeCompactRepositoryBase<TEntity, TPo, Guid, Guid?>, ITreeCompactRepository<TEntity>
        where TEntity : class, ITreeEntity<TEntity, Guid, Guid?>
        where TPo : class, IKey<Guid>, IVersion, IPath, IParentId<Guid?>, ISortId {
        /// <summary>
        /// 存储器
        /// </summary>
        private readonly IStore<TPo, Guid> _store;

        /// <summary>
        /// 初始化树型仓储
        /// </summary>
        /// <param name="store">存储器</param>
        protected TreeCompactRepositoryBase( IStore<TPo, Guid> store ) : base( store ) {
            _store = store;
        }

        /// <summary>
        /// 生成排序号
        /// </summary>
        /// <param name="parentId">父标识</param>
        public override async Task<int> GenerateSortIdAsync( Guid? parentId ) {
            var maxSortId = await _store.Find( t => t.ParentId == parentId ).MaxAsync( t => t.SortId );
            return maxSortId.SafeValue() + 1;
        }
    }

    /// <summary>
    /// 树型仓储
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TPo">持久化对象类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    /// <typeparam name="TParentId">父标识类型</typeparam>
    public abstract partial class TreeCompactRepositoryBase<TEntity, TPo, TKey, TParentId> 
        : CompactRepositoryBase<TEntity, TPo, TKey>, ITreeCompactRepository<TEntity, TKey, TParentId>
        where TEntity : class, ITreeEntity<TEntity, TKey, TParentId>
        where TPo : class, IKey<TKey>, IVersion, IPath {
        /// <summary>
        /// 存储器
        /// </summary>
        private readonly IStore<TPo, TKey> _store;

        /// <summary>
        /// 初始化树型仓储
        /// </summary>
        /// <param name="store">存储器</param>
        protected TreeCompactRepositoryBase( IStore<TPo, TKey> store ) : base( store ) {
            _store = store;
        }

        /// <summary>
        /// 生成排序号
        /// </summary>
        /// <param name="parentId">父标识</param>
        public abstract Task<int> GenerateSortIdAsync( TParentId parentId );

        /// <summary>
        /// 获取全部下级实体
        /// </summary>
        /// <param name="parent">父实体</param>
        public virtual async Task<List<TEntity>> GetAllChildrenAsync( TEntity parent ) {
            var list = await _store.FindAllAsync( t => t.Path.StartsWith( parent.Path ) );
            return list.Where( t => !t.Id.Equals( parent.Id ) ).Select( ToEntity ).ToList();
        }

        /// <summary>
        /// 查找未跟踪单个实体
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="cancellationToken">取消令牌</param>
        public virtual async Task<TEntity> FindByIdNoTrackingAsync( TKey id, CancellationToken cancellationToken = default( CancellationToken ) ) {
            return ToEntity( await _store.FindByIdNoTrackingAsync( id, cancellationToken ) );
        }
    }
}
