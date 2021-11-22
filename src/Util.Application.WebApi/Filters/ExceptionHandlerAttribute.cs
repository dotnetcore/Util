using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Util.Helpers;

namespace Util.Applications.Filters {
    /// <summary>
    /// 异常处理过滤器
    /// </summary>
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute {
        /// <summary>
        /// 异常处理
        /// </summary>
        public override void OnException( ExceptionContext context ) {
            context.ExceptionHandled = true;
            context.HttpContext.Response.StatusCode = 200;
            context.Result = new Result( StateCode.Fail, context.Exception.GetPrompt( Web.Environment.IsProduction() ) );
        }
    }
}
