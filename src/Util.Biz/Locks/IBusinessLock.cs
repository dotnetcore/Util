namespace Util.Biz.Locks {
    /// <summary>
    /// 业务锁
    /// </summary>
    public interface IBusinessLock {
        /// <summary>
        /// 锁定，成功锁定返回true，false代表之前已被锁定
        /// </summary>
        /// <param name="key">锁定标识</param>
        bool Lock( string key );
        /// <summary>
        /// 解除锁定
        /// </summary>
        /// <param name="key">锁定标识</param>
        void UnLock( string key );
    }
}
