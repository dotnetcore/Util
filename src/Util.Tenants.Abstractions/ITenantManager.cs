namespace Util.Tenants;

/// <summary>
/// 租户管理器
/// </summary>
public interface ITenantManager : IScopeDependency {
    /// <summary>
    /// 是否启用多租户架构
    /// </summary>
    bool Enabled();
    /// <summary>
    /// 是否允许使用多数据库
    /// </summary>
    bool AllowMultipleDatabase();
    /// <summary>
    /// 是否平台供应商
    /// </summary>
    bool IsHost();
    /// <summary>
    /// 获取当前租户标识
    /// </summary>
    string GetTenantId();
    /// <summary>
    /// 获取当前租户配置
    /// </summary>
    TenantInfo GetTenant();
    /// <summary>
    /// 是否禁用租户过滤器
    /// </summary>
    bool IsDisableTenantFilter();
}