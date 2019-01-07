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
        /// <param name="message">错误消息</param>
        public ConcurrencyException( string message )
            : this( message, null ) {
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
        public ConcurrencyException( string message, Exception exception )
            : this( message, exception, "" ) {
        }

        /// <summary>
        /// 初始化并发异常
        /// </summary>
        /// <param name="message">错误消息</param>
        /// <param name="exception">异常</param>
        /// <param name="code">错误码</param>
        public ConcurrencyException( string message, Exception exception, string code )
            : base( message, code, exception ) {
            _message = message;
        }

        /// <summary>
        /// 错误消息
        /// </summary>
        public override string Message => $"{LibraryResource.ConcurrencyExceptionMessage}.{_message}";
    }
}
