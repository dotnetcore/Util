using System.Diagnostics;

namespace Util.Logs.Internal {
    /// <summary>
    /// 日志上下文信息
    /// </summary>
    internal class LogContextInfo {
        /// <summary>
        /// 初始化日志上下文信息
        /// </summary>
        /// <param name="traceId">跟踪号</param>
        /// <param name="stopwatch">计时器</param>
        public LogContextInfo( string traceId, Stopwatch stopwatch ) {
            TraceId = traceId;
            Stopwatch = stopwatch;
        }

        /// <summary>
        /// 跟踪号
        /// </summary>
        public string TraceId { get; set; }

        /// <summary>
        /// 计时器
        /// </summary>
        public Stopwatch Stopwatch { get; set; }
    }
}
