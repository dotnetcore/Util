using Util.Tenants.Middlewares;

namespace Util.Tenants;

/// <summary>
/// 租户处理中间件扩展
/// </summary>
public static class TenantMiddlewareExtensions {
    /// <summary>
    /// 注册租户处理中间件,注意: 必须在 app.UseAuthentication() 之后调用
    /// </summary>
    /// <param name="builder">应用程序生成器</param>
    public static IApplicationBuilder UseTenant( this IApplicationBuilder builder ) {
        return builder.UseMiddleware<TenantMiddleware>();
    }
}