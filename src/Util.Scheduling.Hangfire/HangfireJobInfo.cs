namespace Util.Scheduling {
    /// <summary>
    /// Hangfire任务信息
    /// </summary>
    public class HangfireJobInfo : IJobInfo {
        /// <summary>
        /// 任务标识
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 队列名称
        /// </summary>
        public string Queue { get; set; } = "default";
    }
}
