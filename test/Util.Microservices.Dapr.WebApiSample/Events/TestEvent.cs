using Util.Events;

namespace Util.Microservices.Dapr.WebApiSample.Events;

/// <summary>
/// 测试事件
/// </summary>
/// <param name="Code">编码</param>
/// <param name="Name">名称</param>
public record TestEvent( string Code, string Name ) : IntegrationEvent;