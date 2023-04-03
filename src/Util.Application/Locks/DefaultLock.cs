using System;
using System.Threading.Tasks;
using Util.Caching;

namespace Util.Applications.Locks {
    /// <summary>
    /// 业务锁
    /// </summary>
    public class DefaultLock : ILock {
        /// <summary>
        /// 缓存
        /// </summary>
        private readonly ICache _cache;
        /// <summary>
        /// 锁定标识
        /// </summary>
        private string _key;
        /// <summary>
        /// 锁定时间间隔
        /// </summary>
        private TimeSpan? _expiration;

        /// <summary>
        /// 初始化业务锁
        /// </summary>
        /// <param name="cache">缓存</param>
        public DefaultLock( ICache cache ) {
            _cache = cache;
        }

        /// <inheritdoc />
        public bool Lock( string key, TimeSpan? expiration = null ) {
            _key = key;
            _expiration = expiration;
            if ( _cache.Exists( key ) )
                return false;
            return _cache.TrySet( key, 1, new CacheOptions { Expiration = expiration } );
        }

        /// <inheritdoc />
        public async Task<bool> LockAsync( string key, TimeSpan? expiration = null ) {
            _key = key;
            _expiration = expiration;
            if ( await _cache.ExistsAsync( key ) )
                return false;
            return await _cache.TrySetAsync( key, 1, new CacheOptions { Expiration = expiration } );
        }

        /// <inheritdoc />
        public void UnLock() {
            if ( _expiration != null )
                return;
            if ( _cache.Exists( _key ) == false )
                return;
            _cache.Remove( _key );
        }

        /// <inheritdoc />
        public async Task UnLockAsync() {
            if ( _expiration != null )
                return;
            if ( await _cache.ExistsAsync( _key ) == false )
                return;
            await _cache.RemoveAsync( _key );
        }
    }
}
