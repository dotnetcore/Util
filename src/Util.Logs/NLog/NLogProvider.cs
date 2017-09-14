using System;
using NLog;
using Util.Logs.Formats;

namespace Util.Logs.NLog {
    /// <summary>
    /// NLog日志提供程序
    /// </summary>
    public class NLogProvider : ILogProvider {
        /// <summary>
        /// NLog日志操作
        /// </summary>
        private readonly Logger _logger;
        /// <summary>
        /// 日志格式化器
        /// </summary>
        private readonly ILogFormat _format;

        /// <summary>
        /// 初始化日志
        /// </summary>
        /// <param name="logger">NLog日志操作</param>
        /// <param name="format">日志格式化器</param>
        public NLogProvider( Logger logger ,ILogFormat format ) {
            _logger = logger;
            _format = format;
        }

        /// <summary>
        /// 调试级别是否启用
        /// </summary>
        public bool IsDebugEnabled => _logger.IsDebugEnabled;

        /// <summary>
        /// 跟踪级别是否启用
        /// </summary>
        public bool IsTraceEnabled => _logger.IsTraceEnabled;

        /// <summary>
        /// 跟踪
        /// </summary>
        /// <param name="message">日志消息</param>
        public void Trace( object message ) {
            _logger.Trace( new FormatProvider( _format ), message );
        }

        /// <summary>
        /// 跟踪
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Trace( string message, params object[] args ) {
            _logger.Trace( message, args );
        }

        /// <summary>
        /// 跟踪
        /// </summary>
        /// <param name="exception">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Trace( Exception exception, string message = "", params object[] args ) {
            _logger.Trace( exception, message, args );
        }

        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="message">日志消息</param>
        public void Debug( object message ) {
            _logger.Debug( message );
        }

        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Debug( string message, params object[] args ) {
            _logger.Debug( message, args );
        }

        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="exception">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Debug( Exception exception, string message = "", params object[] args ) {
            _logger.Debug( exception, message, args );
        }

        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="message">日志消息</param>
        public void Info( object message ) {
            _logger.Info( message );
        }

        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Info( string message, params object[] args ) {
            _logger.Info( message, args );
        }

        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="exception">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Info( Exception exception, string message = "", params object[] args ) {
            _logger.Info( exception, message, args );
        }

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message">日志消息</param>
        public void Warn( object message ) {
            _logger.Warn( message );
        }

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Warn( string message, params object[] args ) {
            _logger.Warn( message, args );
        }

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="exception">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Warn( Exception exception, string message = "", params object[] args ) {
            _logger.Warn( exception, message, args );
        }

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message">日志消息</param>
        public void Error( object message ) {
            _logger.Error( message );
        }

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Error( string message, params object[] args ) {
            _logger.Error( message, args );
        }

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="exception">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Error( Exception exception, string message = "", params object[] args ) {
            _logger.Error( exception, message, args );
        }

        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="message">日志消息</param>
        public void Fatal( object message ) {
            _logger.Fatal( message );
        }

        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Fatal( string message, params object[] args ) {
            _logger.Fatal( message, args );
        }

        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="exception">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        public void Fatal( Exception exception, string message = "", params object[] args ) {
            _logger.Fatal( exception, message, args );
        }
    }
}
