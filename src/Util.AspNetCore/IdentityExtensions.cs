using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Util.Security.Authentication;

namespace Util {
    /// <summary>
    /// 身份标识扩展
    /// </summary>
    public static class IdentityExtensions {
        /// <summary>
        /// 获取用户标识声明值
        /// </summary>
        /// <param name="identity">用户标识</param>
        /// <param name="type">声明类型</param>
        public static string GetValue( this ClaimsIdentity identity, string type ) {
            var claim = identity.FindFirst( type );
            if( claim == null )
                return string.Empty;
            return claim.Value;
        }

        /// <summary>
        /// 获取身份标识
        /// </summary>
        /// <param name="context">Http上下文</param>
        public static ClaimsIdentity GetIdentity( this HttpContext context ) {
            if( context?.User is not { } principal )
                return UnauthenticatedIdentity.Instance;
            if( principal.Identity is ClaimsIdentity identity )
                return identity;
            return UnauthenticatedIdentity.Instance;
        }
    }
}
