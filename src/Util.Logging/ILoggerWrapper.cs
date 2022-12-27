using System;
using Microsoft.Extensions.Logging;

namespace Util.Logging {
    /// <summary>
    /// 日志记录包装器
    /// </summary>
    public interface ILoggerWrapper {
        /// <summary>
        /// 是否启用
        /// </summary>
        /// <param name="logLevel">日志级别</param>
        bool IsEnabled( LogLevel logLevel );
        /// <summary>写日志</summary>
        /// <param name="logLevel">日志级别</param>
        /// <param name="eventId">日志事件标识</param>
        /// <param name="state">日志状态对象</param>
        /// <param name="exception">异常</param>
        /// <param name="formatter">消息格式化操作</param>
        /// <typeparam name="TState">日志状态类型</typeparam>
        void Log<TState>( LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter );
        /// <summary>
        /// 创建日志范围
        /// </summary>
        /// <param name="state">日志状态</param>
        /// <typeparam name="TState">日志状态类型</typeparam>
        IDisposable BeginScope<TState>( TState state );
        /// <summary>
        /// 写跟踪日志
        /// </summary>
        /// <param name="eventId">日志事件标识</param>
        /// <param name="exception">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">日志消息参数</param>
        void LogTrace( EventId eventId, Exception exception, string message, params object[] args );
        /// <summary>
        /// 写调试日志
        /// </summary>
        /// <param name="eventId">日志事件标识</param>
        /// <param name="exception">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">日志消息参数</param>
        void LogDebug( EventId eventId, Exception exception, string message, params object[] args );
        /// <summary>
        /// 写信息日志
        /// </summary>
        /// <param name="eventId">日志事件标识</param>
        /// <param name="exception">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">日志消息参数</param>
        void LogInformation( EventId eventId, Exception exception, string message, params object[] args );
        /// <summary>
        /// 写警告日志
        /// </summary>
        /// <param name="eventId">日志事件标识</param>
        /// <param name="exception">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">日志消息参数</param>
        void LogWarning( EventId eventId, Exception exception, string message, params object[] args );
        /// <summary>
        /// 写错误日志
        /// </summary>
        /// <param name="eventId">日志事件标识</param>
        /// <param name="exception">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">日志消息参数</param>
        void LogError( EventId eventId, Exception exception, string message, params object[] args );
        /// <summary>
        /// 写致命日志
        /// </summary>
        /// <param name="eventId">日志事件标识</param>
        /// <param name="exception">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">日志消息参数</param>
        void LogCritical( EventId eventId, Exception exception, string message, params object[] args );
    }
}
