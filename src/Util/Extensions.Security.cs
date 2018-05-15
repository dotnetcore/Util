using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Util.Security.Principals;

namespace Util {
    /// <summary>
    /// 系统扩展 - 安全
    /// </summary>
    public static partial class Extensions {
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
            if( context == null )
                return UnauthenticatedIdentity.Instance;
            if( !(context.User is ClaimsPrincipal principal) )
                return UnauthenticatedIdentity.Instance;
            if( principal.Identity is ClaimsIdentity identity )
                return identity;
            return UnauthenticatedIdentity.Instance;
        }
    }
}
