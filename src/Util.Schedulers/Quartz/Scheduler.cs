using System;
using System.Reflection;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using Util.Helpers;
using Util.Reflections;
using Qz = Quartz;

namespace Util.Schedulers.Quartz {
    /// <summary>
    /// Quartz调度器
    /// </summary>
    public class Scheduler : IScheduler {
        /// <summary>
        /// Quartz调度器
        /// </summary>
        private Qz.IScheduler _scheduler;

        /// <summary>
        /// 启动
        /// </summary>
        public async Task StartAsync() {
            _scheduler = await GetScheduler();
            if( _scheduler.IsStarted )
                return;
            await _scheduler.Start();
        }

        /// <summary>
        /// 获取调度器
        /// </summary>
        private async Task<Qz.IScheduler> GetScheduler() {
            if( _scheduler != null )
                return _scheduler;
            var factory = new StdSchedulerFactory();
            return await factory.GetScheduler();
        }

        /// <summary>
        /// 暂停
        /// </summary>
        public async Task PauseAsync() {
            if( _scheduler == null )
                return;
            await _scheduler.PauseAll();
        }

        /// <summary>
        /// 恢复
        /// </summary>
        public async Task ResumeAsync() {
            if( _scheduler == null )
                return;
            await _scheduler.ResumeAll();
        }

        /// <summary>
        /// 停止
        /// </summary>
        public async Task StopAsync() {
            if( _scheduler == null )
                return;
            if( _scheduler.IsShutdown )
                return;
            await _scheduler.Shutdown( true );
        }

        /// <summary>
        /// 扫描并添加作业
        /// </summary>
        /// <param name="assemblies">程序集列表</param>
        public async Task ScanJobsAsync( params Assembly[] assemblies ) {
            assemblies = GetAssemblies( assemblies );
            var jobs = Reflection.GetInstancesByInterface<IJob>( assemblies );
            if ( jobs == null )
                return;
            foreach ( var job in jobs )
                await AddJobAsync( job );
        }

        /// <summary>
        /// 获取程序集列表
        /// </summary>
        private Assembly[] GetAssemblies( Assembly[] assemblies ) {
            if ( assemblies != null && assemblies.Length > 0 )
                return assemblies;
            var finder = Ioc.Create<IFind>();
            return finder?.GetAssemblies().ToArray();
        }

        /// <summary>
        /// 添加作业
        /// </summary>
        public async Task AddJobAsync<TJob>() where TJob : IJob, new() {
            await AddJobAsync( new TJob() );
        }

        /// <summary>
        /// 添加作业
        /// </summary>
        /// <param name="job">作业</param>
        public async Task AddJobAsync( IJob job ) {
            if( !( job is JobBase quartzJob ) )
                throw new InvalidOperationException( "Quartz调度器必须从Util.Schedulers.Quartz.JobBase派生" );
            var jobDetail = CreateJob( quartzJob );
            var trigger = CreateTrigger( quartzJob );
            await AddJobAsync( jobDetail, trigger );
        }

        /// <summary>
        /// 创建作业
        /// </summary>
        private IJobDetail CreateJob( JobBase job ) {
            return JobBuilder.Create( job.GetType() )
                .WithIdentity( job.GetJobName(), job.GetGroupName() )
                .Build();
        }

        /// <summary>
        /// 创建触发器
        /// </summary>
        private ITrigger CreateTrigger( JobBase job ) {
            var builder = TriggerBuilder.Create()
                .WithIdentity( job.GetTriggerName(), job.GetGroupName() )
                .WithSimpleSchedule( scheduleBuilder => Schedule( scheduleBuilder, job ) );
            SetStartTime( builder, job );
            SetEndTime( builder, job );
            SetCron( builder, job );
            return builder.Build();
        }

        /// <summary>
        /// 设置调度策略
        /// </summary>
        private void Schedule( SimpleScheduleBuilder builder, JobBase job ) {
            SetRepeatCount( builder, job );
            if( job.GetInterval() != null )
                builder.WithInterval( job.GetInterval().SafeValue() );
            if( job.GetIntervalInHours() != null )
                builder.WithIntervalInHours( job.GetIntervalInHours().SafeValue() );
            if( job.GetIntervalInMinutes() != null )
                builder.WithIntervalInMinutes( job.GetIntervalInMinutes().SafeValue() );
            if( job.GetIntervalInSeconds() != null )
                builder.WithIntervalInSeconds( job.GetIntervalInSeconds().SafeValue() );
        }

        /// <summary>
        /// 设置重复执行次数
        /// </summary>
        private void SetRepeatCount( SimpleScheduleBuilder builder, JobBase job ) {
            if ( job.GetRepeatCount() == null ) {
                builder.RepeatForever();
                return;
            }
            builder.WithRepeatCount( job.GetRepeatCount().SafeValue() );
        }

        /// <summary>
        /// 设置作业开始时间
        /// </summary>
        private void SetStartTime( TriggerBuilder builder, JobBase job ) {
            if ( job.GetStartTime() == null ) {
                builder.StartNow();
                return;
            }
            builder.StartAt( job.GetStartTime().SafeValue() );
        }

        /// <summary>
        /// 设置作业结束时间
        /// </summary>
        private void SetEndTime( TriggerBuilder builder, JobBase job ) {
            if( job.GetEndTime() == null )
                return;
            builder.EndAt( job.GetEndTime().SafeValue() );
        }

        /// <summary>
        /// 设置Cron表达式
        /// </summary>
        private void SetCron( TriggerBuilder builder, JobBase job ) {
            if( job.GetCron() == null )
                return;
            builder.WithCronSchedule( job.GetCron() );
        }

        /// <summary>
        /// 添加作业
        /// </summary>
        /// <typeparam name="TJob">作业类型</typeparam>
        /// <param name="configureJob">作业配置操作</param>
        /// <param name="configureTrigger">触发器配置操作</param>
        public async Task AddJobAsync<TJob>( Action<JobBuilder> configureJob, Action<TriggerBuilder> configureTrigger ) where TJob : Qz.IScheduler {
            var jobBuilder = JobBuilder.Create( typeof( TJob ) );
            configureJob( jobBuilder );
            var job = jobBuilder.Build();
            var triggerBuilder = TriggerBuilder.Create();
            configureTrigger( triggerBuilder );
            var trigger = triggerBuilder.Build();
            await AddJobAsync( job, trigger );
        }

        /// <summary>
        /// 添加作业
        /// </summary>
        /// <param name="job">作业</param>
        /// <param name="trigger">触发器</param>
        public async Task AddJobAsync( IJobDetail job, ITrigger trigger ) {
            _scheduler = await GetScheduler();
            await _scheduler.ScheduleJob( job, trigger );
        }
    }
}
