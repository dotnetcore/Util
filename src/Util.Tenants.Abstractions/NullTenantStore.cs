namespace Util.Tenants;

/// <summary>
/// 空租户存储器
/// </summary>
[Ioc(-9)]
public class NullTenantStore : ITenantStore {
    /// <summary>
    /// 空租户存储器
    /// </summary>
    public static readonly ITenantStore Instance = new NullTenantStore();

    /// <summary>
    /// 获取当前租户配置
    /// </summary>
    /// <param name="tenantId">租户标识</param>
    public TenantInfo GetTenant( string tenantId ) {
        return null;
    }
}