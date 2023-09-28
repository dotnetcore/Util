namespace Util.Security.Authorization; 

/// <summary>
/// 授权处理器
/// </summary>
public class AclHandler : AuthorizationHandler<AclRequirement> {
    /// <summary>
    /// 处理授权要求
    /// </summary>
    /// <param name="context">授权处理器上下文</param>
    /// <param name="requirement">授权要求</param>
    protected override async Task HandleRequirementAsync( AuthorizationHandlerContext context, AclRequirement requirement ) {
        if ( context == null )
            return;
        if ( requirement == null )
            return;
        var httpContext = GetHttpContext( context.Resource );
        if ( httpContext == null )
            return;
        var options = GetAclOptions( httpContext );
        if ( options.AllowAnonymous ) {
            context.Succeed( requirement );
            return;
        }
        if ( httpContext.GetIdentity().IsAuthenticated == false )
            return;
        if ( options.IgnoreAcl ) {
            context.Succeed( requirement );
            return;
        }
        if ( requirement.Ignore ) {
            context.Succeed( requirement );
            return;
        }
        var permissionManager = httpContext.RequestServices.GetService<IPermissionManager>();
        if ( permissionManager == null ) {
            context.Fail( new AuthorizationFailureReason( this, "未实现IPermissionManager" ) );
            return;
        }
        var uri = GetResourceUri( requirement, httpContext, options );
        var result = await permissionManager.HasPermissionAsync( uri );
        if ( result ) {
            context.Succeed( requirement );
            return;
        }
        context.Fail( new AuthorizationFailureReason( this, $"没有访问资源 {uri} 的权限" ) );
    }

    /// <summary>
    /// 获取Http上下文
    /// </summary>
    /// <param name="resource">资源</param>
    protected virtual HttpContext GetHttpContext( dynamic resource ) {
        if ( resource is DefaultHttpContext httpContext )
            return httpContext;
        return resource.HttpContext;
    }

    /// <summary>
    /// 获取访问控制配置
    /// </summary>
    protected virtual AclOptions GetAclOptions( HttpContext httpContext ) {
        var result = httpContext.RequestServices.GetService<IOptions<AclOptions>>();
        return result == null ? new AclOptions() : result.Value;
    }

    /// <summary>
    /// 获取资源标识
    /// </summary>
    protected virtual string GetResourceUri( AclRequirement requirement,HttpContext httpContext, AclOptions options ) {
        if ( requirement.Uri.IsEmpty() == false )
            return requirement.Uri;
        if ( options.ResourceUri.IsEmpty() == false )
            return options.ResourceUri;
        return GetResourceUri( httpContext.Request.Path, httpContext.Request.Method );
    }

    /// <summary>
    /// 获取资源标识
    /// </summary>
    protected virtual string GetResourceUri( string path, string httpMethod ) {
        if ( path.IsEmpty() )
            return null;
        var result = $"{path}#{httpMethod}";
        return result.ToLower( CultureInfo.InvariantCulture );
    }
}