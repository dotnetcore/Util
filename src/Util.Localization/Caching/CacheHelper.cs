namespace Util.Localization.Caching;

/// <summary>
/// 缓存辅助操作
/// </summary>
internal static class CacheHelper {
    /// <summary>
    /// 获取缓存键
    /// </summary>
    /// <param name="culture">区域文化</param>
    /// <param name="type">资源类型</param>
    /// <param name="name">资源名称</param>
    public static string GetCacheKey( string culture, string type, string name ) {
        return $"{culture}-{type}-{name}";
    }

    /// <summary>
    /// 获取缓存过期时间间隔
    /// </summary>
    public static int GetExpiration( LocalizationOptions options ) {
        return options.Expiration + Random.Shared.Next( 1200 );
    }
}