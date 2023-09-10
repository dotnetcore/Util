using Util.Dependency;

namespace Util.Tenants.Resolvers;

/// <summary>
/// 基于域名的租户解析器
/// </summary>
public interface IDomainTenantResolver : ITransientDependency {
    /// <summary>
    /// 解析租户标识
    /// </summary>
    /// <param name="host">域名,范例: a.test.com</param>
    Task<string> ResolveTenantIdAsync( string host );
}