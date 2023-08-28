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
}