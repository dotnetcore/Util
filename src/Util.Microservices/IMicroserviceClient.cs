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
}