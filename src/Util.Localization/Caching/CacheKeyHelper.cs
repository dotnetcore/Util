namespace Util.Localization.Caching;

/// <summary>
/// 缓存键辅助操作
/// </summary>
internal static class CacheKeyHelper {
    /// <summary>
    /// 获取缓存键
    /// </summary>
    /// <param name="culture">区域文化</param>
    /// <param name="type">资源类型</param>
    /// <param name="name">资源名称</param>
    public static string GetCacheKey( string culture, string type, string name ) {
        return $"{culture}-{type}-{name}";
    }
}