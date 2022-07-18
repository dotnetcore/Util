using System;

namespace Util.Applications.Locks {
    /// <summary>
    /// 空业务锁
    /// </summary>
    public class NullLock : ILock {
        /// <summary>
        /// 空业务锁
        /// </summary>
        public static readonly ILock Instance = new NullLock();

        /// <inheritdoc />
        public bool Lock( string key, TimeSpan? expiration = null ) {
            return true;
        }

        /// <inheritdoc />
        public void UnLock() {
        }
    }
}
