using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Util.Reflections;

namespace Util.Scheduling {
    /// <summary>
    /// Quartz调度管理器
    /// </summary>
    public class QuartzSchedulerManager : SchedulerManagerBase {
        /// <summary>
        /// Quartz调度器工厂
        /// </summary>
        private readonly ISchedulerFactory _factory;

        /// <summary>
        /// 初始化Quartz调度管理器
        /// </summary>
        /// <param name="scopeFactory">服务范围工厂</param>
        /// <param name="typeFinder">类型查找器</param>
        /// <param name="factory">Quartz调度器工厂</param>
        public QuartzSchedulerManager( IServiceScopeFactory scopeFactory, ITypeFinder typeFinder, ISchedulerFactory factory )
            : base( scopeFactory, typeFinder ) {
            _factory = factory ?? throw new ArgumentNullException( nameof( factory ) );
        }

        /// <inheritdoc />
        public override async Task<string> AddJobAsync( IJob job ) {
            if ( job == null )
                return null;
            job.Config();
            var scheduler = await _factory.GetScheduler();
            var detail = job.GetDetail();
            await scheduler.ScheduleJob( detail, job.GetTrigger() );
            return null;
        }

        /// <inheritdoc />
        public override async Task<IScheduler> GetSchedulerAsync() {
            var scheduler = await _factory.GetScheduler();
            return new QuartzScheduler( scheduler );
        }
    }
}
