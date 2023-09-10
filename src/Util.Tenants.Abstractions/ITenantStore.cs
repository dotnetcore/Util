namespace Util.Tenants;

/// <summary>
/// 租户存储器
/// </summary>
public interface ITenantStore : IScopeDependency {
    /// <summary>
    /// 获取当前租户配置
    /// </summary>
    /// <param name="tenantId">租户标识</param>
    TenantInfo GetTenant( string tenantId );
}