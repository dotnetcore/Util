namespace Util.Tenants.Resolvers;

/// <summary>
/// 租户域名解析器辅助操作
/// </summary>
public class DomainTenantResolverHelper {
    /// <summary>
    /// 解析租户标识
    /// </summary>
    /// <param name="domain">域名</param>
    /// <param name="domainMap">域名映射配置</param>
    /// <param name="domainFormat">域名格式字符串</param>
    public static string ResolveTenantId( string domain, IDictionary<string, string> domainMap, string domainFormat ) {
        if ( domain.IsEmpty() )
            return null;
        var host = RemoveDomainPrefix( domain );
        if ( host.IsEmpty() )
            return null;
        if ( domainMap is { Count: > 0 } ) {
            var result = ResolveByMap( host, domainMap );
            if ( result.IsEmpty() == false )
                return result;
        }
        domainFormat = domainFormat.RemoveStart( "," ).RemoveEnd( "," );
        return domainFormat.IsEmpty() ? ResolveBySplit( host ): ResolveByFormat( host, domainFormat );
    }

    /// <summary>
    /// 移除域名前缀
    /// </summary>
    public static string RemoveDomainPrefix( string domain ) {
        return domain.RemoveStart( "http://" ).RemoveStart( "https://" );
    }

    /// <summary>
    /// 通过域名映射配置解析
    /// </summary>
    private static string ResolveByMap( string host, IDictionary<string, string> domainMap ) {
        foreach ( var item in domainMap ) {
            if ( item.Key == host )
                return item.Value;
        }
        return null;
    }

    /// <summary>
    /// 通过域名格式字符串解析
    /// </summary>
    private static string ResolveByFormat( string host, string domainFormat ) {
        var formats = GetDomainFormats( domainFormat );
        foreach ( var format in formats ) {
            if ( format.IsEmpty() )
                continue;
            var result = Util.Helpers.String.Extract( host, RemoveDomainPrefix( format ) ).FirstOrDefault().Value;
            if ( result.IsEmpty() == false )
                return result;
        }
        return null;
    }

    /// <summary>
    /// 获取域名格式列表
    /// </summary>
    private static IEnumerable<string> GetDomainFormats( string domainFormat ) {
        if ( domainFormat.IndexOf( ",", StringComparison.Ordinal ) >= 0 )
            return domainFormat.Split( ',' );
        if ( domainFormat.IndexOf( ";", StringComparison.Ordinal ) >= 0 )
            return domainFormat.Split( ';' );
        return new[] { domainFormat };
    }

    /// <summary>
    /// 通过拆分解析
    /// </summary>
    private static string ResolveBySplit( string host ) {
        var items = host.Split( '.' );
        if ( items.Length > 2 )
            return items[0];
        return null;
    }

    /// <summary>
    /// 合并域名映射字典和租户域名存储器中的域名映射项
    /// </summary>
    /// <param name="domainMap">域名映射字典</param>
    /// <param name="store">租户域名存储器</param>
    public static async Task<IDictionary<string, string>> CombineMapAsync( IDictionary<string, string> domainMap, ITenantDomainStore store) {
        if ( store == null )
            return domainMap;
        var map = await store.GetAsync();
        if ( map == null || map.Count == 0 )
            return domainMap;
        domainMap ??= new Dictionary<string, string>();
        foreach ( var item in map ) {
            if ( domainMap.ContainsKey( item.Key ) == false ) {
                domainMap.Add( item.Key, item.Value );
            }
        }
        return domainMap;
    }
}