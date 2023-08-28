namespace Util.Security.Authorization; 

/// <summary>
/// 授权中间件结果处理器
/// </summary>
public class AclMiddlewareResultHandler : IAuthorizationMiddlewareResultHandler {
    /// <summary>
    /// 默认处理器
    /// </summary>
    private readonly AuthorizationMiddlewareResultHandler defaultHandler = new();

    /// <summary>
    /// 处理授权结果
    /// </summary>
    public async Task HandleAsync( RequestDelegate next, HttpContext context, AuthorizationPolicy policy, PolicyAuthorizationResult authorizeResult ) {
        if ( authorizeResult.Succeeded == false ) {
            var factory = context.RequestServices.GetRequiredService<IUnauthorizedResultFactory>();
            context.Response.StatusCode = factory.HttpStatusCode;
            await context.Response.WriteAsJsonAsync( factory.CreateResult( context ) );
            return;
        }
        await defaultHandler.HandleAsync( next, context, policy, authorizeResult );
    }
}