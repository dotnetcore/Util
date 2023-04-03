using System;
using System.Threading.Tasks;

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
        public Task<bool> LockAsync( string key, TimeSpan? expiration = null ) {
            return Task.FromResult( true );
        }

        /// <inheritdoc />
        public void UnLock() {
        }

        /// <inheritdoc />
        public Task UnLockAsync() {
            return Task.CompletedTask;
        }
    }
}
