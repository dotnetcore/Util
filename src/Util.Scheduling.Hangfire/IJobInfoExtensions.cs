namespace Util.Scheduling {
    /// <summary>
    /// Hangfire任务信息扩展
    /// </summary>
    public static class IJobInfoExtensions {
        /// <summary>
        /// 设置任务标识
        /// </summary>
        /// <param name="source">任务信息</param>
        /// <param name="id">任务标识</param>
        public static IJobInfo Id( this IJobInfo source,string id ) {
            if ( source is HangfireJobInfo job ) 
                job.Id = id;
            return source;
        }

        /// <summary>
        /// 获取任务标识
        /// </summary>
        /// <param name="source">任务信息</param>
        public static string GetId( this IJobInfo source ) {
            if ( source is HangfireJobInfo job )
                return job.Id;
            return null;
        }

        /// <summary>
        /// 设置队列名称
        /// </summary>
        /// <param name="source">任务信息</param>
        /// <param name="queue">队列名称</param>
        public static IJobInfo Queue( this IJobInfo source, string queue ) {
            if ( source is HangfireJobInfo job )
                job.Queue = queue;
            return source;
        }

        /// <summary>
        /// 获取队列名称
        /// </summary>
        /// <param name="source">任务信息</param>
        public static string GetQueue( this IJobInfo source ) {
            if ( source is HangfireJobInfo job )
                return job.Queue;
            return "default";
        }
    }
}
