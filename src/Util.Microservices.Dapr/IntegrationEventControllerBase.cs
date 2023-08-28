using Util.Microservices.Dapr.Events;
using Util.Microservices.Dapr.Events.Filters;

namespace Util.Microservices.Dapr;

/// <summary>
/// 集成事件控制器基类
/// </summary>
[ApiController]
[SubscriptionFilter]
[SubscriptionExceptionHandler( Order = 1 )]
[SubscriptionErrorLogFilter( Order = 2 )]
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
        return PubsubResult.Success;
    }

    /// <summary>
    /// 失败并重试
    /// </summary>
    /// <param name="message">错误消息</param>
    protected IActionResult Fail( string message ) {
        return PubsubResult.Fail( message );
    }

    /// <summary>
    /// 失败并删除消息
    /// </summary>
    /// <param name="message">错误消息</param>
    protected IActionResult Drop( string message ) {
        return PubsubResult.Drop( message );
    }
}