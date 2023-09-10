namespace Util.Tenants.Resolvers;

/// <summary>
/// 租户解析器
/// </summary>
public abstract class TenantResolverBase : ITenantResolver {
    /// <inheritdoc />
    public int Priority { get; set; }

    /// <inheritdoc />
    public async Task<string> ResolveAsync( HttpContext context ) {
        if ( context == null )
            return null;
        return await Resolve( context );
    }

    /// <summary>
    /// 解析租户标识
    /// </summary>
    protected abstract Task<string> Resolve( HttpContext context );

    /// <summary>
    /// 获取租户键名
    /// </summary>
    protected string GetTenantKey( HttpContext context ) {
        var options = context.RequestServices.GetRequiredService<IOptions<TenantOptions>>();
        return options.Value.TenantKey;
    }

    /// <summary>
    /// 获取日志记录器
    /// </summary>
    protected ILogger<ITenantResolver> GetLog( HttpContext context ) {
        return context.RequestServices.GetService<ILogger<ITenantResolver>>() ?? NullLogger<ITenantResolver>.Instance;
    }
}