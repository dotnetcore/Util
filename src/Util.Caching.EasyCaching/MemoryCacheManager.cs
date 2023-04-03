using EasyCaching.Core;

namespace Util.Caching.EasyCaching {
    /// <summary>
    /// EasyCaching内存缓存服务
    /// </summary>
    public class MemoryCacheManager : CacheManager, ILocalCache {
        /// <summary>
        /// 初始化EasyCaching内存缓存服务
        /// </summary>
        /// <param name="factory">EasyCaching缓存提供器工厂</param>
        public MemoryCacheManager( IEasyCachingProviderFactory factory ) : base( factory?.GetCachingProvider( CacheProviderKey.MemoryCache ) ) {
        }
    }
}
