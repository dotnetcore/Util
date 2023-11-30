using Util.Localization.Json;
using Util.Localization.Store;

namespace Util.Localization;

/// <summary>
/// 本地化操作扩展
/// </summary>
public static class AppBuilderExtensions {

    #region AddJsonLocalization

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
        return builder.AddJsonLocalization( t => t.ResourcesPath = resourcesPath );
    }

    /// <summary>
    /// 配置Json本地化
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">Json本地化配置操作</param>
    public static IAppBuilder AddJsonLocalization( this IAppBuilder builder, Action<JsonLocalizationOptions> setupAction ) {
        builder.CheckNull( nameof( builder ) );
        var options = new JsonLocalizationOptions();
        setupAction?.Invoke( options );
        builder.Host.ConfigureServices( ( context, services ) => {
            if ( setupAction != null ) {
                services.Configure( setupAction );
                void Action( LocalizationOptions localizationOptions ) {
                    localizationOptions.Expiration = options.Expiration;
                    localizationOptions.IsLocalizeWarning = options.IsLocalizeWarning;
                    localizationOptions.Cultures = options.Cultures;
                }
                services.Configure( (Action<LocalizationOptions>)Action );
            }
            services.AddMemoryCache();
            services.RemoveAll( typeof( IStringLocalizerFactory ) );
            services.RemoveAll( typeof( IStringLocalizer<> ) );
            services.RemoveAll( typeof( IStringLocalizer ) );
            services.TryAddSingleton<IPathResolver, PathResolver>();
            services.TryAddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();
            services.TryAddTransient( typeof( IStringLocalizer<> ), typeof( StringLocalizer<> ) );
            services.TryAddTransient( typeof( IStringLocalizer ), typeof( StringLocalizer ) );
        } );
        if( options.Cultures == null || options.Cultures.Count == 0 )
            return builder;
        builder.Host.ConfigureServices( ( _, services ) => {
            ConfigRequestLocalization( services, options );
        } );
        return builder;
    }

    /// <summary>
    /// 配置请求本地化
    /// </summary>
    private static void ConfigRequestLocalization( IServiceCollection services, LocalizationOptions options ) {
        services.Configure<RequestLocalizationOptions>( localizationOptions => {
            var supportedCultures = options.Cultures.Select( culture => new CultureInfo( culture ) ).ToList();
            localizationOptions.DefaultRequestCulture = new RequestCulture( culture: supportedCultures[0], uiCulture: supportedCultures[0] );
            localizationOptions.SupportedCultures = supportedCultures;
            localizationOptions.SupportedUICultures = supportedCultures;
            localizationOptions.AddInitialRequestCultureProvider( new CustomRequestCultureProvider( async context => {
                var culture = context.Request.Headers.ContentLanguage.FirstOrDefault();
                if ( culture.IsEmpty() )
                    culture = "zh-CN";
                return await Task.FromResult( new ProviderCultureResult( culture ) );
            } ) );
        } );
    }

    #endregion

    #region AddStoreLocalization

    /// <summary>
    /// 配置基于数据存储的本地化
    /// </summary>
    /// <param name="builder">应用生成器</param>
    public static IAppBuilder AddStoreLocalization<TStore>( this IAppBuilder builder ) where TStore : ILocalizedStore {
        return builder.AddStoreLocalization<TStore>( options => options.Expiration = 28800 );
    }

    /// <summary>
    /// 配置基于数据存储的本地化
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">本地化配置操作</param>
    public static IAppBuilder AddStoreLocalization<TStore>( this IAppBuilder builder, Action<LocalizationOptions> setupAction ) where TStore : ILocalizedStore {
        builder.CheckNull( nameof( builder ) );
        var options = new LocalizationOptions();
        setupAction?.Invoke( options );
        builder.Host.ConfigureServices( ( context, services ) => {
            if ( setupAction != null )
                services.Configure( setupAction );
            services.AddMemoryCache();
            services.RemoveAll( typeof( IStringLocalizerFactory ) );
            services.RemoveAll( typeof( IStringLocalizer<> ) );
            services.RemoveAll( typeof( IStringLocalizer ) );
            services.TryAddSingleton<IStringLocalizerFactory, StoreStringLocalizerFactory>();
            services.TryAddTransient( typeof( IStringLocalizer<> ), typeof( StringLocalizer<> ) );
            services.TryAddTransient( typeof( IStringLocalizer ), typeof( StringLocalizer ) );
            services.TryAddTransient( typeof( ILocalizedStore ), typeof( TStore ) );
            services.TryAddTransient<ILocalizedManager, LocalizedManager>();
        } );
        builder.Host.ConfigureServices( ( _, services ) => {
            if ( options.Cultures == null || options.Cultures.Count == 0 )
                return;
            ConfigRequestLocalization( services, options );
        } );
        return builder;
    }

    #endregion
}