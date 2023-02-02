using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Util.Scheduling {
    /// <summary>
    /// 托管服务
    /// </summary>
    public class HostService : IHostedService {
        /// <summary>
        /// 调度管理器
        /// </summary>
        private readonly ISchedulerManager _manager;
        /// <summary>
        /// 调度器配置
        /// </summary>
        private readonly SchedulerOptions _options;
        /// <summary>
        /// 调度器
        /// </summary>
        private IScheduler _scheduler;

        /// <summary>
        /// 初始化托管服务
        /// </summary>
        /// <param name="manager">调度管理器</param>
        /// <param name="options">调度器配置</param>
        public HostService( ISchedulerManager manager, IOptions<SchedulerOptions> options ) {
            _manager = manager ?? throw new ArgumentNullException( nameof( manager ) );
            _options = options?.Value ?? new SchedulerOptions();
            _scheduler = NullScheduler.Instance;
        }

        /// <summary>
        /// 启动服务
        /// </summary>
        public async Task StartAsync( CancellationToken cancellationToken ) {
            await _manager.ScanJobsAsync( _options.IsScanJobs );
            _scheduler = await _manager.GetSchedulerAsync();
            await _scheduler.StartAsync();
        }

        /// <summary>
        /// 停止服务
        /// </summary>
        public async Task StopAsync( CancellationToken cancellationToken ) {
            await _scheduler.StopAsync();
        }
    }
}
