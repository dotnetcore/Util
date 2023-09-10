namespace Util.Tenants;

/// <summary>
/// 空租户管理器
/// </summary>
[Ioc( -9 )]
public class NullTenantManager : ITenantManager {
    /// <summary>
    /// 租户管理器空实例
    /// </summary>
    public static readonly ITenantManager Instance = new NullTenantManager();

    /// <inheritdoc />
    public bool Enabled() {
        return false;
    }

    /// <inheritdoc />
    public bool AllowMultipleDatabase() {
        return false;
    }

    /// <inheritdoc />
    public bool IsHost() {
        return false;
    }

    /// <inheritdoc />
    public bool IsDisableTenantFilter() {
        return false;
    }

    /// <inheritdoc />
    public string GetTenantId() {
        return null;
    }

    /// <inheritdoc />
    public TenantInfo GetTenant() {
        return null;
    }
}