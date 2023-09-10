namespace Util.Tenants.Resolvers;

/// <summary>
/// 基于请求头的租户解析器
/// </summary>
public class HeaderTenantResolver : TenantResolverBase {
    /// <summary>
    /// 解析租户标识
    /// </summary>
    protected override Task<string> Resolve( HttpContext context ) {
        var key = GetTenantKey( context );
        context.Request.Headers.TryGetValue( key, out var result );
        var tenantId = result.FirstOrDefault();
        GetLog( context ).LogTrace( $"执行请求头租户解析器,{key}={tenantId}" );
        return Task.FromResult( tenantId );
    }
}