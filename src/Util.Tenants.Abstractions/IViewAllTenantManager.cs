namespace Util.Tenants;

/// <summary>
/// 查看租户管理器
/// </summary>
public interface IViewAllTenantManager : ITransientDependency {
    /// <summary>
    /// 是否禁用租户过滤器
    /// </summary>
    bool IsDisableTenantFilter();
    /// <summary>
    /// 启用查看所有租户数据,仅对单一数据库模式有效
    /// </summary>
    Task EnableViewAllAsync();
    /// <summary>
    /// 禁用查看所有租户数据,仅对单一数据库模式有效
    /// </summary>
    Task DisableViewAllAsync();
}