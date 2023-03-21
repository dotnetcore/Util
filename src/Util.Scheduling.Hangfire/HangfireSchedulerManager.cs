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
        public override Task<string> AddJobAsync( IJob job ) {
            if ( job == null )
                return null;
            job.Config();
            var result = ScheduleJob( job as JobBase );
            return Task.FromResult( result );
        }

        /// <summary>
        /// 调度任务
        /// </summary>
        private string ScheduleJob( JobBase job ) {
            if ( job == null )
                return null;
            var jobInfo = job.GetJobInfo();
            var trigger = job.GetTrigger();
            if ( trigger.GetCron().IsEmpty() == false ) {
                var id = jobInfo.GetId();
                if( id.IsEmpty() )
                    RecurringJob.AddOrUpdate( () => job.Execute( job.Data ), trigger.GetCron(),queue:jobInfo.GetQueue() );
                else 
                    RecurringJob.AddOrUpdate( id, () => job.Execute( job.Data ), trigger.GetCron(), queue: jobInfo.GetQueue() );
                return id;
            }
            return trigger.GetDelay() == null ? BackgroundJob.Enqueue( () => job.Execute( job.Data ) ) : BackgroundJob.Schedule( () => job.Execute( job.Data ), trigger.GetDelay().SafeValue() );
        }

        /// <inheritdoc />
        public override Task<IScheduler> GetSchedulerAsync() {
            return Task.FromResult( (IScheduler)new HangfireScheduler(_serverOptions) );
        }
    }
}
