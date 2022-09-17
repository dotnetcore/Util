using Quartz;
using System;

namespace Util.Scheduling {
    /// <summary>
    /// Quartz任务触发器扩展
    /// </summary>
    public static class IJobTriggerExtensions {
        /// <summary>
        /// 设置触发器名称
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="name">触发器名称</param>
        public static IJobTrigger Name( this IJobTrigger source, string name ) {
            if ( source is QuartzTrigger trigger )
                trigger.Name = name;
            return source;
        }

        /// <summary>
        /// 设置触发器组名称
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="name">触发器组名称</param>
        public static IJobTrigger Group( this IJobTrigger source, string name ) {
            if ( source is QuartzTrigger trigger )
                trigger.Group = name;
            return source;
        }

        /// <summary>
        /// 设置重复执行次数
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="value">重复执行次数,设置为null，表示持续重复执行</param>
        public static IJobTrigger RepeatCount( this IJobTrigger source, int? value ) {
            if ( source is QuartzTrigger trigger )
                trigger.RepeatCount = value;
            return source;
        }

        /// <summary>
        /// 设置重复执行时间间隔
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="value">重复执行时间间隔</param>
        public static IJobTrigger Interval( this IJobTrigger source, TimeSpan value ) {
            if ( source is QuartzTrigger trigger )
                trigger.Interval = value;
            return source;
        }

        /// <summary>
        /// 设置重复执行时间间隔
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="value">重复执行时间间隔，单位：小时</param>
        public static IJobTrigger IntervalInHours( this IJobTrigger source, int value ) {
            if ( source is QuartzTrigger trigger )
                trigger.IntervalInHours = value;
            return source;
        }

        /// <summary>
        /// 设置重复执行时间间隔
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="value">重复执行时间间隔，单位：分</param>
        public static IJobTrigger IntervalInMinutes( this IJobTrigger source, int value ) {
            if ( source is QuartzTrigger trigger )
                trigger.IntervalInMinutes = value;
            return source;
        }

        /// <summary>
        /// 设置重复执行时间间隔
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="value">重复执行时间间隔，单位：秒</param>
        public static IJobTrigger IntervalInSeconds( this IJobTrigger source, int value ) {
            if ( source is QuartzTrigger trigger )
                trigger.IntervalInSeconds = value;
            return source;
        }

        /// <summary>
        /// 设置执行起始时间
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="value">执行起始时间</param>
        public static IJobTrigger StartTime( this IJobTrigger source, DateTimeOffset value ) {
            if ( source is QuartzTrigger trigger )
                trigger.StartTime = value;
            return source;
        }

        /// <summary>
        /// 设置执行结束时间
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="value">执行结束时间</param>
        public static IJobTrigger EndTime( this IJobTrigger source, DateTimeOffset value ) {
            if ( source is QuartzTrigger trigger )
                trigger.EndTime = value;
            return source;
        }

        /// <summary>
        /// 设置Cron表达式
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="cron">Cron表达式</param>
        public static IJobTrigger Cron( this IJobTrigger source, string cron ) {
            if ( source is QuartzTrigger trigger ) {
                trigger.Cron = cron;
            }
            return source;
        }

        /// <summary>
        /// 设置Cron表达式
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="cron">Cron表达式</param>
        /// <param name="action">Cron表达式配置操作</param>
        public static IJobTrigger Cron( this IJobTrigger source, string cron, Action<CronScheduleBuilder> action ) {
            if ( source is QuartzTrigger trigger ) {
                trigger.Cron = cron;
                trigger.CronScheduleAction = action;
            }
            return source;
        }

        /// <summary>
        /// 设置每分钟重复执行
        /// </summary>
        /// <param name="source">任务触发器</param>
        public static IJobTrigger Minutely( this IJobTrigger source ) {
            return source.Minutely( 0 );
        }

