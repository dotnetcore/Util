namespace Util.Events; 

/// <summary>
/// 集成事件
/// </summary>
public record IntegrationEvent : IIntegrationEvent {
    /// <inheritdoc />
    public string EventId { get; init; }

    /// <inheritdoc />
    public DateTime EventTime { get; init; }

    /// <summary>
    /// 初始化集成事件
    /// </summary>
    public IntegrationEvent() {
        EventId = Guid.NewGuid().ToString();
        EventTime = Util.Helpers.Time.Now;
    }
}