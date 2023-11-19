namespace Util.Caching.EasyCaching;

/// <summary>
/// EasyCaching缓存操作扩展
/// </summary>
public static class AppBuilderExtensions {

    #region 字段

    /// <summary>
    /// 最大随机秒数
    /// </summary>
    public static int MaxRdSecond = 1200;

    #endregion

    #region AddMemoryCache

    /// <summary>
    /// 配置EasyCaching内存缓存操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    public static IAppBuilder AddMemoryCache( this IAppBuilder builder ) {
        return builder.AddMemoryCache( options => {
            options.MaxRdSecond = MaxRdSecond;
            options.CacheNulls = true;
        } );
    }

    /// <summary>
    /// 配置EasyCaching内存缓存操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="configuration">配置</param>
    /// <param name="section">配置节名称,默认值: "EasyCaching:Memory"</param>
    public static IAppBuilder AddMemoryCache( this IAppBuilder builder, IConfiguration configuration, string section = "EasyCaching:Memory" ) {
        builder.CheckNull( nameof( builder ) );
        builder.Host.ConfigureServices( ( context, services ) => {
            ConfigCommonService( services );
            services.TryAddSingleton<ILocalCache, MemoryCacheManager>();
            services.AddEasyCaching( options => options.UseInMemory( configuration, CacheProviderKey.MemoryCache, section ) );
        } );
        return builder;
    }

    /// <summary>
    /// 配置公共服务
    /// </summary>
    private static void ConfigCommonService( IServiceCollection services ) {
        services.TryAddSingleton<ICache, CacheManager>();
        services.TryAddSingleton<ICacheKeyGenerator, CacheKeyGenerator>();
        services.TryAddSingleton<IEasyCachingKeyGenerator, DefaultEasyCachingKeyGenerator>();
    }

    /// <summary>
    /// 配置EasyCaching内存缓存操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">内存缓存配置操作</param>
    public static IAppBuilder AddMemoryCache( this IAppBuilder builder, Action<InMemoryOptions> setupAction ) {
        builder.CheckNull( nameof( builder ) );
        builder.Host.ConfigureServices( ( context, services ) => {
            ConfigCommonService( services );
            services.TryAddSingleton<ILocalCache, MemoryCacheManager>();
            services.AddEasyCaching( options => options.UseInMemory( setupAction ) );
        } );
        return builder;
    }

    #endregion

    #region AddRedisCache

    /// <summary>
    /// 配置EasyCaching Redis缓存操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="host">Redis服务地址,范例: 127.0.0.1</param>
    /// <param name="port">Redis服务端口,默认值: 6379</param>
    /// <param name="keyPrefix">缓存键前缀,默认值: null</param>
    public static IAppBuilder AddRedisCache( this IAppBuilder builder, string host,int port = 6379, string keyPrefix = null ) {
        return builder.AddRedisCache( options => {
            options.MaxRdSecond = MaxRdSecond;
            options.CacheNulls = true;
            options.DBConfig.AllowAdmin = true;
            options.DBConfig.KeyPrefix = keyPrefix;
            options.DBConfig.Endpoints.Add( new ServerEndPoint( host, port ) );
        } );
    }

    /// <summary>
    /// 配置EasyCaching Redis缓存操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="configuration">配置</param>
    /// <param name="section">配置节名称,默认值: "EasyCaching:Redis"</param>
    public static IAppBuilder AddRedisCache( this IAppBuilder builder, IConfiguration configuration, string section = "EasyCaching:Redis" ) {
        builder.CheckNull( nameof( builder ) );
        CachingOptions.AddRedisEndPoints( configuration,section );
        builder.Host.ConfigureServices( ( context, services ) => {
            ConfigCommonService( services );
            services.TryAddSingleton<IRedisCache, RedisCacheManager>();
            services.AddEasyCaching( options => {
                var serializerNameKey = $"{section}:SerializerName";
                var serializerName = configuration[serializerNameKey];
                if ( serializerName.IsEmpty() ) 
                    configuration[serializerNameKey] = CacheProviderKey.SystemTextJson;
                options.UseRedis( configuration, CacheProviderKey.RedisCache, section );
                ConfigRedisSerializer( options );
            } );
        } );
        return builder;
    }

    /// <summary>
    /// 配置Redis序列化
    /// </summary>
    private static void ConfigRedisSerializer( EasyCachingOptions options ) {
        options.WithSystemTextJson( t => t.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, CacheProviderKey.SystemTextJson );
    }

    /// <summary>
    /// 配置EasyCaching Redis缓存操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">Redis缓存配置操作</param>
    public static IAppBuilder AddRedisCache( this IAppBuilder builder, Action<RedisOptions> setupAction ) {
        builder.CheckNull( nameof( builder ) );
        CachingOptions.AddRedisEndPoints( setupAction );
        builder.Host.ConfigureServices( ( context, services ) => {
            ConfigCommonService( services );
            services.TryAddSingleton<IRedisCache, RedisCacheManager>();
            services.AddEasyCaching( options => {
                ConfigRedisSerializer( options );
                options.UseRedis( redisOptions => {
                    redisOptions.SerializerName = CacheProviderKey.SystemTextJson;
                    setupAction( redisOptions );
                } );
            } );
        } );
        return builder;
    }

    #endregion

    #region AddHybridCache

    /// <summary>
    /// 配置EasyCaching 2级缓存操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="topicName">订阅主题,默认值: "EasyCachingHybridCache"</param>
    public static IAppBuilder AddHybridCache( this IAppBuilder builder,string topicName= "EasyCachingHybridCache" ) {
        return builder.AddHybridCache( hybridOptions => {
            hybridOptions.LocalCacheProviderName = CacheProviderKey.MemoryCache;
            hybridOptions.DistributedCacheProviderName = CacheProviderKey.RedisCache;
            hybridOptions.TopicName = topicName;
        }, redisBusOptions => {
            CachingOptions.GetRedisEndPoints().ForEach( endpoint => {
                redisBusOptions.Endpoints.Add( endpoint );
            } );
            redisBusOptions.SerializerName = CacheProviderKey.SystemTextJson;
        } );
    }

    /// <summary>
    /// 配置EasyCaching 2级缓存操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="configuration">配置</param>
    /// <param name="hybridSection">2级缓存配置节名称,默认值: "EasyCaching:Hybrid"</param>
    /// <param name="redisBusSection">Redis总线配置节名称,默认值: "EasyCaching:RedisBus"</param>
    public static IAppBuilder AddHybridCache( this IAppBuilder builder, IConfiguration configuration, 
            string hybridSection = "EasyCaching:Hybrid", string redisBusSection = "EasyCaching:RedisBus" ) {
        builder.CheckNull( nameof( builder ) );
        builder.Host.ConfigureServices( ( context, services ) => {
            services.AddEasyCaching( options => {
                options.UseHybrid( configuration, CacheProviderKey.HybridCache, hybridSection );
                options.WithRedisBus( configuration, CacheProviderKey.RedisBus, redisBusSection );
            } );
        } );
        return builder;
    }

    /// <summary>
    /// 配置EasyCaching 2级缓存操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="hybridConfigAction">2缓存配置操作</param>
    /// <param name="redisBusConfigAction">Redis总线配置操作</param>
    public static IAppBuilder AddHybridCache( this IAppBuilder builder, Action<HybridCachingOptions> hybridConfigAction, Action<RedisBusOptions> redisBusConfigAction ) {
        builder.CheckNull( nameof( builder ) );
        builder.Host.ConfigureServices( ( context, services ) => {
            services.AddEasyCaching( options => {
                options.UseHybrid( hybridConfigAction );
                options.WithRedisBus( redisBusConfigAction );
            } );
        } );
        return builder;
    }

    #endregion
}