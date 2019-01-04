using System;

namespace Util.Locks {
    /// <summary>
    /// 业务锁
    /// </summary>
    public interface ILock {
        /// <summary>
        /// 锁定，成功锁定返回true，false代表之前已被锁定
        /// </summary>
        /// <param name="key">锁定标识</param>
        /// <param name="expiration">锁定时间间隔</param>
        bool Lock( string key, TimeSpan? expiration = null );
        /// <summary>
        /// 解除锁定
        /// </summary>
        void UnLock();
    }
}
