namespace Util.Microservices.Events;

/// <summary>
/// 事件状态
/// </summary>
public enum EventState {
    /// <summary>
    /// 准备发布
    /// </summary>
    [Description("util.eventState.prePublish")]
    PrePublish = 1,
    /// <summary>
    /// 发布成功
    /// </summary>
    [Description("util.eventState.published")]
    Published = 2,
    /// <summary>
    /// 处理中
    /// </summary>
    [Description("util.eventState.processing")]
    Processing = 3,
    /// <summary>
    /// 所有订阅全部成功完成
    /// </summary>
    [Description("util.eventState.success")]
    Success = 4,
    /// <summary>
    /// 失败
    /// </summary>
    [Description("util.eventState.fail")]
    Fail = 5
}