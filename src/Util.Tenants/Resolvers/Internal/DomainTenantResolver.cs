namespace Util.Tenants.Resolvers.Internal;

/// <summary>
/// 域名租户解析器
/// </summary>
internal class DomainTenantResolver : IDomainTenantResolver {
    /// <summary>
    /// 租户域名存储器
    /// </summary>
    private readonly ITenantDomainStore _store;
    /// <summary>
    /// 租户配置
    /// </summary>
    private readonly TenantOptions _options;

    /// <summary>
    /// 初始化域名租户解析器
    /// </summary>
    /// <param name="store">租户域名存储器</param>
    /// <param name="options">租户配置</param>
    public DomainTenantResolver( ITenantDomainStore store, IOptions<TenantOptions> options ) {
        _store = store ?? throw new ArgumentNullException( nameof( store ) );
        _options = options?.Value ?? new TenantOptions();
    }

    /// <inheritdoc />
    public async Task<string> ResolveTenantIdAsync( string host ) {
        if ( host.IsEmpty() )
            return null;
        var domainMap = new Dictionary<string, string>();
        var domainFormat = string.Empty;
        var resolvers = _options.Resolvers.GetResolvers<Resolvers.DomainTenantResolver>();
        foreach ( var resolver in resolvers ) {
            if ( resolver.DomainMap != null ) {
                foreach ( var item in resolver.DomainMap ) {
                    domainMap.Add( item.Key, item.Value );
                }
            }
            domainFormat += $",{resolver.DomainFormat}";
        }
        var map = await DomainTenantResolverHelper.CombineMapAsync( domainMap, _store );
        return DomainTenantResolverHelper.ResolveTenantId( host, map, domainFormat );
    }
}