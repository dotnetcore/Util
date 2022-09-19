using System.Threading.Tasks;
using Util.Helpers;

namespace Util.Scheduling {
    /// <summary>
    /// 任务
    /// </summary>
    public abstract class JobBase : IJob {
        /// <summary>
        /// 任务信息
        /// </summary>
        private IJobInfo _jobInfo;
        /// <summary>
        /// 触发器
        /// </summary>
        private IJobTrigger _trigger;
        /// <summary>
        /// 任务标识
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 参数
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 配置
        /// </summary>
        public void Config() {
            _jobInfo = new HangfireJobInfo();
            _trigger = new HangfireTrigger();
            ConfigId( _jobInfo );
            ConfigDetail( _jobInfo );
            ConfigTrigger( _trigger );
        }

        /// <summary>
        /// 配置任务标识
        /// </summary>
        protected virtual void ConfigId( IJobInfo job ) {
            if ( Id.IsEmpty() )
                return;
            job.Id( Id );
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
        /// 执行任务
        /// </summary>
        /// <param name="data">参数</param>
        public virtual async Task Execute( object data ) {
            using var scope = Ioc.ServiceScopeFactory.CreateScope();
            await Execute( new HangfireExecutionContext( scope.ServiceProvider, data ) );
        }

        /// <summary>
        /// 执行任务
        /// </summary>
        /// <param name="context">执行上下文</param>
        protected abstract Task Execute( HangfireExecutionContext context );

        /// <summary>
        /// 获取任务信息
        /// </summary>
        public IJobInfo GetJobInfo() {
            return _jobInfo;
        }

        /// <summary>
        /// 获取触发器
        /// </summary>
        public IJobTrigger GetTrigger() {
            return _trigger;
        }
    }
}
