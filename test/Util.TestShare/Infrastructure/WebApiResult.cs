namespace Util.Tests.Infrastructure {
    /// <summary>
    /// Web Api操作结果
    /// </summary>
    public class WebApiResult<T> {
        /// <summary>
        /// 状态码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }
    }
}
