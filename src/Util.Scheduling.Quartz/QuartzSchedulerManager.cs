using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Util.Helpers;
using Util.Reflections;

namespace Util.Scheduling {
    /// <summary>
    /// Quartz调度管理器
    /// </summary>
    public class QuartzSchedulerManager : ISchedulerManager {
        /// <summary>
        /// 类型查找器
        /// </summary>
        private readonly ITypeFinder _typeFinder;
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
        public QuartzSchedulerManager( IServiceScopeFactory scopeFactory, ITypeFinder typeFinder, ISchedulerFactory factory ) {
            Ioc.ServiceScopeFactory = scopeFactory ?? throw new ArgumentNullException( nameof( scopeFactory ) );
            _typeFinder = typeFinder ?? throw new ArgumentNullException( nameof( typeFinder ) );
            _factory = factory ?? throw new ArgumentNullException( nameof( factory ) );
        }

        /// <inheritdoc />
        public async Task AddJobAsync<TJob>() where TJob : IJob, new() {
            await AddJobAsync( new TJob() );
        }

        /// <inheritdoc />
        public async Task AddJobAsync( IJob job ) {
            if ( job == null )
                return;
            job.Config();
            var scheduler = await _factory.GetScheduler();
            await scheduler.ScheduleJob( job.GetDetail(), job.GetTrigger() );
        }

        /// <inheritdoc />
        public async Task ScanJobsAsync() {
            var types = _typeFinder.Find<IJob>();
            foreach ( var type in types ) {
                var job = Reflection.CreateInstance<IJob>( type );
                if ( job == null )
                    continue;
                await AddJobAsync( job );
            }
        }

        /// <inheritdoc />
        public async Task<IScheduler> GetSchedulerAsync() {
            var scheduler = await _factory.GetScheduler();
            return new QuartzScheduler( scheduler );
        }
    }
}
