namespace Util.Microservices.Dapr;

/// <summary>
/// 微服务客户端工厂扩展
/// </summary>
public static class MicroserviceClientFactoryExtensions {
    /// <summary>
    /// 设置应用标识
    /// </summary>
    /// <param name="source">微服务客户端工厂</param>
    /// <param name="appId">应用标识</param>
    public static IMicroserviceClientFactory AppId( this IMicroserviceClientFactory source,string appId ) {
        if ( source is DaprMicroserviceClientFactory factory )
            factory.AppId( appId );
        return source;
    }

    /// <summary>
    /// 设置Dapr Http端口
    /// </summary>
    /// <param name="source">微服务客户端工厂</param>
    /// <param name="daprHttpPort">Dapr Http端口</param>
    public static IMicroserviceClientFactory DaprHttpPort( this IMicroserviceClientFactory source, int daprHttpPort ) {
        if ( source is DaprMicroserviceClientFactory factory )
            factory.DaprHttpPort( daprHttpPort );
        return source;
    }

    /// <summary>
    /// 设置Dapr Grpc端口
    /// </summary>
    /// <param name="source">微服务客户端工厂</param>
    /// <param name="daprGrpcPort">Dapr Grpc端口</param>
    public static IMicroserviceClientFactory DaprGrpcPort( this IMicroserviceClientFactory source, int daprGrpcPort ) {
        if ( source is DaprMicroserviceClientFactory factory )
            factory.DaprGrpcPort( daprGrpcPort );
        return source;
    }
}