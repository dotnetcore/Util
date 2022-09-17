using System.Threading.Tasks;

namespace Util.Scheduling {
    /// <summary>
    /// 后台任务调度器
    /// </summary>
    public interface IScheduler {
        /// <summary>
        /// 启动
        /// </summary>
        Task StartAsync();
        /// <summary>
        /// 停止
        /// </summary>
        Task StopAsync();
    }
}
