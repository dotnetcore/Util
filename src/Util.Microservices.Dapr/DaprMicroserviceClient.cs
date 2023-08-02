using Util.Microservices.Dapr.ServiceInvocations;

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
    public DaprMicroserviceClient( DaprClient client, HttpClient httpClient, IOptions<DaprOptions> options, string appId, ILoggerFactory loggerFactory ) {
        HttpClient = new HttpClientService().SetHttpClient( httpClient );
        ServiceInvocation = new DaprServiceInvocation( client, options, loggerFactory ).Service( appId );
    }

    /// <summary>
    /// Http客户端
    /// </summary>
    public IHttpClient HttpClient { get; }

    /// <summary>
    /// WebApi服务调用
    /// </summary>
    public IServiceInvocation ServiceInvocation { get; }
}