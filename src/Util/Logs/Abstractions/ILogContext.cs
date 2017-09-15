using System.Diagnostics;

namespace Util.Logs.Abstractions {
    /// <summary>
    /// 日志上下文
    /// </summary>
    public interface ILogContext {
        /// <summary>
        /// 跟踪号
        /// </summary>
        string TraceId { get; }
        /// <summary>
        /// 计时器
        /// </summary>
        Stopwatch Stopwatch { get; }
    }
}
