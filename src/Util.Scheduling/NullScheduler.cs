using System.Threading.Tasks;

namespace Util.Scheduling {
    /// <summary>
    /// 空后台任务调度器
    /// </summary>
    public class NullScheduler : IScheduler {
        /// <summary>
        /// 空调度器实例
        /// </summary>
        public static readonly IScheduler Instance = new NullScheduler();

        /// <summary>
        /// 启动
        /// </summary>
        public Task StartAsync() {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 暂停
        /// </summary>
        public Task PauseAsync() {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 恢复
        /// </summary>
        public Task ResumeAsync() {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 停止
        /// </summary>
        public Task StopAsync() {
            return Task.CompletedTask;
        }
    }
}
