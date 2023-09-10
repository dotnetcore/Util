namespace Util.Microservices.Events;

/// <summary>
/// 空集成事件日志记录
/// </summary>
public class NullIntegrationEventLog : IntegrationEventLog {
    /// <summary>
    /// 空集成事件日志记录实例
    /// </summary>
    public static readonly IntegrationEventLog Instance = new NullIntegrationEventLog();
}

/// <summary>
/// 集成事件日志记录
/// </summary>
public class IntegrationEventLog : IntegrationEventLog<object> {
}

/// <summary>
/// 集成事件日志记录
/// </summary>
public class IntegrationEventLog<TValue> : StateBase {
    /// <summary>
    /// 初始化集成事件日志记录
    /// </summary>
    public IntegrationEventLog() {
        SubscriptionLogs = new List<SubscriptionLog>();
    }

    /// <summary>
    /// 应用标识
    ///</summary>
    public string AppId { get; set; }
    /// <summary>
    /// 用户标识
    ///</summary>
    public string UserId { get; set; }
    /// <summary>
    /// 发布订阅组件名称
    ///</summary>
    public string PubsubName { get; set; }
    /// <summary>
    /// 事件主题
    ///</summary>
    public string Topic { get; set; }
    /// <summary>
    /// 事件数据
    ///</summary>
    public TValue Value { get; set; }
    /// <summary>
    /// 事件状态
    ///</summary>
    public EventState State { get; set; }
    /// <summary>
    /// 发布时间
    ///</summary>
    public DateTime PublishTime { get; set; }
    /// <summary>
    /// 最后修改时间
    ///</summary>
    public DateTime LastModificationTime { get; set; }
    /// <summary>
    /// 订阅日志记录列表
    /// </summary>
    public List<SubscriptionLog> SubscriptionLogs { get; set; }

    /// <summary>
    /// 获取事件数据
    /// </summary>
    public T GetValue<T>() {
        return (T)(object)Value;
    }
}