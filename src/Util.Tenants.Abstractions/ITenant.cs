namespace Util.Tenants; 

/// <summary>
/// 租户
/// </summary>
public interface ITenant {
    /// <summary>
    /// 租户标识
    /// </summary>
    string TenantId { get; set; }
}