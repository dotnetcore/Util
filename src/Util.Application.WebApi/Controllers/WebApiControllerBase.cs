using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Util.Applications.Filters;
using Util.Helpers;
using Util.Logging;
using Util.Properties;
using Util.Sessions;

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
        /// 会话
        /// </summary>
        protected virtual ISession Session => UserSession.Instance;

        /// <summary>
        /// 获取日志操作
        /// </summary>
        protected virtual ILog GetLog() {
            try {
                var logFactory = Ioc.Create<ILogFactory>();
                return logFactory.CreateLog( GetType() );
            }
            catch {
                return NullLog.Instance;
            }
        }

        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <param name="statusCode">Http状态码</param>
        protected virtual IActionResult Success( dynamic data = null, string message = null, int? statusCode = 200 ) {
            message ??= R.Success;
            return GetResult( StateCode.Ok, message, data, statusCode );
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private IActionResult GetResult( string code, string message, dynamic data, int? httpStatusCode ) {
            var resultFactory = HttpContext.RequestServices.GetService<IResultFactory>();
            if ( resultFactory == null )
                return new Result( code, message, data, httpStatusCode );
            return resultFactory.CreateResult( code, message, data, httpStatusCode );
        }

        /// <summary>
        /// 返回失败消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="statusCode">Http状态码</param>
        protected virtual IActionResult Fail( string message, int? statusCode = 200 ) {
            return GetResult( StateCode.Fail, message, null, statusCode );
        }

        /// <summary>
        /// 获取文件流结果,内容类型设置为 application/octet-stream
        /// </summary>
        /// <param name="stream">文件流</param>
        protected IActionResult GetStreamResult( Stream stream ) {
            return new FileStreamResult( stream, "application/octet-stream" );
        }

        /// <summary>
        /// 获取文件流结果,内容类型设置为 application/octet-stream
        /// </summary>
        /// <param name="stream">文件流</param>
        protected IActionResult GetStreamResult( byte[] stream ) {
            return GetStreamResult( new MemoryStream( stream ) );
        }
    }
}
