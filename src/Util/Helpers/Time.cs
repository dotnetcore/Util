using System;

namespace Util.Helpers {
    /// <summary>
    /// 时间操作
    /// </summary>
    public static partial class Time {
        /// <summary>
        /// 日期
        /// </summary>
        private static DateTime? _dateTime;

        /// <summary>
        /// 设置时间
        /// </summary>
        /// <param name="dateTime">时间</param>
        public static void SetTime( DateTime? dateTime ) {
            _dateTime = dateTime;
        }

        /// <summary>
        /// 设置时间
        /// </summary>
        /// <param name="dateTime">时间</param>
        public static void SetTime( string dateTime ) {
            _dateTime = Util.Helpers.Convert.ToDateOrNull( dateTime );
        }

        /// <summary>
        /// 重置时间
        /// </summary>
        public static void Reset() {
            _dateTime = null;
        }

        /// <summary>
        /// 获取当前日期时间
        /// </summary>
        public static DateTime GetDateTime() {
            if( _dateTime == null )
                return DateTime.Now;
            return _dateTime.Value;
        }

        /// <summary>
        /// 获取当前日期,不带时间
        /// </summary>
        public static DateTime GetDate() {
            return GetDateTime().Date;
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