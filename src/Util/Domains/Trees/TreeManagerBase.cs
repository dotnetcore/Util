using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Domains.Services;
using Util.Exceptions;
using Util.Properties;

namespace Util.Domains.Trees {
    /// <summary>
    /// 树型服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public class TreeManagerBase<TEntity> : TreeManagerBase<TEntity, Guid, Guid?> where TEntity : class, ITreeEntity<TEntity, Guid, Guid?> {
        /// <summary>
        /// 初始化树型服务
        /// </summary>
        /// <param name="repository">仓储</param>
        public TreeManagerBase( ITreeRepository<TEntity, Guid, Guid?> repository ) : base( repository ) {
        }
    }

    /// <summary>
    /// 树型服务
    /// </summary>
    public abstract class TreeManagerBase<TEntity, TKey, TParentId> : DomainServiceBase
        where TEntity : class, ITreeEntity<TEntity, TKey, TParentId> {
        /// <summary>
        /// 仓储
        /// </summary>
        private readonly ITreeRepository<TEntity, TKey, TParentId> _repository;

        /// <summary>
        /// 初始化树型服务
        /// </summary>
        /// <param name="repository">仓储</param>
        protected TreeManagerBase( ITreeRepository<TEntity, TKey, TParentId> repository ) {
            _repository = repository;
        }

        /// <summary>
        /// 更新实体及所有下级节点路径
        /// </summary>
        /// <param name="entity">实体</param>
        public async Task UpdatePathAsync( TEntity entity ) {
            entity.CheckNull( nameof( entity ) );
            if( entity.ParentId.Equals( entity.Id ) )
                return;
            var old = await _repository.FindNoTrackingAsync( entity.Id );
            if( old == null )
                return;
            if( entity.ParentId.Equals( old.ParentId ) )
                return;
            var children = await _repository.GetAllChildrenAsync( entity );
            if( children.Exists( t => t.Id.Equals( entity.ParentId ) ) )
                throw new Warning( LibraryResource.NotSupportMoveToChildren );
            var parent = await _repository.FindAsync( entity.ParentId );
            entity.InitPath( parent );
            await UpdateChildrenPath( entity, children );
            await _repository.UpdateAsync( children );
        }

        /// <summary>
        /// 修改路径
        /// </summary>
        private async Task UpdateChildrenPath( TEntity parent, List<TEntity> children ) {
            if( parent == null || children == null )
                return;
            var list = children.Where( t => t.ParentId.Equals( parent.Id ) ).ToList();
            foreach( var child in list ) {
                child.InitPath( parent );
                await UpdateChildrenPath( child, children );
            }
        }
    }
}
