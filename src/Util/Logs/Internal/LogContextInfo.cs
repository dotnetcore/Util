using System.Diagnostics;

namespace Util.Logs.Internal {
    /// <summary>
    /// 日志上下文信息
    /// </summary>
    public class LogContextInfo {
        /// <summary>
        /// 跟踪号
        /// </summary>
        public string TraceId { get; set; }

        /// <summary>
        /// 计时器
        /// </summary>
        public Stopwatch Stopwatch { get; set; }

        /// <summary>
        /// IP
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 主机
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// 浏览器
        /// </summary>
        public string Browser { get; set; }

        /// <summary>
        /// 请求地址
        /// </summary>
        public string Url { get; set; }
    }
}
