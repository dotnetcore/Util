namespace Util.Microservices.Events;

/// <summary>
/// 订阅状态
/// </summary>
public enum SubscriptionState {
    /// <summary>
    /// 处理中
    /// </summary>
    [Description( "util.subscriptionState.processing" )]
    Processing = 1,
    /// <summary>
    /// 成功完成
    /// </summary>
    [Description( "util.subscriptionState.success" )]
    Success = 2,
    /// <summary>
    /// 失败
    /// </summary>
    [Description( "util.subscriptionState.fail" )]
    Fail = 3
}