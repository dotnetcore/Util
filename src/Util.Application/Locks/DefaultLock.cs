using System;
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
        /// 延迟执行时间
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
            return _cache.TryAdd( key, 1, expiration );
        }

        /// <inheritdoc />
        public void UnLock() {
            if ( _expiration != null )
                return;
            if( _cache.Exists( _key ) == false )
                return;
            _cache.Remove( _key );
        }
    }
}
