namespace Util.Applications.Locks {
    /// <summary>
    /// 业务锁类型
    /// </summary>
    public enum LockType {
        /// <summary>
        /// 用户锁，当用户发出多个执行该操作的请求，只有第一个请求被执行，其它请求被抛弃，其它用户不受影响
        /// </summary>
        User = 0,
        /// <summary>
        /// 全局锁，该操作同时只有一个用户的请求被执行
        /// </summary>
        Global = 1
    }
}
