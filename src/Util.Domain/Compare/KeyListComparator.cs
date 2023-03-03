using System.Collections.Generic;
using System.Linq;

namespace Util.Domain.Compare {
    /// <summary>
    /// 键列表比较器
    /// </summary>
    /// <typeparam name="TKey">标识类型</typeparam>
    public class KeyListComparator<TKey> {
        /// <summary>
        /// 比较
        /// </summary>
        /// <param name="newList">新实体集合</param>
        /// <param name="originalList">旧实体集合</param>
        public KeyListCompareResult<TKey> Compare( IEnumerable<TKey> newList, IEnumerable<TKey> originalList ) {
            newList.CheckNull( nameof(newList) );
            originalList.CheckNull( nameof( originalList ) );
            var newEntities = newList.ToList();
            var originalEntities = originalList.ToList();
            var createList = GetCreateList( newEntities, originalEntities );
            var updateList = GetUpdateList( newEntities, originalEntities );
            var deleteList = GetDeleteList( newEntities, originalEntities );
            return new KeyListCompareResult<TKey>( createList, updateList, deleteList );
        }

        /// <summary>
        /// 获取创建列表
        /// </summary>
        private List<TKey> GetCreateList( List<TKey> newList, List<TKey> originalList ) {
            var result = newList.Except( originalList );
            return result.ToList();
        }

        /// <summary>
        /// 获取更新列表
        /// </summary>
        private List<TKey> GetUpdateList( List<TKey> newList, List<TKey> originalList ) {
            return newList.FindAll( id => originalList.Exists( t => t.Equals( id ) ) );
        }

        /// <summary>
        /// 获取删除列表
        /// </summary>
        private List<TKey> GetDeleteList( List<TKey> newList, List<TKey> originalList ) {
            var result = originalList.Except( newList );
            return result.ToList();
        }
    }
}
