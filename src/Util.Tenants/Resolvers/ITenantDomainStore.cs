using Util.Dependency;

namespace Util.Tenants.Resolvers;

/// <summary>
/// 租户域名存储器
/// </summary>
public interface ITenantDomainStore : ITransientDependency {
    /// <summary>
    /// 获取租户域名映射,键为域名,值为租户标识
    /// </summary>
    Task<IDictionary<string, string>> GetAsync();
}