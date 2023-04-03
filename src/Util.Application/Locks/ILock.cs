using System;
using System.Threading.Tasks;

namespace Util.Applications.Locks {
    /// <summary>
    /// 业务锁
    /// </summary>
    public interface ILock {
        /// <summary>
        /// 锁定，true表示本次操作成功锁定资源，false表示资源已被之前的操作锁定
        /// </summary>
        /// <param name="key">锁定标识</param>
        /// <param name="expiration">锁定时间间隔</param>
        bool Lock( string key, TimeSpan? expiration = null );
        /// <summary>
        /// 锁定，true表示本次操作成功锁定资源，false表示资源已被之前的操作锁定
        /// </summary>
        /// <param name="key">锁定标识</param>
        /// <param name="expiration">锁定时间间隔</param>
        Task<bool> LockAsync( string key, TimeSpan? expiration = null );
        /// <summary>
        /// 解除锁定
        /// </summary>
        void UnLock();
        /// <summary>
        /// 解除锁定
        /// </summary>
        Task UnLockAsync();
    }
}
