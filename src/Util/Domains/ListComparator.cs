using System;
using System.Collections.Generic;
using System.Linq;

namespace Util.Domains {
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
        /// <param name="oldList">旧实体集合</param>
        public ListCompareResult<TEntity, TKey> Compare( IEnumerable<TEntity> newList, IEnumerable<TEntity> oldList ) {
            if( newList == null )
                throw new ArgumentNullException( nameof( newList ) );
            if( oldList == null )
                throw new ArgumentNullException( nameof( oldList ) );
            var newEntities = newList.ToList();
            var oldEntities = oldList.ToList();
            var createList = GetCreateList( newEntities, oldEntities );
            var updateList = GetUpdateList( newEntities, oldEntities );
            var deleteList = GetDeleteList( newEntities, oldEntities );
            return new ListCompareResult<TEntity, TKey>( createList, updateList, deleteList );
        }

        /// <summary>
        /// 获取创建列表
        /// </summary>
        private List<TEntity> GetCreateList( List<TEntity> newList, List<TEntity> oldList ) {
            var result = newList.Except( oldList );
            return result.ToList();
        }

        /// <summary>
        /// 获取更新列表
        /// </summary>
        private List<TEntity> GetUpdateList( List<TEntity> newList, List<TEntity> oldList ) {
            return newList.FindAll( entity => oldList.Exists( t => t.Id.Equals( entity.Id ) ) );
        }

        /// <summary>
        /// 获取删除列表
        /// </summary>
        private List<TEntity> GetDeleteList( List<TEntity> newList, List<TEntity> oldList ) {
            var result = oldList.Except( newList );
            return result.ToList();
        }
    }
}
