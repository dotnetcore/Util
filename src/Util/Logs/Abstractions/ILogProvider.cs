namespace Util.Logs.Abstractions {
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
        /// 调试
        /// </summary>
        /// <param name="message">日志消息</param>
        void Debug( object message );
        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="message">日志消息</param>
        void Info( object message );
        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message">日志消息</param>
        void Warn( object message );
        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message">日志消息</param>
        void Error( object message );
        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="message">日志消息</param>
        void Fatal( object message );
    }
}
