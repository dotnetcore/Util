using System;
using EasyCaching.Core;

namespace Util.Caching.EasyCaching {
    /// <summary>
    /// EasyCaching Redis缓存服务
    /// </summary>
    public class RedisCacheManager : CacheManager, IRedisCache {
        /// <summary>
        /// Redis缓存提供器
        /// </summary>
        private readonly IRedisCachingProvider _provider;

        /// <summary>
        /// 初始化EasyCaching Redis缓存服务
        /// </summary>
        /// <param name="factory">EasyCaching缓存提供器工厂</param>
        public RedisCacheManager( IEasyCachingProviderFactory factory ) : base( factory?.GetCachingProvider( CacheProviderKey.RedisCache ) ) {
            if ( factory == null )
                throw new ArgumentNullException( nameof(factory) );
            _provider = factory.GetRedisProvider( CacheProviderKey.RedisCache );
        }
    }
}
