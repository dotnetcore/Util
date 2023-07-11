namespace Util.Events;

/// <summary>
/// 集成事件
/// </summary>
public interface IIntegrationEvent : IEvent {
    /// <summary>
    /// 事件标识
    /// </summary>
    public string EventId { get; }
    /// <summary>
    /// 事件发生时间
    /// </summary>
    public DateTime EventTime { get; }
}