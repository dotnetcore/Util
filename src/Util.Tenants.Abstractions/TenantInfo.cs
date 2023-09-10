using Util.Data;

namespace Util.Tenants; 

/// <summary>
/// 租户信息
/// </summary>
public class TenantInfo {
    /// <summary>
    /// 租户标识
    /// </summary>
    public string TenantId { get; set; }
    /// <summary>
    /// 连接字符串集合
    /// </summary>
    public ConnectionStringCollection ConnectionStrings { get; set; }
}