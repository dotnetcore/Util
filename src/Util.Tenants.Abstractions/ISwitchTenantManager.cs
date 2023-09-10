namespace Util.Tenants;

/// <summary>
/// 切换租户管理器
/// </summary>
public interface ISwitchTenantManager : ITransientDependency {
    /// <summary>
    /// 获取切换的租户标识
    /// </summary>
    string GetSwitchTenantId();
    /// <summary>
    /// 切换租户标识
    /// </summary>
    /// <param name="tenantId">租户标识</param>
    Task SwitchTenantAsync( string tenantId );
    /// <summary>
    /// 重置租户标识
    /// </summary>
    Task ResetTenantAsync();
}