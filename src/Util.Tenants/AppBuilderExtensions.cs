using Util.Configs;
using Util.Tenants.Resolvers;

namespace Util.Tenants;

/// <summary>
/// 租户操作扩展
/// </summary>
public static class AppBuilderExtensions {
    /// <summary>
    /// 配置租户操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    public static IAppBuilder AddTenant( this IAppBuilder builder ) {
        return builder.AddTenant( null );
    }

    /// <summary>
    /// 配置租户操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">租户配置操作</param>
    public static IAppBuilder AddTenant( this IAppBuilder builder, Action<TenantOptions> setupAction ) {
        builder.CheckNull( nameof( builder ) );
        var options = new TenantOptions {
            IsEnabled = true
        };
        setupAction?.Invoke( options );
        builder.Host.ConfigureServices( ( context, services ) => {
            services.TryAddSingleton<ITenantResolver, DefaultTenantResolver>();
            services.TryAddSingleton<IOptions<TenantOptions>>( new OptionsWrapper<TenantOptions>( options ) );
        } );
        return builder;
    }
}