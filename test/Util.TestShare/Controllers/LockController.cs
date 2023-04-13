using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Util.Applications.Controllers;
using Util.Applications.Filters;
using Util.Applications.Locks;

namespace Util.Tests.Controllers {
    /// <summary>
    /// 业务锁控制器
    /// </summary>
    public class LockController : WebApiControllerBase {
        /// <summary>
        /// 未设置防重复过滤器
        /// </summary>
        [HttpGet("nolock")]
        public IActionResult GetAsync() {
            Thread.Sleep( 100 );
            return Success( "ok" );
        }

        /// <summary>
        /// 设置防重复过滤器 - 全局锁
        /// </summary>
        [HttpGet( "GlobalLock" )]
        [Lock(Type = LockType.Global)]
        public IActionResult Get2Async() {
            Thread.Sleep( 100 );
            return Success( "ok" );
        }

        /// <summary>
        /// 设置防重复过滤器 - 用户锁
        /// </summary>
        [HttpGet( "UserLock" )]
        [Lock( Type = LockType.User )]
        public IActionResult Get3Async() {
            Thread.Sleep( 100 );
            return Success( "ok" );
        }
    }
}