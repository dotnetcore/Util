namespace Util.Tenants; 

/// <summary>
/// 租户解析器
/// </summary>
public interface ITenantResolver {
    /// <summary>
    /// 解析租户标识
    /// </summary>
    /// <param name="context">Http上下文</param>
    Task<string> ResolveAsync( HttpContext context );
    /// <summary>
    /// 优先级,值越大则优先解析
    /// </summary>
    int Priority { get; set; }
}