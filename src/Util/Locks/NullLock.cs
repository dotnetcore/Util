using System;

namespace Util.Locks {
    /// <summary>
    /// 空业务锁
    /// </summary>
    public class NullLock : ILock {
        /// <summary>
        /// 空业务锁
        /// </summary>
        public static readonly ILock Instance = new NullLock();

        /// <summary>
        /// 锁定，成功锁定返回true，false代表之前已被锁定
        /// </summary>
        /// <param name="key">锁定标识</param>
        /// <param name="expiration">锁定时间间隔</param>
        public bool Lock( string key, TimeSpan? expiration = null ) {
            return true;
        }

        /// <summary>
        /// 解除锁定
        /// </summary>
        public void UnLock() {
        }
    }
}
