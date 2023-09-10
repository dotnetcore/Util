namespace Util.Events.Infrastructure;

/// <summary>
/// MediatR本地事件总线服务注册器配置扩展
/// </summary>
public static class ServiceRegistrarConfigExtensions {
    /// <summary>
    /// 启用MediatR本地事件总线服务注册器
    /// </summary>
    /// <param name="config">服务注册器配置</param>
    public static ServiceRegistrarConfig EnableMediatREventBusServiceRegistrar( this ServiceRegistrarConfig config ) {
        ServiceRegistrarConfig.Enable( MediatREventBusServiceRegistrar.ServiceName );
        return config;
    }

    /// <summary>
    ///禁用MediatR本地事件总线服务注册器
    /// </summary>
    /// <param name="config">服务注册器配置</param>
    public static ServiceRegistrarConfig DisableMediatREventBusServiceRegistrar( this ServiceRegistrarConfig config ) {
        ServiceRegistrarConfig.Disable( MediatREventBusServiceRegistrar.ServiceName );
        return config;
    }
}