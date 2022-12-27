using System;
using Util.Properties;

namespace Util.Exceptions {
    /// <summary>
    /// 并发异常
    /// </summary>
    public class ConcurrencyException : Warning {
        /// <summary>
        /// 消息
        /// </summary>
        private readonly string _message;

        /// <summary>
        /// 初始化并发异常
        /// </summary>
        public ConcurrencyException()
            : this( "" ) {
        }

        /// <summary>
        /// 初始化并发异常
        /// </summary>
        /// <param name="exception">异常</param>
        public ConcurrencyException( Exception exception )
            : this( "", exception ) {
        }

        /// <summary>
        /// 初始化并发异常
        /// </summary>
        /// <param name="message">错误消息</param>
        /// <param name="exception">异常</param>
        /// <param name="code">错误码</param>
        /// <param name="httpStatusCode">Http状态码</param>
        public ConcurrencyException( string message, Exception exception = null, string code = null, int? httpStatusCode = null )
            : base( message, exception, code, httpStatusCode ) {
            _message = message;
        }

        /// <inheritdoc />
        public override string Message => $"{R.ConcurrencyExceptionMessage}.{_message}";

        /// <inheritdoc />
        public override string GetMessage( bool isProduction = true ) {
            if( isProduction )
                return R.ConcurrencyExceptionMessage;
            return GetMessage(this);
        }
    }
}
