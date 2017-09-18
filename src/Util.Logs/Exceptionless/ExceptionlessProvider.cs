using System;
using Exceptionless;
using Exceptionless.Logging;
using Util.Logs.Abstractions;
using Util.Logs.Formats;

namespace Util.Logs.Exceptionless {
    /// <summary>
    /// Exceptionless日志提供程序
    /// </summary>
    public class ExceptionlessProvider : ILogProvider {
        /// <summary>
        /// 客户端
        /// </summary>
        private readonly ExceptionlessClient _client;

        /// <summary>
        /// 初始化Exceptionless日志提供程序
        /// </summary>
        /// <param name="logName">日志名称</param>
        public ExceptionlessProvider( string logName ) {
            _client = ExceptionlessClient.Default;
            LogName = logName;
        }

        /// <summary>
        /// 日志名称
        /// </summary>
        public string LogName { get; }

        /// <summary>
        /// 调试级别是否启用
        /// </summary>
        public bool IsDebugEnabled { get; }

        /// <summary>
        /// 跟踪级别是否启用
        /// </summary>
        public bool IsTraceEnabled { get; }

        /// <summary>
        /// 跟踪
        /// </summary>
        /// <param name="message">日志消息</param>
        public void Trace( object message ) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="message">日志消息</param>
        public void Debug( object message ) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="message">日志消息</param>
        public void Info( object message ) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message">日志消息</param>
        public void Warn( object message ) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message">日志消息</param>
        public void Error( object message ) {
            _client.CreateEvent().AddObject( message ).Submit();
        }

        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="message">日志消息</param>
        public void Fatal( object message ) {
            throw new NotImplementedException();
        }
    }
}
