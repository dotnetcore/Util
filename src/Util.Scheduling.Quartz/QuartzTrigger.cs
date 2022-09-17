using Quartz;
using System;

namespace Util.Scheduling {
    /// <summary>
    /// Quartz触发器
    /// </summary>
    public class QuartzTrigger : IJobTrigger {
        /// <summary>
        /// 触发器名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 触发器组名称
        /// </summary>
        public string Group { get; set; }
        /// <summary>
        /// 重复执行次数，默认返回null，表示持续重复执行
        /// </summary>
        public int? RepeatCount { get; set; }
        /// <summary>
        /// 重复执行时间间隔
        /// </summary>
        public TimeSpan? Interval { get; set; }
        /// <summary>
        /// 重复执行时间间隔，单位：小时
        /// </summary>
        public int? IntervalInHours { get; set; }
        /// <summary>
        /// 重复执行时间间隔，单位：分
        /// </summary>
        public int? IntervalInMinutes { get; set; }
        /// <summary>
        /// 重复执行时间间隔，单位：秒
        /// </summary>
        public int? IntervalInSeconds { get; set; }
        /// <summary>
        /// 执行起始时间
        /// </summary>
        public DateTimeOffset? StartTime { get; set; }
        /// <summary>
        /// 执行结束时间
        /// </summary>
        public DateTimeOffset? EndTime { get; set; }
        /// <summary>
        /// Cron表达式
        /// </summary>
        public string Cron { get; set; }
        /// <summary>
        /// Cron表达式配置操作
        /// </summary>
        public Action<CronScheduleBuilder> CronScheduleAction { get; set; }

        /// <summary>
        /// 转换为Quartz触发器
        /// </summary>
        public ITrigger ToTrigger() {
            Init();
            var build = TriggerBuilder.Create()
                .WithIdentity( Name, Group )
                .WithSimpleSchedule( simpleScheduleBuilder => {
                    SetRepeatCount( simpleScheduleBuilder );
                    SetInterval( simpleScheduleBuilder );
                } );
            SetStartTime( build );
            SetEndTime( build );
            SetCron( build );
            return build.Build();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init() {
            if ( Interval == null && IntervalInHours == null && IntervalInMinutes == null && IntervalInSeconds == null && Cron.IsEmpty() )
                IntervalInMinutes = 1;
        }

        /// <summary>
        /// 设置重复执行次数
        /// </summary>
        private void SetRepeatCount( SimpleScheduleBuilder builder ) {
            if ( RepeatCount == null ) {
                builder.RepeatForever();
                return;
            }
            builder.WithRepeatCount( RepeatCount.Value );
        }

        /// <summary>
        /// 设置重复执行时间间隔
        /// </summary>
        private void SetInterval( SimpleScheduleBuilder builder ) {
            if ( Interval != null )
                builder.WithInterval( Interval.Value );
            if ( IntervalInHours != null )
                builder.WithIntervalInHours( IntervalInHours.Value );
            if ( IntervalInMinutes != null )
                builder.WithIntervalInMinutes( IntervalInMinutes.Value );
            if ( IntervalInSeconds != null )
                builder.WithIntervalInSeconds( IntervalInSeconds.Value );
        }

        /// <summary>
        /// 设置执行起始时间
        /// </summary>
        private void SetStartTime( TriggerBuilder builder ) {
            if ( StartTime == null ) {
                builder.StartNow();
                return;
            }
            builder.StartAt( StartTime.Value );
        }

        /// <summary>
        /// 设置执行结束时间
        /// </summary>
        private void SetEndTime( TriggerBuilder builder ) {
            if ( EndTime == null )
                return;
            builder.EndAt( EndTime.Value );
        }

        /// <summary>
        /// 设置Cron表达式
        /// </summary>
        private void SetCron( TriggerBuilder builder ) {
            if ( Cron == null )
                return;
            if ( CronScheduleAction == null ) {
                builder.WithCronSchedule( Cron );
                return;
            }
            builder.WithCronSchedule( Cron, CronScheduleAction );
        }
    }
}
