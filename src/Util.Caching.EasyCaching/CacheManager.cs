using System;
using EasyCaching.Core;

namespace Util.Caching.EasyCaching {
    /// <summary>
    /// EasyCaching缓存服务
    /// </summary>
    public class CacheManager : ICache {
        /// <summary>
        /// 缓存提供器
        /// </summary>
        private readonly IEasyCachingProvider _provider;

        /// <summary>
        /// 初始化缓存服务
        /// </summary>
        /// <param name="provider">EasyCaching缓存提供器</param>
        public CacheManager( IEasyCachingProvider provider ) {
            _provider = provider;
        }

        /// <inheritdoc />
        public bool Exists( string key ) {
            return _provider.Exists( key );
        }

        /// <inheritdoc />
        public T Get<T>( string key, Func<T> action, TimeSpan? expiration = null ) {
            var result = _provider.Get( key, action, GetExpiration( expiration ) );
            return result.Value;
        }

        /// <summary>
        /// 获取过期时间间隔
        /// </summary>
        private TimeSpan GetExpiration( TimeSpan? expiration ) {
            expiration ??= TimeSpan.FromHours( 12 );
            return expiration.SafeValue();
        }

        /// <inheritdoc />
        public bool TryAdd<T>( string key, T value, TimeSpan? expiration = null ) {
            return _provider.TrySet( key, value, GetExpiration( expiration ) );
        }

        /// <inheritdoc />
        public void Remove( string key ) {
            _provider.Remove( key );
        }

        /// <inheritdoc />
        public void Clear() {
            _provider.Flush();
        }
    }
}
