namespace Util.Microservices.Events;

/// <summary>
/// 事件状态
/// </summary>
public enum EventState {
    /// <summary>
    /// 已发布
    /// </summary>
    [Description("util.eventState.published")]
    Published = 1,
    /// <summary>
    /// 处理中
    /// </summary>
    [Description("util.eventState.processing")]
    Processing = 2,
    /// <summary>
    /// 所有订阅全部成功完成
    /// </summary>
    [Description("util.eventState.success")]
    Success = 3,
    /// <summary>
    /// 失败
    /// </summary>
    [Description("util.eventState.fail")]
    Fail = 4
}