using System;
using System.Threading.Tasks;

namespace Util.Applications.Locks {
    /// <summary>
    /// 业务锁测试服务
    /// </summary>
    public class LockTestService {
        /// <summary>
        /// 业务锁
        /// </summary>
        private readonly ILock _lock;

        /// <summary>
        /// 初始化业务锁测试服务
        /// </summary>
        public LockTestService( ILock lLock ) {
            _lock = lLock;
        }

        /// <summary>
        /// 执行
        /// </summary>
        public async Task<string> ExecuteAsync( string key, TimeSpan? expiration = null ) {
            var result = await _lock.LockAsync( key, expiration );
            return result ? "ok" : "fail";
        }

        /// <summary>
        /// 解锁
        /// </summary>
        public async Task UnLockAsync() {
            await _lock.UnLockAsync();
        }
    }
}
