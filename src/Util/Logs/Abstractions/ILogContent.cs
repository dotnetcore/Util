namespace Util.Logs.Abstractions {
    /// <summary>
    /// 日志内容
    /// </summary>
    public interface ILogContent {
        /// <summary>
        /// 跟踪号
        /// </summary>
        string TraceId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        string OperationTime { get; set; }
    }
}
