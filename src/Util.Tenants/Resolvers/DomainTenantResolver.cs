namespace Util.Tenants.Resolvers;

/// <summary>
/// 基于域名的租户解析器
/// </summary>
public class DomainTenantResolver : TenantResolverBase {
    /// <summary>
    /// 初始化基于域名的租户解析器
    /// </summary>
    public DomainTenantResolver() {
    }

    /// <summary>
    /// 初始化基于域名的租户解析器
    /// </summary>
    /// <param name="domainFormat">域名格式字符串,范例:{0}.a.com</param>
    public DomainTenantResolver( string domainFormat ) {
        DomainFormat = domainFormat;
    }

    /// <summary>
    /// 初始化基于域名的租户解析器
    /// </summary>
    /// <param name="domainMap">域名映射配置,键为域名,值为租户标识</param>
    public DomainTenantResolver( IDictionary<string, string> domainMap ) {
        DomainMap = domainMap;
    }

    /// <summary>
    /// 域名格式字符串
    /// </summary>
    public string DomainFormat { get; }

    /// <summary>
    /// 域名映射配置
    /// </summary>
    public IDictionary<string, string> DomainMap { get; }

    /// <summary>
    /// 解析租户标识
    /// </summary>
    protected override async Task<string> Resolve( HttpContext context ) {
        var host = DomainTenantResolverHelper.RemoveDomainPrefix( context.Request.Host.Value );
        if ( host.IsEmpty() )
            return null;
        var result = await Resolve( context, host );
        GetLog( context ).LogTrace( $"执行域名租户解析器,host={host},tenantId={result}" );
        return result;
    }

    /// <summary>
    /// 解析租户标识
    /// </summary>
    private async Task<string> Resolve( HttpContext context, string host ) {
        var store = context.RequestServices.GetService<ITenantDomainStore>();
        var map = await DomainTenantResolverHelper.CombineMapAsync( DomainMap,store );
        return DomainTenantResolverHelper.ResolveTenantId( host, map, DomainFormat );
    }
}