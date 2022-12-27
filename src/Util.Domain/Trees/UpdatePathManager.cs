using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Data;
using Util.Domain.Properties;
using Util.Exceptions;

namespace Util.Domain.Trees {
    /// <summary>
    /// 树形路径更新服务
    /// </summary>
    public class UpdatePathManager<TEntity, TKey, TParentId>
        where TEntity : class, ITreeEntity<TEntity, TKey, TParentId> {
        /// <summary>
        /// 仓储
        /// </summary>
        private readonly ITreeRepository<TEntity, TKey, TParentId> _repository;

        /// <summary>
        /// 初始化树型路径更新服务
        /// </summary>
        /// <param name="repository">仓储</param>
        public UpdatePathManager( ITreeRepository<TEntity, TKey, TParentId> repository ) {
            _repository = repository;
        }

        /// <summary>
        /// 更新实体及所有下级节点路径
        /// </summary>
        /// <param name="entity">实体</param>
        public async Task UpdatePathAsync( TEntity entity ) {
            entity.CheckNull( nameof( entity ) );
            if( entity.ParentId.Equals( entity.Id ) )
                throw new Warning( DomainResource.NotSupportMoveToChildren );
            var old = await _repository.NoTracking().FindByIdAsync( entity.Id );
            if( old == null )
                return;
            if( entity.ParentId.Equals( old.ParentId ) )
                return;
            var children = await _repository.GetAllChildrenAsync( entity );
            if( children.Exists( t => t.Id.Equals( entity.ParentId ) ) )
                throw new Warning( DomainResource.NotSupportMoveToChildren );
            var parent = await _repository.FindByIdAsync( entity.ParentId );
            entity.InitPath( parent );
            UpdateChildrenPath( entity, children );
            await _repository.UpdateAsync( children );
        }

        /// <summary>
        /// 修改路径
        /// </summary>
        private void UpdateChildrenPath( TEntity parent, List<TEntity> children ) {
            if( parent == null || children == null )
                return;
            var list = children.Where( t => t.ParentId.Equals( parent.Id ) ).ToList();
            foreach( var child in list ) {
                child.InitPath( parent );
                UpdateChildrenPath( child, children );
            }
        }
    }
}
