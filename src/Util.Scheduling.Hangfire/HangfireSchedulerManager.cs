using System.Threading.Tasks;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Util.Reflections;

namespace Util.Scheduling {
    /// <summary>
    /// Hangfire调度管理器
    /// </summary>
    public class HangfireSchedulerManager : SchedulerManagerBase {
        /// <summary>
        /// 服务器配置
        /// </summary>
        private readonly BackgroundJobServerOptions _serverOptions;

        /// <summary>
        /// 初始化Hangfire调度管理器
        /// </summary>
        /// <param name="scopeFactory">服务范围工厂</param>
        /// <param name="typeFinder">类型查找器</param>
        /// <param name="serverOptions">服务器配置</param>
        public HangfireSchedulerManager( IServiceScopeFactory scopeFactory, ITypeFinder typeFinder,
            IOptions<BackgroundJobServerOptions> serverOptions ) : base( scopeFactory, typeFinder ) {
            _serverOptions = serverOptions.Value;
        }

        /// <inheritdoc />
        public override Task AddJobAsync( IJob job ) {
            if ( job == null )
                return Task.CompletedTask;
            job.Config();
            ScheduleJob( job as JobBase );
            return Task.CompletedTask;
        }

        /// <summary>
        /// 调度任务
        /// </summary>
        private void ScheduleJob( JobBase job ) {
            if ( job == null )
                return;
            var jobInfo = job.GetJobInfo();
            var trigger = job.GetTrigger();
            if ( trigger.GetCron().IsEmpty() == false ) {
                var id = jobInfo.GetId();
                if( id.IsEmpty() )
                    RecurringJob.AddOrUpdate( () => job.Execute( job.Data ), trigger.GetCron(),queue:jobInfo.GetQueue() );
                else 
                    RecurringJob.AddOrUpdate( id, () => job.Execute( job.Data ), trigger.GetCron(), queue: jobInfo.GetQueue() );
                return;
            }
            if ( trigger.GetDelay() != null ) {
                BackgroundJob.Schedule( () => job.Execute( job.Data ), trigger.GetDelay().SafeValue() );
                return;
            }
            BackgroundJob.Enqueue( () => job.Execute( job.Data ) );
        }

        /// <inheritdoc />
        public override Task<IScheduler> GetSchedulerAsync() {
            return Task.FromResult( (IScheduler)new HangfireScheduler(_serverOptions) );
        }
    }
}
