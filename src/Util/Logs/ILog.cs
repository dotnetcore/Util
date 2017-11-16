using System;
using Util.Logs.Abstractions;

namespace Util.Logs {
    /// <summary>
    /// 日志操作
    /// </summary>
    public interface ILog {
        /// <summary>
        /// 设置内容
        /// </summary>
        /// <typeparam name="TContent">日志内容类型</typeparam>
        /// <param name="action">设置内容操作</param>
        ILog Set<TContent>( Action<TContent> action ) where TContent : ILogContent;
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
        void Trace( string message );
        /// <summary>
        /// 调试
        /// </summary>
        void Debug();
        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="message">日志消息</param>
        void Debug( string message );
        /// <summary>
        /// 信息
        /// </summary>
        void Info();
        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="message">日志消息</param>
        void Info( string message );
        /// <summary>
        /// 警告
        /// </summary>
        void Warn();
        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message">日志消息</param>
        void Warn( string message );
        /// <summary>
        /// 错误
        /// </summary>
        void Error();
        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message">日志消息</param>
        void Error( string message );
        /// <summary>
        /// 致命错误
        /// </summary>
        void Fatal();
        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="message">日志消息</param>
        void Fatal( string message );
    }
}
