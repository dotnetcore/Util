using Util.Helpers;

namespace Util.Tenants.Managements;

/// <summary>
/// 查看租户管理器
/// </summary>
public class ViewAllTenantManager : IViewAllTenantManager {
    /// <summary>
    /// 查看所有租户键名
    /// </summary>
    public const string Key = "x-view-all-tenant";

    /// <inheritdoc />
    public bool IsDisableTenantFilter() {
        var result = Web.GetCookie( Key );
        if ( result.IsEmpty() )
            return false;
        return result.ToBool();
    }

    /// <inheritdoc />
    public Task EnableViewAllAsync() {
        Web.SetCookie( Key,"true" );
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public Task DisableViewAllAsync() {
        Web.RemoveCookie( Key );
        return Task.CompletedTask;
    }
}