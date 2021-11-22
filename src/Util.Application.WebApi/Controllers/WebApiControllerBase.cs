using System.Net;
using Microsoft.AspNetCore.Mvc;
using Util.Applications.Filters;
using Util.Properties;

namespace Util.Applications.Controllers {
    /// <summary>
    /// WebApi控制器基类
    /// </summary>
    [ApiController]
    [Route( "api/[controller]" )]
    [ExceptionHandler]
    [ErroLogFilter]
    public abstract class WebApiControllerBase : ControllerBase {
        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <param name="statusCode">Http状态码</param>
        protected virtual IActionResult Success( dynamic data = null, string message = null, HttpStatusCode? statusCode = HttpStatusCode.OK ) {
            message ??= R.Success;
            return new Result( StateCode.Ok, message, data, statusCode );
        }

        /// <summary>
        /// 返回失败消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="statusCode">Http状态码</param>
        protected virtual IActionResult Fail( string message, HttpStatusCode? statusCode = null ) {
            return new Result( StateCode.Fail, message, null, statusCode );
        }
    }
}
