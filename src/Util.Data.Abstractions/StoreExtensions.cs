using Util.Data.Queries;
using Util.Data.Stores;
using Util.Domain;

namespace Util.Data {
    /// <summary>
    /// 存储器扩展
    /// </summary>
    public static class StoreExtensions {
        /// <summary>
        /// 设置为不跟踪实体
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">实体标识类型</typeparam>
        /// <param name="source">源</param>
        public static IQueryStore<TEntity, TKey> NoTracking<TEntity, TKey>( this IQueryStore<TEntity, TKey> source ) where TEntity : class, IKey<TKey> {
            source.CheckNull( nameof( source ) );
            if( source is ITrack store )
                store.NoTracking();
            return source;
        }
    }
}
