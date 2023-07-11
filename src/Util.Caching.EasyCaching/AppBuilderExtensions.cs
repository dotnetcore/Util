using Util.Configs;

namespace Util.Caching.EasyCaching;

/// <summary>
/// EasyCaching缓存操作扩展
/// </summary>
public static class AppBuilderExtensions {
    /// <summary>
    /// 配置EasyCaching内存缓存操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    public static IAppBuilder AddMemoryCache( this IAppBuilder builder ) {
        return builder.AddEasyCaching( new EasyCachingOptions { IsConfigMemoryCache = true } );
    }

    /// <summary>
    /// 配置EasyCaching内存缓存操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="configuration">配置</param>
    /// <param name="section">配置节名称</param>
    public static IAppBuilder AddMemoryCache( this IAppBuilder builder, IConfiguration configuration, string section ) {
        return builder.AddEasyCaching( new EasyCachingOptions { Configuration = configuration, MemoryConfigSection = section } );
    }

    /// <summary>
    /// 配置EasyCaching内存缓存操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">内存缓存配置操作</param>
    public static IAppBuilder AddMemoryCache( this IAppBuilder builder, Action<InMemoryOptions> setupAction ) {
        return builder.AddEasyCaching( new EasyCachingOptions { MemoryCacheSetupAction = setupAction } );
    }

    /// <summary>
    /// 配置EasyCaching Redis缓存操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="configuration">配置</param>
    /// <param name="section">配置节名称</param>
    public static IAppBuilder AddRedisCache( this IAppBuilder builder, IConfiguration configuration, string section ) {
        return builder.AddEasyCaching( new EasyCachingOptions { Configuration = configuration, RedisConfigSection = section } );
    }

    /// <summary>
    /// 配置EasyCaching Redis缓存操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">Redis缓存配置操作</param>
    public static IAppBuilder AddRedisCache( this IAppBuilder builder, Action<RedisOptions> setupAction ) {
        return builder.AddEasyCaching( new EasyCachingOptions { RedisCacheSetupAction = setupAction } );
    }

    /// <summary>
    /// 配置EasyCaching缓存操作
    /// </summary>
    private static IAppBuilder AddEasyCaching( this IAppBuilder builder, EasyCachingOptions easyCachingOptions ) {
        builder.CheckNull( nameof( builder ) );
        builder.Host.ConfigureServices( ( context, services ) => {
            services.TryAddSingleton<ICache, CacheManager>();
            services.TryAddSingleton<ILocalCache, MemoryCacheManager>();
            services.TryAddSingleton<IRedisCache, RedisCacheManager>();
            services.TryAddSingleton<ICacheKeyGenerator, CacheKeyGenerator>();
            services.AddEasyCaching( options => ConfigEasyCaching( easyCachingOptions, options ) );
            services.TryAddSingleton<IEasyCachingKeyGenerator, DefaultEasyCachingKeyGenerator>();
        } );
        return builder;
    }

    /// <summary>
    /// 配置缓存
    /// </summary>
    private static void ConfigEasyCaching( EasyCachingOptions easyCachingOptions, EasyCachingConfig.EasyCachingOptions options ) {
        ConfigMemoryCache( easyCachingOptions,options );
        ConfigRedisCache( easyCachingOptions,options );
    }

    /// <summary>
    /// 配置内存缓存
    /// </summary>
    private static void ConfigMemoryCache( EasyCachingOptions easyCachingOptions, EasyCachingConfig.EasyCachingOptions options ) {
        if ( easyCachingOptions.Configuration != null && easyCachingOptions.MemoryConfigSection.IsEmpty() == false ) {
            options.UseInMemory( easyCachingOptions.Configuration, CacheProviderKey.MemoryCache, easyCachingOptions.MemoryConfigSection );
            return;
        }
        if ( easyCachingOptions.MemoryCacheSetupAction != null ) {
            options.UseInMemory( easyCachingOptions.MemoryCacheSetupAction, CacheProviderKey.MemoryCache );
            return;
        }
        if ( easyCachingOptions.IsConfigMemoryCache ) {
            options.UseInMemory( CacheProviderKey.MemoryCache );
        }
    }

    /// <summary>
    /// 配置Redis缓存
    /// </summary>
    private static void ConfigRedisCache( EasyCachingOptions easyCachingOptions, EasyCachingConfig.EasyCachingOptions options ) {
        if ( easyCachingOptions.Configuration != null && easyCachingOptions.RedisConfigSection.IsEmpty() == false ) {
            ConfigRedisSerializer( options );
            options.UseRedis( easyCachingOptions.Configuration, CacheProviderKey.RedisCache, easyCachingOptions.RedisConfigSection );
            return;
        }
        if ( easyCachingOptions.RedisCacheSetupAction == null )
            return;
        ConfigRedisSerializer( options );
        options.UseRedis( easyCachingOptions.RedisCacheSetupAction, CacheProviderKey.RedisCache );
    }

    /// <summary>
    /// 配置Redis序列化
    /// </summary>
    private static void ConfigRedisSerializer( EasyCachingConfig.EasyCachingOptions options ) {
        options.WithSystemTextJson( t => t.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, CacheProviderKey.RedisCache );
    }
}