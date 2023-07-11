using Util.Configs;
using Util.Localization.Json;

namespace Util.Localization;

/// <summary>
/// 本地化操作扩展
/// </summary>
public static class AppBuilderExtensions {
    /// <summary>
    /// 配置Json本地化
    /// </summary>
    /// <param name="builder">应用生成器</param>
    public static IAppBuilder AddJsonLocalization( this IAppBuilder builder ) {
        return builder.AddJsonLocalization( "Resources" );
    }

    /// <summary>
    /// 配置Json本地化
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="resourcesPath">资源路径,默认值: Resources</param>
    public static IAppBuilder AddJsonLocalization( this IAppBuilder builder, string resourcesPath ) {
        builder.CheckNull( nameof( builder ) );
        builder.Host.ConfigureServices( ( context, services ) => {
            services.RemoveAll( typeof( IStringLocalizerFactory ) );
            services.RemoveAll( typeof( IStringLocalizer<> ) );
            services.RemoveAll( typeof( IStringLocalizer ) );
            services.TryAddSingleton<IPathResolver, PathResolver>();
            services.TryAddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();
            services.TryAddTransient( typeof( IStringLocalizer<> ), typeof( StringLocalizer<> ) );
            services.TryAddTransient( typeof( IStringLocalizer ), typeof( StringLocalizer ) );
            services.Configure<LocalizationOptions>( options => options.ResourcesPath = resourcesPath );
        } );
        return builder;
    }
}