        /// <summary>
        /// 设置每分钟重复执行
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="second">在第几秒执行</param>
        public static IJobTrigger Minutely( this IJobTrigger source, int second ) {
            source.CheckNull( nameof( source ) );
            if ( source is QuartzTrigger trigger )
                trigger.Cron = CronHelper.Minutely( second );
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
        /// <param name="minute">在第几分执行</param>
        public static IJobTrigger Hourly( this IJobTrigger source, int minute ) {
            return source.Hourly( minute, 0 );
        }

        /// <summary>
        /// 设置每小时重复执行
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="minute">在第几分执行</param>
        /// <param name="second">在第几秒执行</param>
        public static IJobTrigger Hourly( this IJobTrigger source, int minute, int second ) {
            source.CheckNull( nameof( source ) );
            if ( source is QuartzTrigger trigger )
                trigger.Cron = CronHelper.Hourly( minute, second );
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
        /// <param name="minute">在第几分执行</param>
        public static IJobTrigger Daily( this IJobTrigger source, int hour, int minute ) {
            return source.Daily( hour, minute, 0 );
        }

        /// <summary>
        /// 设置每天重复执行
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="hour">在几点执行</param>
        /// <param name="minute">在第几分执行</param>
        /// <param name="second">在第几秒执行</param>
        public static IJobTrigger Daily( this IJobTrigger source, int hour, int minute, int second ) {
            source.CheckNull( nameof( source ) );
            if ( source is QuartzTrigger trigger )
                trigger.Cron = CronHelper.Daily( hour, minute, second );
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
        /// <param name="minute">在第几分执行</param>
        public static IJobTrigger Weekly( this IJobTrigger source, DayOfWeek dayOfWeek, int hour, int minute ) {
            return source.Weekly( dayOfWeek, hour, minute, 0 );
        }

        /// <summary>
        /// 设置每周重复执行
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="dayOfWeek">在星期几执行</param>
        /// <param name="hour">在几点执行</param>
        /// <param name="minute">在第几分执行</param>
        /// <param name="second">在第几秒执行</param>
        public static IJobTrigger Weekly( this IJobTrigger source, DayOfWeek dayOfWeek, int hour, int minute, int second ) {
            source.CheckNull( nameof( source ) );
            if ( source is QuartzTrigger trigger )
                trigger.Cron = CronHelper.Weekly( dayOfWeek, hour, minute, second );
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
        /// <param name="minute">在第几分执行</param>
        public static IJobTrigger Monthly( this IJobTrigger source, int day, int hour, int minute ) {
            return source.Monthly( day, hour, minute, 0 );
        }

        /// <summary>
        /// 设置每月重复执行
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="day">在第几天执行</param>
        /// <param name="hour">在几点执行</param>
        /// <param name="minute">在第几分执行</param>
        /// <param name="second">在第几秒执行</param>
        public static IJobTrigger Monthly( this IJobTrigger source, int day, int hour, int minute, int second ) {
            source.CheckNull( nameof( source ) );
            if ( source is QuartzTrigger trigger )
                trigger.Cron = CronHelper.Monthly( day, hour, minute, second );
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
            return source.Yearly( month, 1 );
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
        /// <param name="minute">在第几分执行</param>
        public static IJobTrigger Yearly( this IJobTrigger source, int month, int day, int hour, int minute ) {
            return source.Yearly( month, day, hour, minute, 0 );
        }

        /// <summary>
        /// 设置每年重复执行
        /// </summary>
        /// <param name="source">任务触发器</param>
        /// <param name="month">在几月执行</param>
        /// <param name="day">在第几天执行</param>
        /// <param name="hour">在几点执行</param>
        /// <param name="minute">在第几分执行</param>
        /// <param name="second">在第几秒执行</param>
        public static IJobTrigger Yearly( this IJobTrigger source, int month, int day, int hour, int minute, int second ) {
            source.CheckNull( nameof( source ) );
            if ( source is QuartzTrigger trigger )
                trigger.Cron = CronHelper.Yearly( month, day, hour, minute, second );
            return source;
        }
    }
}
