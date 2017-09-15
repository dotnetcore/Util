namespace Util.Logs.Abstractions {
    /// <summary>
    /// 日志内容
    /// </summary>
    public interface ILogContent {
        /// <summary>
        /// 日志名称
        /// </summary>
        string LogName { get; set; }
        /// <summary>
        /// 日志级别
        /// </summary>
        string Level { get; set; }
        /// <summary>
        /// 跟踪号
        /// </summary>
        string TraceId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        string OperationTime { get; set; }
        /// <summary>
        /// 持续时间
        /// </summary>
        string Duration { get; set; }
        /// <summary>
        /// 请求地址
        /// </summary>
        string Url { get; set; }
    }
}
