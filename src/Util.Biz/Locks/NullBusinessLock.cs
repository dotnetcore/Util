namespace Util.Biz.Locks {
    /// <summary>
    /// 空业务锁
    /// </summary>
    public class NullBusinessLock : IBusinessLock {
        /// <summary>
        /// 锁定，成功锁定返回true，false代表之前已被锁定
        /// </summary>
        /// <param name="key">锁定标识</param>
        public bool Lock( string key ) {
            return true;
        }

        /// <summary>
        /// 解除锁定
        /// </summary>
        /// <param name="key">锁定标识</param>
        public void UnLock( string key ) {
        }
    }
}
