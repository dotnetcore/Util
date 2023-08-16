namespace Util.Microservices.Dapr.Events;

/// <summary>
/// 发布订阅参数
/// </summary>
/// <param name="Event">事件</param>
/// <param name="Metadata">元数据</param>
public record PubsubArgument(
    CloudEvent<IIntegrationEvent> Event = null,
    Dictionary<string,string> Metadata = null
);