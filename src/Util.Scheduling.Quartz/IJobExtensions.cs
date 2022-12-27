using Quartz;

namespace Util.Scheduling {
    /// <summary>
    /// Quartz任务扩展
    /// </summary>
    public static class IJobExtensions {
        /// <summary>
        /// 获取Quartz任务信息
        /// </summary>
        /// <param name="source">任务</param>
        public static IJobDetail GetDetail( this IJob source ) {
            if ( source is JobBase job )
                return job.GetJobDetail();
            return null;
        }

        /// <summary>
        /// 获取Quartz任务触发器
        /// </summary>
        /// <param name="source">任务</param>
        public static ITrigger GetTrigger( this IJob source ) {
            if ( source is JobBase job )
                return job.GetTrigger();
            return null;
        }
    }
}
