using Util.Logs.Abstractions;

namespace Util.Logs.Core {
    /// <summary>
    /// 日志内容
    /// </summary>
    public class Content : ILogContent {
        /// <summary>
        /// 跟踪号
        /// </summary>
        public string TraceId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public string OperationTime { get; set; }
        /// <summary>
        /// 业务编号
        /// </summary>
        public string BusinessId { get; set; }
    }
}
