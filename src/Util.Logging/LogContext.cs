using System.Collections.Generic;
using System.Diagnostics;

namespace Util.Logging {
    /// <summary>
    /// 日志上下文
    /// </summary>
    public class LogContext {
        /// <summary>
        /// 初始化日志上下文
        /// </summary>
        public LogContext() {
            Data = new Dictionary<string, object>();
        }

        /// <summary>
        /// 计时器
        /// </summary>
        public Stopwatch Stopwatch { get; set; }
        /// <summary>
        /// 跟踪标识
        /// </summary>
        public string TraceId { get; set; }
        /// <summary>
        /// 用户标识
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 应用程序
        /// </summary>
        public string Application { get; set; }
        /// <summary>
        /// 执行环境
        /// </summary>
        public string Environment { get; set; }
        /// <summary>
        /// 扩展数据
        /// </summary>
        public IDictionary<string, object> Data { get; }
    }
}
