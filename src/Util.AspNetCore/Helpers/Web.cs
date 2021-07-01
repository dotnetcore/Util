using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Util.Security.Authorization;

namespace Util.Helpers {
    /// <summary>
    /// Web操作
    /// </summary>
    public static class Web {

        #region HttpContextAccessor(Http上下文访问器)

        /// <summary>
        /// Http上下文访问器
        /// </summary>
        public static IHttpContextAccessor HttpContextAccessor { get; set; }

        #endregion

        #region HttpContext(Http上下文)

        /// <summary>
        /// 当前Http上下文
        /// </summary>
        public static HttpContext HttpContext => HttpContextAccessor?.HttpContext;

        #endregion

        #region ServiceProvider(服务提供器)

        /// <summary>
        /// 当前Http请求服务提供器
        /// </summary>
        public static IServiceProvider ServiceProvider => HttpContext?.RequestServices;

        #endregion

        #region Request(Http请求)

        /// <summary>
        /// 当前Http请求
        /// </summary>
        public static HttpRequest Request => HttpContext?.Request;

        #endregion

        #region Response(Http响应)

        /// <summary>
        /// 当前Http响应
        /// </summary>
        public static HttpResponse Response => HttpContext?.Response;

        #endregion

        #region User(当前用户安全主体)

        /// <summary>
        /// 当前用户安全主体
        /// </summary>
        public static ClaimsPrincipal User {
            get {
                if( HttpContext?.User is { } principal )
                    return principal;
                return UnauthenticatedPrincipal.Instance;
            }
        }

        #endregion

        #region Identity(当前用户身份标识)

        /// <summary>
        /// 当前用户身份标识
        /// </summary>
        public static ClaimsIdentity Identity {
            get {
                if( User.Identity is ClaimsIdentity identity )
                    return identity;
                return UnauthenticatedIdentity.Instance;
            }
        }

        #endregion
    }
}
