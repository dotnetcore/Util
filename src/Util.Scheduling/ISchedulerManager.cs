using System.Threading.Tasks;

namespace Util.Scheduling {
    /// <summary>
    /// 后台任务调度管理器
    /// </summary>
    public interface ISchedulerManager {
        /// <summary>
        /// 添加任务
        /// </summary>
        /// <typeparam name="TJob">任务类型</typeparam>
        Task<string> AddJobAsync<TJob>() where TJob : IJob, new();
        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="job">任务</param>
        Task<string> AddJobAsync( IJob job );
        /// <summary>
        /// 扫描添加任务
        /// </summary>
        /// <param name="isScanAllJobs">是否扫描所有任务</param>
        Task ScanJobsAsync( bool isScanAllJobs = true );
        /// <summary>
        /// 获取后台任务调度器
        /// </summary>
        Task<IScheduler> GetSchedulerAsync();
    }
}
