namespace Util.Contexts {
    /// <summary>
    /// Web上下文
    /// </summary>
    public interface IWebContext : IContext {
        /// <summary>
        /// 跟踪号
        /// </summary>
        string TraceId { get; }
        /// <summary>
        /// 请求地址
        /// </summary>
        string Url { get; }
    }
}
