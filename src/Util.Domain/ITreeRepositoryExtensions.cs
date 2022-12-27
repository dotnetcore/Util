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
    }
}
