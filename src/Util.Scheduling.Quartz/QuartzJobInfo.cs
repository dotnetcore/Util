namespace Util.Scheduling {
    /// <summary>
    /// Quartz任务信息
    /// </summary>
    public class QuartzJobInfo : IJobInfo {
        /// <summary>
        /// 任务名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 任务组名称
        /// </summary>
        public string Group { get; set; }
    }
}
