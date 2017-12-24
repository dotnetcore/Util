using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Util.Webs.Commons;
using Util.Webs.Filters;

namespace Util.Webs.Controllers {
    /// <summary>
    /// WebApi控制器
    /// </summary>
    [Route( "api/[controller]" )]
    [ExceptionHandler]
    public class WebApiControllerBase : Controller {
        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="data">数据</param>
        protected virtual IActionResult Success( string message, object data ) {
            return new Result( StateCode.Ok, message, data );
        }

        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="data">数据</param>
        protected virtual IActionResult Success( string message = "操作成功", IEnumerable<object> data = null ) {
            return new Result( StateCode.Ok, message, data );
        }

        /// <summary>
        /// 返回失败消息
        /// </summary>
        /// <param name="message">消息</param>
        protected IActionResult Fail( string message ) {
            return new Result( StateCode.Fail, message );
        }
    }
}
