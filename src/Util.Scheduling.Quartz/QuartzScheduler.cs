using System;
using System.Threading.Tasks;

namespace Util.Scheduling {
    /// <summary>
    /// Quartz调度器
    /// </summary>
    public class QuartzScheduler : IScheduler {
        /// <summary>
        /// Quartz调度器
        /// </summary>
        private readonly Quartz.IScheduler _scheduler;

        /// <summary>
        /// 初始化Quartz调度器
        /// </summary>
        /// <param name="scheduler">Quartz调度器</param>
        public QuartzScheduler( Quartz.IScheduler scheduler ) {
            _scheduler = scheduler ?? throw new ArgumentNullException(nameof(scheduler));
        }

        /// <inheritdoc />
        public async Task StartAsync() {
            if ( _scheduler.IsStarted )
                return;
            await _scheduler.Start();
        }

        /// <summary>
        /// 暂停
        /// </summary>
        public async Task PauseAsync() {
            await _scheduler.PauseAll();
        }

        /// <summary>
        /// 恢复
        /// </summary>
        public async Task ResumeAsync() {
            await _scheduler.ResumeAll();
        }

        /// <inheritdoc />
        public async Task StopAsync() {
            if ( _scheduler.IsShutdown )
                return;
            await _scheduler.Shutdown( true );
        }
    }
}
