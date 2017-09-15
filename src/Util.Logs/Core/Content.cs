using Util.Logs.Abstractions;

namespace Util.Logs.Core {
    /// <summary>
    /// 日志内容
    /// </summary>
    public class Content : ILogContent {
        /// <summary>
        /// 日志名称
        /// </summary>
        public string LogName { get; set; }
        /// <summary>
        /// 日志级别
        /// </summary>
        public string Level { get; set; }
        /// <summary>
        /// 跟踪号
        /// </summary>
        public string TraceId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public string OperationTime { get; set; }
        /// <summary>
        /// 持续时间
        /// </summary>
        public string Duration { get; set; }
        /// <summary>
        /// 请求地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 业务编号
        /// </summary>
        public string BusinessId { get; set; }
        /// <summary>
        /// 应用程序
        /// </summary>
        public string Application { get; set; }
        /// <summary>
        /// 租户
        /// </summary>
        public string Tenant { get; set; }
        /// <summary>
        /// 模块
        /// </summary>
        public string Module { get; set; }
        /// <summary>
        /// 类名
        /// </summary>
        public string Class { get; set; }
        /// <summary>
        /// 方法名
        /// </summary>
        public string Method { get; set; }
        /// <summary>
        /// 参数
        /// </summary>
        public string Params { get; set; }
    }
}
