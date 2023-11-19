namespace Util.Caching.EasyCaching; 

/// <summary>
/// 缓存提供器标识
/// </summary>
public static class CacheProviderKey {
    /// <summary>
    /// 内存缓存提供器标识
    /// </summary>
    public const string MemoryCache = "DefaultInMemory";
    /// <summary>
    /// Redis缓存提供器标识
    /// </summary>
    public const string RedisCache = "DefaultRedis";
    /// <summary>
    /// Hybrid缓存提供器标识
    /// </summary>
    public const string HybridCache = "DefaultHybrid";
    /// <summary>
    /// Redis总线提供器标识
    /// </summary>
    public const string RedisBus = "DefaultRedis";
    /// <summary>
    /// SystemTextJson序列化提供程序标识
    /// </summary>
    public const string SystemTextJson = "SystemTextJson";
}