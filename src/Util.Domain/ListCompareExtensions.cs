using System;
using System.Collections.Generic;
using Util.Domain.Compare;

namespace Util.Domain {
    /// <summary>
    /// 列表比较器扩展
    /// </summary>
    public static class ListCompareExtensions {
        /// <summary>
        /// 比较
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="newList">新实体集合</param>
        /// <param name="originalList">旧实体集合</param>
        public static ListCompareResult<TEntity, Guid> Compare<TEntity>( this IEnumerable<TEntity> newList, IEnumerable<TEntity> originalList )
            where TEntity : IKey<Guid> {
            return Compare<TEntity, Guid>( newList, originalList );
        }

        /// <summary>
        /// 比较
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">标识类型</typeparam>
        /// <param name="newList">新实体集合</param>
        /// <param name="originalList">旧实体集合</param>
        public static ListCompareResult<TEntity, TKey> Compare<TEntity, TKey>( this IEnumerable<TEntity> newList, IEnumerable<TEntity> originalList )
            where TEntity : IKey<TKey> {
            var comparator = new ListComparator<TEntity, TKey>();
            return comparator.Compare( newList, originalList );
        }

        /// <summary>
        /// 比较
        /// </summary>
        /// <param name="newList">新实体标识集合</param>
        /// <param name="originalList">旧实体标识集合</param>
        public static KeyListCompareResult<Guid> Compare( this IEnumerable<Guid> newList, IEnumerable<Guid> originalList ) {
            var comparator = new KeyListComparator<Guid>();
            return comparator.Compare( newList, originalList );
        }

        /// <summary>
        /// 比较
        /// </summary>
        /// <param name="newList">新实体标识集合</param>
        /// <param name="originalList">旧实体标识集合</param>
        public static KeyListCompareResult<string> Compare( this IEnumerable<string> newList, IEnumerable<string> originalList ) {
            var comparator = new KeyListComparator<string>();
            return comparator.Compare( newList, originalList );
        }

        /// <summary>
        /// 比较
        /// </summary>
        /// <param name="newList">新实体标识集合</param>
        /// <param name="originalList">旧实体标识集合</param>
        public static KeyListCompareResult<int> Compare( this IEnumerable<int> newList, IEnumerable<int> originalList ) {
            var comparator = new KeyListComparator<int>();
            return comparator.Compare( newList, originalList );
        }

        /// <summary>
        /// 比较
        /// </summary>
        /// <param name="newList">新实体标识集合</param>
        /// <param name="originalList">旧实体标识集合</param>
        public static KeyListCompareResult<long> Compare( this IEnumerable<long> newList, IEnumerable<long> originalList ) {
            var comparator = new KeyListComparator<long>();
            return comparator.Compare( newList, originalList );
        }
    }
}
