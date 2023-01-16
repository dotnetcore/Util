using System;
using System.Text;
using Util.Helpers;
using Util.Properties;

namespace Util {
    /// <summary>
    /// 日期扩展
    /// </summary>
    public static class DateTimeExtensions {
        /// <summary>
        /// 获取格式化字符串，带时分秒，格式："yyyy-MM-dd HH:mm:ss"
        /// </summary>
        /// <param name="dateTime">日期</param>
        /// <param name="removeSecond">是否移除秒</param>
        public static string ToDateTimeString( this DateTime dateTime, bool removeSecond = false ) {
            dateTime = GetLocalDateTime( dateTime );
            if ( removeSecond )
                return dateTime.ToString( "yyyy-MM-dd HH:mm" );
            return dateTime.ToString( "yyyy-MM-dd HH:mm:ss" );
        }

        /// <summary>
        /// 获取本地日期
        /// </summary>
        private static DateTime GetLocalDateTime( DateTime dateTime ) {
            return Time.ToLocalTime( dateTime );
        }

        /// <summary>
        /// 获取格式化字符串，带时分秒，格式："yyyy-MM-dd HH:mm:ss"
        /// </summary>
        /// <param name="dateTime">日期</param>
        /// <param name="removeSecond">是否移除秒</param>
        public static string ToDateTimeString( this DateTime? dateTime, bool removeSecond = false ) {
            if( dateTime == null )
                return string.Empty;
            return ToDateTimeString( dateTime.Value, removeSecond );
        }

        /// <summary>
        /// 获取格式化字符串，不带时分秒，格式："yyyy-MM-dd"
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string ToDateString( this DateTime dateTime ) {
            dateTime = GetLocalDateTime( dateTime );
            return dateTime.ToString( "yyyy-MM-dd" );
        }

        /// <summary>
        /// 获取格式化字符串，不带时分秒，格式："yyyy-MM-dd"
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string ToDateString( this DateTime? dateTime ) {
            if( dateTime == null )
                return string.Empty;
            return ToDateString( dateTime.Value );
        }

        /// <summary>
        /// 获取格式化字符串，不带年月日，格式："HH:mm:ss"
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string ToTimeString( this DateTime dateTime ) {
            dateTime = GetLocalDateTime( dateTime );
            return dateTime.ToString( "HH:mm:ss" );
        }

        /// <summary>
        /// 获取格式化字符串，不带年月日，格式："HH:mm:ss"
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string ToTimeString( this DateTime? dateTime ) {
            if( dateTime == null )
                return string.Empty;
            return ToTimeString( dateTime.Value );
        }

        /// <summary>
        /// 获取格式化字符串，带毫秒，格式："yyyy-MM-dd HH:mm:ss.fff"
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string ToMillisecondString( this DateTime dateTime ) {
            dateTime = GetLocalDateTime( dateTime );
            return dateTime.ToString( "yyyy-MM-dd HH:mm:ss.fff" );
        }

        /// <summary>
        /// 获取格式化字符串，带毫秒，格式："yyyy-MM-dd HH:mm:ss.fff"
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string ToMillisecondString( this DateTime? dateTime ) {
            if( dateTime == null )
                return string.Empty;
            return ToMillisecondString( dateTime.Value );
        }

        /// <summary>
        /// 获取中文格式化字符串，不带时分秒，格式："yyyy年MM月dd日"
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string ToChineseDateString( this DateTime dateTime ) {
            dateTime = GetLocalDateTime( dateTime );
            return $"{dateTime.Year}年{dateTime.Month}月{dateTime.Day}日";
        }

        /// <summary>
        /// 获取中文格式化字符串，不带时分秒，格式："yyyy年MM月dd日"
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string ToChineseDateString( this DateTime? dateTime ) {
            if( dateTime == null )
                return string.Empty;
            return ToChineseDateString( dateTime.SafeValue() );
        }

        /// <summary>
        /// 获取中文格式化字符串，带时分秒，格式："yyyy年MM月dd日 HH时mm分"
        /// </summary>
        /// <param name="dateTime">日期</param>
        /// <param name="removeSecond">是否移除秒</param>
        public static string ToChineseDateTimeString( this DateTime dateTime, bool removeSecond = false ) {
            dateTime = GetLocalDateTime( dateTime );
            StringBuilder result = new StringBuilder();
            result.AppendFormat( "{0}年{1}月{2}日", dateTime.Year, dateTime.Month, dateTime.Day );
            result.AppendFormat( " {0}时{1}分", dateTime.Hour, dateTime.Minute );
            if( removeSecond == false )
                result.AppendFormat( "{0}秒", dateTime.Second );
            return result.ToString();
        }

        /// <summary>
        /// 获取中文格式化字符串，带时分秒，格式："yyyy年MM月dd日 HH时mm分"
        /// </summary>
        /// <param name="dateTime">日期</param>
        /// <param name="removeSecond">是否移除秒</param>
        public static string ToChineseDateTimeString( this DateTime? dateTime, bool removeSecond = false ) {
            if( dateTime == null )
                return string.Empty;
            return ToChineseDateTimeString( dateTime.Value, removeSecond );
        }

        /// <summary>
        /// 获取描述
        /// </summary>
        /// <param name="timeSpan">时间间隔</param>
        public static string Description( this TimeSpan timeSpan ) {
            StringBuilder result = new StringBuilder();
            if ( timeSpan.Days > 0 ) {
                result.Append( timeSpan.Days );
                result.Append( R.Days );
            }
            if ( timeSpan.Hours > 0 ) {
                result.Append( timeSpan.Hours );
                result.Append( R.Hours );
            }
            if ( timeSpan.Minutes > 0 ) {
                result.Append( timeSpan.Minutes );
                result.Append( R.Minutes );
            }
            if ( timeSpan.Seconds > 0 ) {
                result.Append( timeSpan.Seconds );
                result.Append( R.Seconds );
            }
            if ( timeSpan.Milliseconds > 0 ) {
                result.Append( timeSpan.Milliseconds );
                result.Append( R.Milliseconds );
            }
            if ( result.Length > 0 )
                return result.ToString();
            return $"{timeSpan.TotalMilliseconds}{R.Milliseconds}";
        }
    }
}
