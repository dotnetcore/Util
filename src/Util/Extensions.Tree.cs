using System.Threading.Tasks;
using Util.Domains.Trees;

namespace Util {
    /// <summary>
    /// 树型扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 更新实体及所有下级节点路径
        /// </summary>
        /// <param name="repository">仓储</param>
        /// <param name="entity">实体</param>
        public static async Task UpdatePathAsync<TEntity, TKey, TParentId>( this ITreeCompactRepository<TEntity, TKey, TParentId> repository, TEntity entity )
            where TEntity : class, ITreeEntity<TEntity, TKey, TParentId> {
            var manager = new UpdatePathManager<TEntity, TKey, TParentId>( repository );
            await manager.UpdatePathAsync( entity );
        }
    }
}
