using Util.Dependency;

namespace Util.Tenants.Resolvers;

/// <summary>
/// 空租户域名存储器
/// </summary>
[Ioc(-9)]
public class NullTenantDomainStore : ITenantDomainStore {
    /// <summary>
    /// 结果
    /// </summary>
    private readonly IDictionary<string, string> _result;

    /// <summary>
    /// 初始化空租户域名存储器
    /// </summary>
    public NullTenantDomainStore() {
        _result = new Dictionary<string, string>();
    }

    /// <summary>
    /// 空租户域名存储器
    /// </summary>
    public static readonly ITenantDomainStore Instance = new NullTenantDomainStore();

    /// <inheritdoc />
    public Task<IDictionary<string, string>> GetAsync() {
        return Task.FromResult(_result);
    }
}