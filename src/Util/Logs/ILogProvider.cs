using System;

namespace Util.Logs {
    /// <summary>
    /// 日志提供程序
    /// </summary>
    public interface ILogProvider {
        /// <summary>
        /// 调试级别是否启用
        /// </summary>
        bool IsDebugEnabled { get; }
        /// <summary>
        /// 跟踪级别是否启用
        /// </summary>
        bool IsTraceEnabled { get; }
        /// <summary>
        /// 跟踪
        /// </summary>
        /// <param name="message">日志消息</param>
        void Trace( object message );
        /// <summary>
        /// 跟踪
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        void Trace( string message, params object[] args );
        /// <summary>
        /// 跟踪
        /// </summary>
        /// <param name="exception">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        void Trace( Exception exception, string message = "", params object[] args );
        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="message">日志消息</param>
        void Debug( object message );
        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        void Debug( string message, params object[] args );
        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="exception">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        void Debug( Exception exception, string message = "", params object[] args );
        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="message">日志消息</param>
        void Info( object message );
        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        void Info( string message, params object[] args );
        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="exception">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        void Info( Exception exception, string message = "", params object[] args );
        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message">日志消息</param>
        void Warn( object message );
        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        void Warn( string message, params object[] args );
        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="exception">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        void Warn( Exception exception, string message = "", params object[] args );
        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message">日志消息</param>
        void Error( object message );
        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        void Error( string message, params object[] args );
        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="exception">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        void Error( Exception exception, string message = "", params object[] args );
        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="message">日志消息</param>
        void Fatal( object message );
        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        void Fatal( string message, params object[] args );
        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="exception">异常</param>
        /// <param name="message">日志消息</param>
        /// <param name="args">参数值</param>
        void Fatal( Exception exception, string message = "", params object[] args );
    }
}
