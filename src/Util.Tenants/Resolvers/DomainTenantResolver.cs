namespace Util.Tenants.Resolvers;

/// <summary>
/// 基于域名的租户解析器
/// </summary>
public class DomainTenantResolver : TenantResolverBase {
    /// <summary>
    /// 域名格式字符串
    /// </summary>
    private readonly string _domainFormat;
    /// <summary>
    /// 域名映射配置
    /// </summary>
    private readonly IDictionary<string, string> _domainMap;

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
        _domainFormat = domainFormat;
    }

    /// <summary>
    /// 初始化基于域名的租户解析器
    /// </summary>
    /// <param name="domainMap">域名映射配置,键为域名,值为租户标识</param>
    public DomainTenantResolver( IDictionary<string, string> domainMap ) {
        _domainMap = domainMap;
    }

    /// <summary>
    /// 解析租户标识
    /// </summary>
    protected override async Task<string> Resolve( HttpContext context ) {
        var host = GetDomain( context.Request.Host.Value );
        if ( host.IsEmpty() )
            return null;
        var result = await Resolve( context,host );
        GetLog( context ).LogTrace( $"执行域名租户解析器,host={host},tenantId={result}" );
        return result;
    }

    /// <summary>
    /// 获取域名
    /// </summary>
    private string GetDomain( string domain ) {
        return domain.RemoveStart( "http://" ).RemoveStart( "https://" );
    }

    /// <summary>
    /// 解析租户标识
    /// </summary>
    private async Task<string> Resolve( HttpContext context, string host ) {
        if ( _domainMap != null )
            return ResolveByMap( host );
        if ( _domainFormat.IsEmpty() == false )
            return ResolveByFormat( host );
        var resolver = context.RequestServices.GetService<IDomainTenantResolver>();
        return resolver == null ? ResolveBySplit( host ) : await resolver.ResolveTenantIdAsync( host );
    }

    /// <summary>
    /// 通过域名映射配置解析
    /// </summary>
    private string ResolveByMap( string host ) {
        foreach ( var item in _domainMap ) {
            if ( item.Key == host )
                return item.Value;
        }
        return null;
    }

    /// <summary>
    /// 通过域名格式字符串解析
    /// </summary>
    private string ResolveByFormat( string host ) {
        var formats = GetDomainFormats();
        foreach ( var format in formats ) {
            if ( format.IsEmpty() )
                continue;
            var result = Util.Helpers.String.Extract( host, GetDomain( format ) ).FirstOrDefault().Value;
            if( result.IsEmpty() == false )
                return result;
        }
        return null;
    }

    /// <summary>
    /// 获取域名格式列表
    /// </summary>
    private IEnumerable<string> GetDomainFormats() {
        if ( _domainFormat.IndexOf( ",", StringComparison.Ordinal ) >= 0 )
            return _domainFormat.Split( ',' );
        if ( _domainFormat.IndexOf( ";", StringComparison.Ordinal ) >= 0 )
            return _domainFormat.Split( ';' );
        return new[] { _domainFormat };
    }

    /// <summary>
    /// 通过拆分解析
    /// </summary>
    private string ResolveBySplit( string host ) {
        var items = host.Split( '.' );
        if ( items.Length > 2 )
            return items[0];
        return null;
    }
}