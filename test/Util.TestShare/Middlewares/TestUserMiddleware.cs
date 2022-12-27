using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Util.Tests.Middlewares {
    /// <summary>
    /// 测试用户中间件
    /// </summary>
    public class TestUserMiddleware {
        /// <summary>
        /// 下个中间件
        /// </summary>
        private readonly RequestDelegate _next;

        /// <summary>
        /// 初始化测试用户中间件
        /// </summary>
        /// <param name="next">下个中间件</param>
        public TestUserMiddleware( RequestDelegate next ) {
            _next = next;
        }

        /// <summary>
        /// 执行中间件
        /// </summary>
        /// <param name="context">Http上下文</param>
        public async Task Invoke( HttpContext context ) {
            var userId = context.Request.Headers["user-id"].SafeString();
            if ( userId.IsEmpty() == false ) {
                var identity = new ClaimsIdentity( new[] { new Claim( "sub", userId ) } );
                context.User = new ClaimsPrincipal( identity );
            }
            await _next( context );
        }
    }
}
