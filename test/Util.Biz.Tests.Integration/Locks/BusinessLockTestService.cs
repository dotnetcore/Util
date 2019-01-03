using Util.Biz.Locks;

namespace Util.Biz.Tests.Integration.Locks {
    /// <summary>
    /// 业务锁测试服务
    /// </summary>
    public class BusinessLockTestService {
        /// <summary>
        /// 业务锁
        /// </summary>
        private readonly BusinessLock _lock;

        /// <summary>
        /// 初始化业务锁测试服务
        /// </summary>
        public BusinessLockTestService() {
            _lock = new BusinessLock();
        }

        /// <summary>
        /// 执行
        /// </summary>
        public string Execute( string key ) {
            var result = _lock.Lock( key );
            return result ? "ok" : "fail";
        }

        /// <summary>
        /// 解锁
        /// </summary>
        public void UnLock( string key ) {
            _lock.UnLock( key );
        }
    }
}
