using System;

namespace Util.Scheduling {
    /// <summary>
    /// Hangfire触发器
    /// </summary>
    public class HangfireTrigger : IJobTrigger {
        /// <summary>
        /// 延迟执行时间间隔
        /// </summary>
        public TimeSpan? Delay { get; set; }
        /// <summary>
        /// Cron表达式
        /// </summary>
        public string Cron { get; set; }
    }
}
