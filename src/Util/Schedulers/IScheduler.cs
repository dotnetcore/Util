using System.Reflection;
using System.Threading.Tasks;

namespace Util.Schedulers {
    /// <summary>
    /// 调度器
    /// </summary>
    public interface IScheduler {
        /// <summary>
        /// 启动
        /// </summary>
        Task StartAsync();
        /// <summary>
        /// 暂停
        /// </summary>
        Task PauseAsync();
        /// <summary>
        /// 恢复
        /// </summary>
        Task ResumeAsync();
        /// <summary>
        /// 停止
        /// </summary>
        Task StopAsync();
        /// <summary>
        /// 添加作业
        /// </summary>
        /// <typeparam name="TJob">作业类型</typeparam>
        Task AddJobAsync<TJob>() where TJob : IJob, new();
        /// <summary>
        /// 扫描并添加作业
        /// </summary>
        /// <param name="assemblies">程序集列表</param>
        Task ScanJobsAsync( params Assembly[] assemblies );
    }
}
