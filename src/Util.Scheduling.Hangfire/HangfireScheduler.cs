using Hangfire;
using System.Threading.Tasks;

namespace Util.Scheduling {
    /// <summary>
    /// Hangfire调度器
    /// </summary>
    public class HangfireScheduler : IScheduler {
        /// <summary>
        /// Hangfire后台任务服务器
        /// </summary>
        private BackgroundJobServer _jobServer;
        /// <summary>
        /// 服务器配置
        /// </summary>
        private readonly BackgroundJobServerOptions _options;

        /// <summary>
        /// 初始化Hangfire调度器
        /// </summary>
        /// <param name="options">服务器配置</param>
        public HangfireScheduler( BackgroundJobServerOptions options ) {
            _options = options;
        }

        /// <inheritdoc />
        public Task StartAsync() {
            _jobServer = new BackgroundJobServer( _options );
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task StopAsync() {
            _jobServer.Dispose();
            return Task.CompletedTask;
        }
    }
}
