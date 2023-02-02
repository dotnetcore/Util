using System;
using System.Threading;
using Util.Dates;

namespace Util.Helpers {
    /// <summary>
    /// 时间操作
    /// </summary>
    public static class Time {
        /// <summary>
        /// 日期
        /// </summary>
        private static readonly AsyncLocal<DateTime?> _dateTime = new();
        /// <summary>
        /// 是否使用Utc日期
        /// </summary>
        private static readonly AsyncLocal<bool?> _isUseUtc = new();
        /// <summary>
        /// 是否使用Utc日期
        /// </summary>
        private static bool IsUseUtc => _isUseUtc.Value != null ? _isUseUtc.Value.SafeValue() : TimeOptions.IsUseUtc;

        /// <summary>
        /// 设置时间
        /// </summary>
        /// <param name="dateTime">时间</param>
        public static void SetTime( DateTime? dateTime ) {
            _dateTime.Value = dateTime;
        }

        /// <summary>
        /// 设置时间
        /// </summary>
        /// <param name="dateTime">时间</param>
        public static void SetTime( string dateTime ) {
            SetTime( Convert.ToDateTimeOrNull( dateTime ) );
        }

        /// <summary>
        /// 设置使用Utc日期
        /// </summary>
        /// <param name="isUseUtc">是否使用Utc日期,默认值: true</param>
        public static void UseUtc( bool? isUseUtc = true ) {
            _isUseUtc.Value = isUseUtc;
        }

        /// <summary>
        /// 重置时间和Utc标志
        /// </summary>
        public static void Reset() {
            _dateTime.Value = null;
            _isUseUtc.Value = null;
        }

        /// <summary>
        /// 获取当前日期时间
        /// </summary>
        public static DateTime Now {
            get {
                if ( _dateTime.Value != null )
                    return _dateTime.Value.Value;
                return IsUseUtc ? DateTime.UtcNow : DateTime.Now;
            }
        }


        /// <summary>
        /// 转换为标准化日期
        /// </summary>
        /// <param name="date">日期</param>
        public static DateTime? Normalize( DateTime? date ) {
            if( date == null )
                return null;
            return Normalize( date.Value );
        }

        /// <summary>
        /// 转换为标准化日期
        /// </summary>
        /// <param name="date">日期</param>
        public static DateTime Normalize( DateTime date ) {
            if ( IsUseUtc )
                return ToUniversalTime( date );
            return ToLocalTime( date );
        }

        /// <summary>
        /// 转换为UTC日期
        /// </summary>
        /// <param name="date">日期</param>
        public static DateTime ToUniversalTime( DateTime date ) {
            if ( date == DateTime.MinValue )
                return DateTime.MinValue;
            switch ( date.Kind ) {
                case DateTimeKind.Local:
                    return date.ToUniversalTime();
                case DateTimeKind.Unspecified:
                    return DateTime.SpecifyKind( date, DateTimeKind.Local ).ToUniversalTime();
                default:
                    return date;
            }
        }

        /// <summary>
        /// 转换为本地化日期
        /// </summary>
        /// <param name="date">日期</param>
        public static DateTime ToLocalTime( DateTime date ) {
            if ( date == DateTime.MinValue )
                return DateTime.MinValue;
            switch ( date.Kind ) {
                case DateTimeKind.Utc:
                    return date.ToLocalTime();
                case DateTimeKind.Unspecified:
                    return DateTime.SpecifyKind( date, DateTimeKind.Local );
                default:
                    return date;
            }
        }

        /// <summary>
        /// Utc日期转换为本地化日期
        /// </summary>
        /// <param name="date">日期</param>
        public static DateTime UtcToLocalTime( DateTime date ) {
            if ( date == DateTime.MinValue )
                return DateTime.MinValue;
            if( date.Kind == DateTimeKind.Utc )
                return date.ToLocalTime();
            if ( date.Kind == DateTimeKind.Local )
                return date;
            if ( IsUseUtc )
                return DateTime.SpecifyKind( date, DateTimeKind.Utc ).ToLocalTime();
            return date;
        }

        /// <summary>
        /// 获取Unix时间戳
        /// </summary>
        public static long GetUnixTimestamp() {
            return GetUnixTimestamp( DateTime.Now );
        }

        /// <summary>
        /// 获取Unix时间戳
        /// </summary>
        /// <param name="time">时间</param>
        public static long GetUnixTimestamp( DateTime time ) {
            var start = TimeZoneInfo.ConvertTime( new DateTime( 1970, 1, 1 ), TimeZoneInfo.Local );
            long ticks = ( time - start.Add( new TimeSpan( 8, 0, 0 ) ) ).Ticks;
            return Util.Helpers.Convert.ToLong( ticks / TimeSpan.TicksPerSecond );
        }

        /// <summary>
        /// 从Unix时间戳获取时间
        /// </summary>
        /// <param name="timestamp">Unix时间戳</param>
        public static DateTime GetTimeFromUnixTimestamp( long timestamp ) {
            var start = TimeZoneInfo.ConvertTime( new DateTime( 1970, 1, 1 ), TimeZoneInfo.Local );
            TimeSpan span = new TimeSpan( long.Parse( timestamp + "0000000" ) );
            return start.Add( span ).Add( new TimeSpan( 8, 0, 0 ) );
        }
    }
}