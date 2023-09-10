namespace Util.Tenants.Resolvers; 

/// <summary>
/// 基于Cookie的租户解析器
/// </summary>
public class CookieTenantResolver : TenantResolverBase {
    /// <summary>
    /// 解析租户标识
    /// </summary>
    protected override Task<string> Resolve( HttpContext context ) {
        var key = GetTenantKey( context );
        var tenantId = context.Request.Cookies[key];
        GetLog( context ).LogTrace( $"执行Cookie租户解析器,{key}={tenantId}" );
        return Task.FromResult( tenantId );
    }
}