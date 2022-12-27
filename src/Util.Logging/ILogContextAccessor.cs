namespace Util.Logging {
    /// <summary>
    /// 日志上下文访问器
    /// </summary>
    public interface ILogContextAccessor {
        /// <summary>
        /// 日志上下文
        /// </summary>
        LogContext Context { get; set; }
    }
}
