namespace Util.Tenants.Resolvers;

/// <summary>
/// 默认租户解析器
/// </summary>
public class DefaultTenantResolver : ITenantResolver {
    /// <summary>
    /// 租户配置
    /// </summary>
    private readonly TenantOptions _options;
    /// <inheritdoc />
    public int Priority { get; set; }

    /// <summary>
    /// 初始化默认租户解析器
    /// </summary>
    /// <param name="options">租户配置</param>
    public DefaultTenantResolver( IOptions<TenantOptions> options ) {
        _options = options?.Value ?? TenantOptions.Null;
    }

    /// <inheritdoc />
    public async Task<string> ResolveAsync( HttpContext context ) {
        if ( context == null )
            return null;
        if ( _options.IsEnabled == false )
            return null;
        var session = context.RequestServices.GetService<Util.Sessions.ISession>();
        if ( session is { IsAuthenticated: true } )
            return session.TenantId;
        if ( _options.Resolvers == null )
            return null;
        foreach ( var resolver in _options.Resolvers.OrderByDescending( t => t.Priority ) ) {
            var result = await resolver.ResolveAsync( context );
            if ( result.IsEmpty() == false )
                return result;
        }
        return null;
    }
}