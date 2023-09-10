namespace Util.Events.Infrastructure;

/// <summary>
/// MediatR本地事件总线服务注册器
/// </summary>
public class MediatREventBusServiceRegistrar : IServiceRegistrar {
    /// <summary>
    /// 获取服务名
    /// </summary>
    public static string ServiceName => "Util.Events.MediatR.Infrastructure.LocalEventBusServiceRegistrar";

    /// <summary>
    /// 排序号
    /// </summary>
    public int OrderId => 511;

    /// <summary>
    /// 是否启用
    /// </summary>
    public bool Enabled => ServiceRegistrarConfig.IsEnabled( ServiceName );

    /// <summary>
    /// 注册服务
    /// </summary>
    /// <param name="serviceContext">服务上下文</param>
    public Action Register( ServiceContext serviceContext ) {
        serviceContext.HostBuilder.ConfigureServices( ( context, services ) => {
            RegisterMediatR( services, serviceContext.AssemblyFinder );
        } );
        return null;
    }

    /// <summary>
    /// 注册MediatR
    /// </summary>
    private void RegisterMediatR( IServiceCollection services, IAssemblyFinder finder ) {
        if ( MediatROptions.IsScan == false )
            return;
        services.AddMediatR( t => t.RegisterServicesFromAssemblies( finder.Find().ToArray() ) );
    }
}