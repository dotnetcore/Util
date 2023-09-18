using Util.Tenants.Resolvers;

namespace Util.Tenants;

/// <summary>
/// 租户配置
/// </summary>
public class TenantOptions {
    /// <summary>
    /// 初始化租户配置
    /// </summary>
    public TenantOptions() {
        TenantKey = DefaultTenantKey;
        Resolvers = new TenantResolverCollection {
            new HeaderTenantResolver{ Priority = 9 },
            new QueryStringTenantResolver{ Priority = 7 },
            new CookieTenantResolver{ Priority = 5 }
        };
    }

    /// <summary>
    /// 租户配置空实例
    /// </summary>
    public static readonly TenantOptions Null = new();

    /// <summary>
    /// 默认租户键名,默认值: x-tenant-id
    /// </summary>
    public const string DefaultTenantKey = "x-tenant-id";

    /// <summary>
    /// 是否启用多租户架构
    /// </summary>
    public bool IsEnabled { get; set; }

    /// <summary>
    /// 是否允许使用多数据库
    /// </summary>
    public bool IsAllowMultipleDatabase { get; set; }

    /// <summary>
    /// 默认租户标识
    /// </summary>
    public string DefaultTenantId { get; set; }

    /// <summary>
    /// 租户键名,默认值: x-tenant-id
    /// </summary>
    public string TenantKey { get; set; }

    /// <summary>
    /// 租户解析器集合
    /// </summary>
    public TenantResolverCollection Resolvers { get; }
}