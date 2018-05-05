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

        /// <summary>
        /// 交换排序
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="swapEntity">交换实体</param>
        public static void SwapSort( this ISortId entity, ISortId swapEntity ) {
            var sortId = entity.SortId;
            entity.SortId = swapEntity.SortId;
            swapEntity.SortId = sortId;
        }
    }
}
