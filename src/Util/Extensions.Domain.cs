using System;
using System.Collections.Generic;
using Util.Domains;

namespace Util {
    /// <summary>
    /// 实体扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 比较
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="newList">新实体集合</param>
        /// <param name="oldList">旧实体集合</param>
        public static ListCompareResult<TEntity, Guid> Compare<TEntity>( this IEnumerable<TEntity> newList, IEnumerable<TEntity> oldList )
            where TEntity : IKey<Guid> {
            return Compare<TEntity,Guid>( newList, oldList );
        }

        /// <summary>
        /// 比较
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">标识类型</typeparam>
        /// <param name="newList">新实体集合</param>
        /// <param name="oldList">旧实体集合</param>
        public static ListCompareResult<TEntity, TKey> Compare<TEntity, TKey>( this IEnumerable<TEntity> newList, IEnumerable<TEntity> oldList )
            where TEntity : IKey<TKey> {
            var comparator = new ListComparator<TEntity, TKey>();
            return comparator.Compare( newList, oldList );
        }
    }
}
