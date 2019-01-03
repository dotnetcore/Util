using System;

namespace Util.Biz.Locks {
    /// <summary>
    /// 业务锁信息
    /// </summary>
    public class BusinessLockInfo {
        /// <summary>
        /// 锁定标识
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 锁定时间
        /// </summary>
        public DateTime Time { get; set; }
    }
}
