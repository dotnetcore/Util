using System;
using System.Collections.Concurrent;

namespace Util.Biz.Locks {
    /// <summary>
    /// 业务锁
    /// </summary>
    public class BusinessLock : IBusinessLock{
        /// <summary>
        /// 锁定资源列表
        /// </summary>
        private static readonly ConcurrentDictionary<string, BusinessLockInfo> Data = new ConcurrentDictionary<string, BusinessLockInfo>();

        /// <summary>
        /// 空业务锁
        /// </summary>
        public static readonly IBusinessLock Null = new NullBusinessLock();

        /// <summary>
        /// 锁定，成功锁定返回true，false代表之前已被锁定
        /// </summary>
        /// <param name="key">锁定标识</param>
        public bool Lock( string key ) {
            if ( Data.ContainsKey( key ) )
                return false;
            var info = new BusinessLockInfo {
                Key = key,
                Time = DateTime.Now
            };
            return Data.TryAdd( key, info );
        }

        /// <summary>
        /// 解除锁定
        /// </summary>
        /// <param name="key">锁定标识</param>
        public void UnLock( string key ) {
            if( Data.ContainsKey( key ) == false )
                return;
            Data.TryRemove( key, out _ );
        }
    }
}
