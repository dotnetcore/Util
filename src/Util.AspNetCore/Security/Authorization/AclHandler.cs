using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Util.Security.Authorization {
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
            var httpContext = context.Resource as DefaultHttpContext;
            if ( httpContext == null )
                return;
            if ( httpContext.GetIdentity().IsAuthenticated == false )
                return;
            if ( requirement.Ignore ) {
                context.Succeed( requirement );
                return;
            }
            var permissionManager = httpContext.RequestServices.GetService<IPermissionManager>();
            if ( permissionManager == null ) {
                context.Fail( new AuthorizationFailureReason( this, "未实现IPermissionManager" ) );
                return;
            }
            var uri = GetResourceUri( requirement, httpContext );
            var result = await permissionManager.HasPermissionAsync( uri );
            if ( result ) {
                context.Succeed( requirement );
                return;
            }
            context.Fail( new AuthorizationFailureReason( this, $"没有访问资源 {uri} 的权限" ) );
        }

        /// <summary>
        /// 获取资源标识
        /// </summary>
        private string GetResourceUri( AclRequirement requirement,HttpContext httpContext ) {
            if ( requirement.Uri.IsEmpty() == false )
                return requirement.Uri;
            return httpContext.Request.Path;
        }
    }
}
