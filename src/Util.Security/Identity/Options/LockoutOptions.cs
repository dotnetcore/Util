using System;

namespace Util.Security.Identity.Options {
    /// <summary>
    /// 登录锁定配置
    /// </summary>
    public class LockoutOptions {
        /// <summary>
        /// 是否锁定新创建的用户，默认锁定
        /// </summary>
        public bool AllowedForNewUsers { get; set; } = true;

        /// <summary>
        /// 导致锁定的登录失败最大次数，默认5次
        /// </summary>
        public int MaxFailedAccessAttempts { get; set; } = 5;

        /// <summary>
        /// 锁定时间间隔，默认5分钟
        /// </summary>
        public TimeSpan LockoutTimeSpan { get; set; } = TimeSpan.FromMinutes( 5 );
    }
}
