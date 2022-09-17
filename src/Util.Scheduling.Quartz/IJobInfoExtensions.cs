namespace Util.Scheduling {
    /// <summary>
    /// Quartz任务信息扩展
    /// </summary>
    public static class IJobInfoExtensions {
        /// <summary>
        /// 设置任务名称
        /// </summary>
        /// <param name="source">任务信息</param>
        /// <param name="name">任务名称</param>
        public static IJobInfo Name( this IJobInfo source,string name ) {
            if ( source is QuartzJobInfo job ) 
                job.Name = name;
            return source;
        }

        /// <summary>
        /// 设置任务组名称
        /// </summary>
        /// <param name="source">任务信息</param>
        /// <param name="name">任务组名称</param>
        public static IJobInfo Group( this IJobInfo source, string name ) {
            if ( source is QuartzJobInfo job )
                job.Group = name;
            return source;
        }

        /// <summary>
        /// 获取任务名称
        /// </summary>
        /// <param name="source">任务信息</param>
        public static string GetName( this IJobInfo source ) {
            if ( source is QuartzJobInfo job )
                return job.Name;
            return null;
        }

        /// <summary>
        /// 获取任务组名称
        /// </summary>
        /// <param name="source">任务信息</param>
        public static string GetGroup( this IJobInfo source ) {
            if ( source is QuartzJobInfo job )
                return job.Group;
            return null;
        }
    }
}
