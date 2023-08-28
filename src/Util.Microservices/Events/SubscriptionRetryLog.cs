namespace Util.Microservices.Events;

/// <summary>
/// 订阅重试日志记录
/// </summary>
public class SubscriptionRetryLog {
    /// <summary>
    /// 重试序号
    ///</summary>
    public int Number { get; set; }
    /// <summary>
    /// 重试时间
    ///</summary>
    public DateTime? RetryTime { get; set; }
    /// <summary>
    /// 失败消息
    ///</summary>
    public string Message { get; set; }
}