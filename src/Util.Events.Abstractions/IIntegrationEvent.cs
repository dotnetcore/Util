namespace Util.Events;

/// <summary>
/// 集成事件
/// </summary>
public interface IIntegrationEvent : IEvent {
    /// <summary>
    /// 事件标识
    /// </summary>
    string EventId { get; }
    /// <summary>
    /// 事件发生时间
    /// </summary>
    DateTime EventTime { get; }
    /// <summary>
    /// 是否立即发送,默认值: true
    /// </summary>
    bool SendNow { get; }
    /// <summary>
    /// 发布订阅名称,默认值: pubsub
    /// </summary>
    string PubsubName { get; }
    /// <summary>
    /// 事件主题,默认为事件类型名称
    /// </summary>
    string Topic { get; }
}