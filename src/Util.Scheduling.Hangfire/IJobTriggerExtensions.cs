using System;

namespace Util.Scheduling {
    /// <summary>
    /// Quartz任务触发器扩展
    /// </summary>
    public static class IJobTriggerExtensions {
        /// <summary>
        /// 设置延迟执行时间间隔
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="value">延迟执行时间间隔</param>
        public static IJobTrigger Delay( this IJobTrigger source, TimeSpan value ) {
            source.CheckNull( nameof( source ) );
            if ( source is HangfireTrigger trigger )
                trigger.Delay = value;
            return source;
        }

        /// <summary>
        /// 设置Cron表达式
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="cron">Cron表达式</param>
        public static IJobTrigger Cron( this IJobTrigger source, string cron ) {
            source.CheckNull( nameof( source ) );
            if ( source is HangfireTrigger trigger ) {
                trigger.Cron = cron;
            }
            return source;
        }

        /// <summary>
        /// 获取延迟执行时间间隔
        /// </summary>
        /// <param name="source">任务触发器</param>
        public static TimeSpan? GetDelay( this IJobTrigger source ) {
            source.CheckNull( nameof( source ) );
            if ( source is HangfireTrigger trigger )
                return trigger.Delay;
            return null;
        }

        /// <summary>
        /// 获取Cron表达式
        /// </summary>
        /// <param name="source">任务触发器</param>
        public static string GetCron( this IJobTrigger source ) {
            source.CheckNull( nameof( source ) );
            if ( source is HangfireTrigger trigger )
                return trigger.Cron;
            return null;
        }

        /// <summary>
        /// 设置每分钟重复执行
        /// </summary>
        /// <param name="source">任务触发器</param>
        public static IJobTrigger Minutely( this IJobTrigger source ) {
            source.CheckNull( nameof( source ) );
            if ( source is HangfireTrigger trigger )
                trigger.Cron = Hangfire.Cron.Minutely();
            return source;
        }

        /// <summary>
        /// 设置每小时重复执行
        /// </summary>
        /// <param name="source">任务触发器</param>
        public static IJobTrigger Hourly( this IJobTrigger source ) {
            return source.Hourly( 0 );
        }

        /// <summary>
        /// 设置每小时重复执行
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="minute">在几分执行</param>
        public static IJobTrigger Hourly( this IJobTrigger source, int minute ) {
            source.CheckNull( nameof( source ) );
            if ( source is HangfireTrigger trigger )
                trigger.Cron = Hangfire.Cron.Hourly( minute );
            return source;
        }

        /// <summary>
        /// 设置每天重复执行
        /// </summary>
        /// <param name="source">任务触发器</param>
        public static IJobTrigger Daily( this IJobTrigger source ) {
            return source.Daily( 0 );
        }

        /// <summary>
        /// 设置每天重复执行
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="hour">在几点执行</param>
        public static IJobTrigger Daily( this IJobTrigger source, int hour ) {
            return source.Daily( hour, 0 );
        }

        /// <summary>
        /// 设置每天重复执行
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="hour">在几点执行</param>
        /// <param name="minute">在几分执行</param>
        public static IJobTrigger Daily( this IJobTrigger source, int hour, int minute ) {
            source.CheckNull( nameof( source ) );
            if ( source is HangfireTrigger trigger )
                trigger.Cron = Hangfire.Cron.Daily( hour, minute );
            return source;
        }

        /// <summary>
        /// 设置每周重复执行
        /// </summary>
        /// <param name="source">任务触发器</param>
        public static IJobTrigger Weekly( this IJobTrigger source ) {
            return source.Weekly( DayOfWeek.Monday );
        }

        /// <summary>
        /// 设置每周重复执行
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="dayOfWeek">在星期几执行</param>
        public static IJobTrigger Weekly( this IJobTrigger source, DayOfWeek dayOfWeek ) {
            return source.Weekly( dayOfWeek, 0 );
        }

        /// <summary>
        /// 设置每周重复执行
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="dayOfWeek">在星期几执行</param>
        /// <param name="hour">在几点执行</param>
        public static IJobTrigger Weekly( this IJobTrigger source, DayOfWeek dayOfWeek, int hour ) {
            return source.Weekly( dayOfWeek, hour, 0 );
        }

        /// <summary>
        /// 设置每周重复执行
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="dayOfWeek">在星期几执行</param>
        /// <param name="hour">在几点执行</param>
        /// <param name="minute">在几分执行</param>
        public static IJobTrigger Weekly( this IJobTrigger source, DayOfWeek dayOfWeek, int hour, int minute ) {
            source.CheckNull( nameof( source ) );
            if ( source is HangfireTrigger trigger )
                trigger.Cron = Hangfire.Cron.Weekly( dayOfWeek, hour, minute );
            return source;
        }

        /// <summary>
        /// 设置每月重复执行
        /// </summary>
        /// <param name="source">任务触发器</param>
        public static IJobTrigger Monthly( this IJobTrigger source ) {
            return source.Monthly( 1 );
        }

        /// <summary>
        /// 设置每月重复执行
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="day">在第几天执行</param>
        public static IJobTrigger Monthly( this IJobTrigger source, int day ) {
            return source.Monthly( day, 0 );
        }

        /// <summary>
        /// 设置每月重复执行
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="day">在第几天执行</param>
        /// <param name="hour">在几点执行</param>
        public static IJobTrigger Monthly( this IJobTrigger source, int day, int hour ) {
            return source.Monthly( day, hour, 0 );
        }

        /// <summary>
        /// 设置每月重复执行
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="day">在第几天执行</param>
        /// <param name="hour">在几点执行</param>
        /// <param name="minute">在几分执行</param>
        public static IJobTrigger Monthly( this IJobTrigger source, int day, int hour, int minute ) {
            source.CheckNull( nameof( source ) );
            if ( source is HangfireTrigger trigger )
                trigger.Cron = Hangfire.Cron.Monthly( day, hour, minute );
            return source;
        }

        /// <summary>
        /// 设置每年重复执行
        /// </summary>
        /// <param name="source">任务触发器</param>
        public static IJobTrigger Yearly( this IJobTrigger source ) {
            return source.Yearly( 1 );
        }

        /// <summary>
        /// 设置每年重复执行
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="month">在几月执行</param>
        public static IJobTrigger Yearly( this IJobTrigger source, int month ) {
            return source.Yearly( month,1 );
        }

        /// <summary>
        /// 设置每年重复执行
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="month">在几月执行</param>
        /// <param name="day">在第几天执行</param>
        public static IJobTrigger Yearly( this IJobTrigger source, int month, int day ) {
            return source.Yearly( month, day,0 );
        }

        /// <summary>
        /// 设置每年重复执行
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="month">在几月执行</param>
        /// <param name="day">在第几天执行</param>
        /// <param name="hour">在几点执行</param>
        public static IJobTrigger Yearly( this IJobTrigger source, int month, int day, int hour ) {
            return source.Yearly( month, day, hour, 0 );
        }

        /// <summary>
        /// 设置每年重复执行
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="month">在几月执行</param>
        /// <param name="day">在第几天执行</param>
        /// <param name="hour">在几点执行</param>
        /// <param name="minute">在几分执行</param>
        public static IJobTrigger Yearly( this IJobTrigger source, int month, int day, int hour, int minute ) {
            source.CheckNull( nameof( source ) );
            if ( source is HangfireTrigger trigger )
                trigger.Cron = Hangfire.Cron.Yearly( month, day, hour, minute );
            return source;
        }
    }
}
