namespace Util.Data.EntityFrameworkCore; 

/// <summary>
/// 过滤器操作扩展
/// </summary>
public static class FilterExtensions {
    /// <summary>
    /// 启用逻辑删除过滤器
    /// </summary>
    /// <param name="source">源</param>
    public static void EnableDeleteFilter( this IFilterOperation source ) {
        source.EnableFilter<IDelete>();
    }

    /// <summary>
    /// 禁用逻辑删除过滤器
    /// </summary>
    /// <param name="source">源</param>
    public static IDisposable DisableDeleteFilter( this IFilterOperation source ) {
        return source.DisableFilter<IDelete>();
    }

    /// <summary>
    /// 启用租户过滤器
    /// </summary>
    /// <param name="source">源</param>
    public static void EnableTenantFilter( this IFilterOperation source ) {
        source.EnableFilter<ITenant>();
    }

    /// <summary>
    /// 禁用租户过滤器
    /// </summary>
    /// <param name="source">源</param>
    public static IDisposable DisableTenantFilter( this IFilterOperation source ) {
        return source.DisableFilter<ITenant>();
    }
}