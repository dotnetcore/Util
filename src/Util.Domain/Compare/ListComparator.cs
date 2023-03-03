using System.Collections.Generic;
using System.Linq;

namespace Util.Domain.Compare {
    /// <summary>
    /// 实体列表比较器
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">标识类型</typeparam>
    public class ListComparator<TEntity, TKey> where TEntity : IKey<TKey> {
        /// <summary>
        /// 比较
        /// </summary>
        /// <param name="newList">新实体集合</param>
        /// <param name="originalList">旧实体集合</param>
        public ListCompareResult<TEntity, TKey> Compare( IEnumerable<TEntity> newList, IEnumerable<TEntity> originalList ) {
            newList.CheckNull( nameof( newList ) );
            originalList.CheckNull( nameof( originalList ) );
            var newEntities = newList.ToList();
            var originalEntities = originalList.ToList();
            var createList = GetCreateList( newEntities, originalEntities );
            var updateList = GetUpdateList( newEntities, originalEntities );
            var deleteList = GetDeleteList( newEntities, originalEntities );
            return new ListCompareResult<TEntity, TKey>( createList, updateList, deleteList );
        }

        /// <summary>
        /// 获取创建列表
        /// </summary>
        private List<TEntity> GetCreateList( List<TEntity> newList, List<TEntity> originalList ) {
            var result = newList.Except( originalList );
            return result.ToList();
        }

        /// <summary>
        /// 获取更新列表
        /// </summary>
        private List<TEntity> GetUpdateList( List<TEntity> newList, List<TEntity> originalList ) {
            return newList.FindAll( entity => originalList.Exists( t => t.Id.Equals( entity.Id ) ) );
        }

        /// <summary>
        /// 获取删除列表
        /// </summary>
        private List<TEntity> GetDeleteList( List<TEntity> newList, List<TEntity> originalList ) {
            var result = originalList.Except( newList );
            return result.ToList();
        }
    }
}
