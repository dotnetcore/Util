namespace Util.Tenants.Resolvers;

/// <summary>
/// 基于查询字符串的租户解析器
/// </summary>
public class QueryStringTenantResolver : TenantResolverBase {
    /// <summary>
    /// 解析租户标识
    /// </summary>
    protected override Task<string> Resolve( HttpContext context ) {
        var key = GetTenantKey( context );
        var tenantId = context.Request.Query[key].FirstOrDefault();
        GetLog( context ).LogTrace( $"执行查询字符串租户解析器,{key}={tenantId}" );
        return Task.FromResult( tenantId );
    }
}