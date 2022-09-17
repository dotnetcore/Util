using Quartz;
using System.Threading.Tasks;
using Util.Helpers;

namespace Util.Scheduling {
    /// <summary>
    /// 任务
    /// </summary>
    public abstract class JobBase : IJob, Quartz.IJob {
        /// <summary>
        /// 参数键名
        /// </summary>
        public const string DataKey = "Util_Job_Data";
        /// <summary>
        /// 任务信息
        /// </summary>
        private IJobDetail _jobDetail;
        /// <summary>
        /// 触发器
        /// </summary>
        private ITrigger _trigger;

        /// <summary>
        /// 参数
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 配置
        /// </summary>
        public void Config() {
            var jobInfo = new QuartzJobInfo();
            var trigger = new QuartzTrigger();
            ConfigDetail( jobInfo );
            ConfigTrigger( trigger );
            _jobDetail = CreateJobDetail( jobInfo );
            _trigger = trigger.ToTrigger();
            Config( _jobDetail, _trigger );
        }

        /// <summary>
        /// 配置任务信息
        /// </summary>
        protected virtual void ConfigDetail( IJobInfo job ) {
        }

        /// <summary>
        /// 配置触发器
        /// </summary>
        protected virtual void ConfigTrigger( IJobTrigger trigger ) {
        }

        /// <summary>
        /// 创建任务信息
        /// </summary>
        private IJobDetail CreateJobDetail( IJobInfo job ) {
            var builder = JobBuilder.Create( GetType() )
                .WithIdentity( job.GetName(), job.GetGroup() );
            if ( Data != null )
                builder.UsingJobData( DataKey, Util.Helpers.Json.ToJson( Data ) );
            return builder.Build();
        }

        /// <summary>
        /// 配置任务
        /// </summary>
        /// <param name="jobDetail">任务信息</param>
        /// <param name="trigger">任务触发器</param>
        protected virtual void Config( IJobDetail jobDetail, ITrigger trigger ) {
        }

        /// <summary>
        /// 执行任务
        /// </summary>
        /// <param name="context">执行上下文</param>
        public async Task Execute( IJobExecutionContext context ) {
            using var scope = Ioc.ServiceScopeFactory.CreateScope();
            await Execute( new QuartzExecutionContext( scope.ServiceProvider, context ) );
        }

        /// <summary>
        /// 执行任务
        /// </summary>
        /// <param name="context">执行上下文</param>
        protected abstract Task Execute( QuartzExecutionContext context );

        /// <summary>
        /// 获取任务信息
        /// </summary>
        public IJobDetail GetJobDetail() {
            return _jobDetail;
        }

        /// <summary>
        /// 获取触发器
        /// </summary>
        public ITrigger GetTrigger() {
            return _trigger;
        }
    }
}
