using Util.Events;

namespace Util.Microservices.Dapr.WebApiSample.Events;

/// <summary>
/// 测试事件
/// </summary>
/// <param name="UserId">用户标识</param>
/// <param name="Message">消息</param>
public record TestEvent(
    string UserId,
    string Message
) : IntegrationEvent {
}