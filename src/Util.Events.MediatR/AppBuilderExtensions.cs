using Util.Configs;

namespace Util.Events;

/// <summary>
/// MediatR事件总线操作扩展
/// </summary>
public static class AppBuilderExtensions {
    /// <summary>
    /// 配置MediatR事件总线操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    public static IAppBuilder AddMediatR( this IAppBuilder builder ) {
        builder.CheckNull( nameof( builder ) );
        MediatROptions.IsScan = true;
        builder.Host.ConfigureServices( ( context, services ) => {
            services.TryAddTransient<ILocalEventBus, MediatREventBus>();
        } );
        return builder;
    }

    /// <summary>
    /// 配置MediatR事件总线操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">事件总线配置操作</param>
    public static IAppBuilder AddMediatR( this IAppBuilder builder, Action<MediatRServiceConfiguration> setupAction ) {
        builder.CheckNull( nameof( builder ) );
        builder.Host.ConfigureServices( ( context, services ) => {
            services.TryAddTransient<ILocalEventBus, MediatREventBus>();
            services.AddMediatR( setupAction );
        } );
        return builder;
    }
}