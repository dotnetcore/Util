using System;

namespace Util.Logs.Abstractions {
    /// <summary>
    /// 日志操作
    /// </summary>
    public interface ILog {
        /// <summary>
        /// 设置内容
        /// </summary>
        /// <typeparam name="TContent">日志内容类型</typeparam>
        /// <param name="action">设置内容操作</param>
        ILog Content<TContent>( Action<TContent> action ) where TContent : ILogContent;
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
        void Trace();
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
