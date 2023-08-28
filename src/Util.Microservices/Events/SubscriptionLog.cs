namespace Util.Microservices.Events;

/// <summary>
/// 订阅日志记录
/// </summary>
public class SubscriptionLog {
    /// <summary>
    /// 初始化订阅日志记录
    /// </summary>
    public SubscriptionLog() {
        RetryLogs = new List<SubscriptionRetryLog>();
    }

    /// <summary>
    /// 应用标识
    ///</summary>
    public string AppId { get; set; }
    /// <summary>
    /// 订阅地址
    ///</summary>
    public string RouteUrl { get; set; }
    /// <summary>
    /// 重试次数
    ///</summary>
    public int? RetryCount { get; set; }
    /// <summary>
    /// 订阅状态
    ///</summary>
    public SubscriptionState State { get; set; }
    /// <summary>
    /// 订阅时间
    ///</summary>
    public DateTime SubscriptionTime { get; set; }
    /// <summary>
    /// 最后修改时间
    ///</summary>
    public DateTime LastModificationTime { get; set; }
    /// <summary>
    /// 订阅重试日志记录列表
    /// </summary>
    public List<SubscriptionRetryLog> RetryLogs { get; set; }
}