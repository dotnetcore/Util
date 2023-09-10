using Util.Events;
using Util.Http;

namespace Util.Microservices; 

/// <summary>
/// 微服务客户端
/// </summary>
public interface IMicroserviceClient {
    /// <summary>
    /// Http客户端
    /// </summary>
    IHttpClient HttpClient { get; }
    /// <summary>
    /// WebApi服务调用
    /// </summary>
    IServiceInvocation ServiceInvocation { get; }
    /// <summary>
    /// 集成事件总线
    /// </summary>
    IIntegrationEventBus IntegrationEventBus { get; }
    /// <summary>
    /// 状态管理
    /// </summary>
    IStateManager StateManager { get; }
}