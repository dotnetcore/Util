using System;

namespace Util.Scheduling {
    /// <summary>
    /// Cron表达式操作
    /// </summary>
    public static class CronHelper {
        /// <summary>
        /// 每分钟重复执行
        /// </summary>
        /// <param name="second">在第几秒执行</param>
        public static string Minutely( int second ) {
            return $"{second} * * * * ? *";
        }

        /// <summary>
        /// 每小时重复执行
        /// </summary>
        /// <param name="minute">在第几分执行</param>
        /// <param name="second">在第几秒执行</param>
        public static string Hourly( int minute, int second ) {
            return $"{second} {minute} * * * ? *";
        }

        /// <summary>
        /// 每天重复执行
        /// </summary>
        /// <param name="hour">在几点执行</param>
        /// <param name="minute">在第几分执行</param>
        /// <param name="second">在第几秒执行</param>
        public static string Daily( int hour, int minute, int second ) {
            return $"{second} {minute} {hour} * * ? *";
        }

        /// <summary>
        /// 每周重复执行
        /// </summary>
        /// <param name="dayOfWeek">在星期几执行</param>
        /// <param name="hour">在几点执行</param>
        /// <param name="minute">在第几分执行</param>
        /// <param name="second">在第几秒执行</param>
        public static string Weekly( DayOfWeek dayOfWeek, int hour, int minute, int second ) {
            return $"{second} {minute} {hour} ? * {GetDayOfWeek(dayOfWeek)} *";
        }

        /// <summary>
        /// 获取星期缩写
        /// </summary>
        private static string GetDayOfWeek( DayOfWeek dayOfWeek ) {
            switch ( dayOfWeek ) {
                case DayOfWeek.Monday:
                    return "MON";
                case DayOfWeek.Tuesday:
                    return "TUE";
                case DayOfWeek.Wednesday:
                    return "WED";
                case DayOfWeek.Thursday:
                    return "THUR";
                case DayOfWeek.Friday:
                    return "FRI";
                case DayOfWeek.Saturday:
                    return "SAT";
                case DayOfWeek.Sunday:
                    return "SUN";
            }
            return null;
        }

        /// <summary>
        /// 每月重复执行
        /// </summary>
        /// <param name="day">在第几天执行</param>
        /// <param name="hour">在几点执行</param>
        /// <param name="minute">在第几分执行</param>
        /// <param name="second">在第几秒执行</param>
        public static string Monthly( int day, int hour, int minute, int second ) {
            return $"{second} {minute} {hour} {day} * ? *";
        }

        /// <summary>
        /// 每年重复执行
        /// </summary>
        /// <param name="month">在几月执行</param>
        /// <param name="day">在第几天执行</param>
        /// <param name="hour">在几点执行</param>
        /// <param name="minute">在第几分执行</param>
        /// <param name="second">在第几秒执行</param>
        public static string Yearly( int month, int day, int hour, int minute, int second ) {
            return $"{second} {minute} {hour} {day} {month} ? *";
        }
    }
}
