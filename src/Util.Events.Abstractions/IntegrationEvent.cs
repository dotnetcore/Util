namespace Util.Events; 

/// <summary>
/// 集成事件
/// </summary>
public record IntegrationEvent : IIntegrationEvent {
    /// <summary>
    /// 事件标识
    /// </summary>
    public string EventId { get; }

    /// <summary>
    /// 事件发生时间
    /// </summary>
    public DateTime EventTime { get; }

    /// <summary>
    /// 是否立即发送,默认为false,将在提交工作单元后发送
    /// </summary>
    public bool SendNow { get; }

    /// <summary>
    /// 初始化集成事件
    /// </summary>
    public IntegrationEvent() {
        EventId = Guid.NewGuid().ToString();
        EventTime = Util.Helpers.Time.Now;
        SendNow = false;
    }
}