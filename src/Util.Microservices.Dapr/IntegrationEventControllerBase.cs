using Util.Microservices.Dapr.Events.Filters;

namespace Util.Microservices.Dapr;

/// <summary>
/// 集成事件控制器基类
/// </summary>
[ApiController]
[SubscriptionErroLogFilter]
[Route( "api/[controller]" )]
public abstract class IntegrationEventControllerBase : ControllerBase {
    /// <summary>
    /// 会话
    /// </summary>
    protected virtual Util.Sessions.ISession Session => Util.Sessions.UserSession.Instance;

    /// <summary>
    /// 返回成功消息
    /// </summary>
    protected IActionResult Success() {
        return PubsubResult.Success();
    }

    /// <summary>
    /// 重试
    /// </summary>
    protected IActionResult Retry() {
        return PubsubResult.Retry();
    }

    /// <summary>
    /// 写警告日志删除消息
    /// </summary>
    protected IActionResult Drop() {
        return PubsubResult.Drop();
    }

    /// <summary>
    /// 失败并重试
    /// </summary>
    protected IActionResult Fail() {
        return PubsubResult.Fail();
    }
}