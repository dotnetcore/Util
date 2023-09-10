using Util.Microservices.Dapr.Events;
using Util.Microservices.Dapr.ServiceInvocations;
using Util.Microservices.Dapr.StateManagements;

namespace Util.Microservices.Dapr; 

/// <summary>
/// Dapr微服务客户端
/// </summary>
public class DaprMicroserviceClient : IMicroserviceClient {
    /// <summary>
    /// 初始化Dapr微服务客户端
    /// </summary>
    /// <param name="client">Dapr客户端</param>
    /// <param name="httpClient">Dapr Http客户端</param>
    /// <param name="options">Dapr配置</param>
    /// <param name="appId">应用标识</param>
    /// <param name="loggerFactory">日志工厂</param>
    /// <param name="serviceProvider">服务提供器</param>
    public DaprMicroserviceClient( DaprClient client, HttpClient httpClient, IOptions<DaprOptions> options, string appId, ILoggerFactory loggerFactory, IServiceProvider serviceProvider ) {
        HttpClient = new HttpClientService().SetHttpClient( httpClient );
        ServiceInvocation = new DaprServiceInvocation( client, options, loggerFactory ).Service( appId );
        IntegrationEventBus = new DaprIntegrationEventBus( client, options, loggerFactory, serviceProvider );
        var keyGenerator = serviceProvider.GetService<IKeyGenerator>();
        StateManager = new DaprStateManager( client, options, loggerFactory, keyGenerator );
    }

    /// <summary>
    /// Http客户端
    /// </summary>
    public IHttpClient HttpClient { get; }

    /// <summary>
    /// WebApi服务调用
    /// </summary>
    public IServiceInvocation ServiceInvocation { get; }

    /// <summary>
    /// 集成事件总线
    /// </summary>
    public IIntegrationEventBus IntegrationEventBus { get; }

    /// <summary>
    /// 状态管理
    /// </summary>
    public IStateManager StateManager { get; }
}