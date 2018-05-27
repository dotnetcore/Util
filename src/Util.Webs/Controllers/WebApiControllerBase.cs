using Microsoft.AspNetCore.Mvc;
using Util.Helpers;
using Util.Properties;
using Util.Sessions;
using Util.Webs.Commons;
using Util.Webs.Filters;

namespace Util.Webs.Controllers {
    /// <summary>
    /// WebApi控制器
    /// </summary>
    [Route( "api/[controller]" )]
    [ExceptionHandler]
    [ErrorLog]
    public class WebApiControllerBase : Controller {
        /// <summary>
        /// 会话
        /// </summary>
        private readonly ISession _session;

        /// <summary>
        /// 初始化
        /// </summary>
        public WebApiControllerBase() {
            _session = Ioc.Create<ISession>();
        }

        /// <summary>
        /// 会话
        /// </summary>
        public virtual ISession Session => _session ?? NullSession.Instance;

        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        protected virtual IActionResult Success( dynamic data = null, string message = null ) {
            if ( message == null )
                message = R.Success;
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