namespace Util.Microservices;

/// <summary>
/// 微服务客户端工厂
/// </summary>
public interface IMicroserviceClientFactory : ITransientDependency {
    /// <summary>
    /// 创建微服务客户端
    /// </summary>
    IMicroserviceClient Create();
}