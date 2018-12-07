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
    }
}
