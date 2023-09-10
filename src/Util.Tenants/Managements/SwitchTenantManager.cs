using Util.Helpers;

namespace Util.Tenants.Managements;

/// <summary>
/// 切换租户管理器
/// </summary>
public class SwitchTenantManager : ISwitchTenantManager {
    /// <summary>
    /// 切换租户键名
    /// </summary>
    public const string Key = "x-switch-tenant";

    /// <inheritdoc />
    public string GetSwitchTenantId() {
        return Web.GetCookie( Key );
    }

    /// <inheritdoc />
    public Task SwitchTenantAsync( string tenantId ) {
        Web.SetCookie( Key, tenantId );
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public Task ResetTenantAsync() {
        Web.RemoveCookie( Key );
        return Task.CompletedTask;
    }
}