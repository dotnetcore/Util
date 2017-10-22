using System;
using Util.Logs.Abstractions;

namespace Util.Logs.Formats {
    /// <summary>
    /// 日志格式化提供程序
    /// </summary>
    public class FormatProvider : IFormatProvider, ICustomFormatter {
        /// <summary>
        /// 日志格式化器
        /// </summary>
        private readonly ILogFormat _format;

        /// <summary>
        /// 初始化日志格式化提供程序
        /// </summary>
        /// <param name="format">日志格式化器</param>
        public FormatProvider( ILogFormat format ) {
            _format = format ?? throw new ArgumentNullException( nameof( format ) );
        }

        /// <summary>
        /// 格式化
        /// </summary>
        public string Format( string format, object arg, IFormatProvider formatProvider ) {
            if( !( arg is ILogContent content ) )
                return string.Empty;
            return _format.Format( content );
        }

        /// <summary>
        /// 获取格式化器
        /// </summary>
        public object GetFormat( Type formatType ) {
            return formatType == typeof( ICustomFormatter ) ? this : null;
        }
    }
}
