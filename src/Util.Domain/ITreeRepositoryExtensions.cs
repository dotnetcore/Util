using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Domain.Trees;

namespace Util.Domain {
    /// <summary>
    /// 树形仓储扩展
    /// </summary>
    public static class ITreeRepositoryExtensions {
        /// <summary>
        /// 更新实体及所有下级节点路径
        /// </summary>
        /// <param name="repository">仓储</param>
        /// <param name="entity">实体</param>
        public static async Task UpdatePathAsync<TEntity, TKey, TParentId>( this ITreeRepository<TEntity, TKey, TParentId> repository, TEntity entity )
            where TEntity : class, ITreeEntity<TEntity, TKey, TParentId> {
            var manager = new UpdatePathManager<TEntity, TKey, TParentId>( repository );
            await manager.UpdatePathAsync( entity );
        }

        /// <summary>
        /// 获取缺失的父标识列表
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="entities">实体列表</param>
        public static List<string> GetMissingParentIds<TEntity>( this IEnumerable<TEntity> entities ) where TEntity : class, ITreeEntity<TEntity, Guid, Guid?> {
            return GetMissingParentIds<TEntity, Guid, Guid?>( entities );
        }

        /// <summary>
        /// 获取缺失的父标识列表
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// /// <typeparam name="TKey">标识类型</typeparam>
        /// <typeparam name="TParentId">父标识类型</typeparam>
        /// <param name="entities">实体列表</param>
        public static List<string> GetMissingParentIds<TEntity, TKey, TParentId>( this IEnumerable<TEntity> entities ) where TEntity : class, ITreeEntity<TEntity, TKey, TParentId> {
            var result = new List<string>();
            if ( entities == null )
                return result;
            var list = entities.ToList();
            list.ForEach( entity => {
                if ( entity == null )
                    return;
                result.AddRange( entity.GetParentIdsFromPath().Select( t => t.SafeString() ) );
            } );
            var ids = list.Select( t => t?.Id.SafeString() );
            return result.Except( ids ).ToList();
        }
    }
}
