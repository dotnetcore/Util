using System;

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
        public string Execute( string key, TimeSpan? expiration = null ) {
            var result = _lock.Lock( key, expiration );
            return result ? "ok" : "fail";
        }

        /// <summary>
        /// 解锁
        /// </summary>
        public void UnLock() {
            _lock.UnLock();
        }
    }
}
