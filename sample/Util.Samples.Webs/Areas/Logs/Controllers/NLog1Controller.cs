using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Util.Logs;
using Util.Logs.Extensions;

namespace Util.Samples.Webs.Areas.Logs.Controllers {
    /// <summary>
    /// NLog日志控制器
    /// </summary>
    public class NLog1Controller : LogControllerBase {
        /// <summary>
        /// 初始化NLog日志控制器
        /// </summary>
        /// <param name="log">日志操作</param>
        public NLog1Controller( ILog log ) {
            Log = log;
        }

        /// <summary>
        /// 日志操作
        /// </summary>
        public ILog Log { get; set; }

        /// <summary>
        /// 首页
        /// </summary>
        public IActionResult Index() {
            return View();
        }

        /// <summary>
        /// 写异步日志
        /// </summary>
        public async Task<IActionResult> LogAsync() {
            await WriteLog();
            await WriteLog();
            await WriteLog();
            await WriteLog();
            return Content( "写入成功，请查看c:/log/application/debug目录" );
        }

        /// <summary>
        /// 写日志
        /// </summary>
        private Task WriteLog() {
            return Task.Run( () => Log.Debug( "测试异步写入日志" ) );
        }

        /// <summary>
        /// 写入业务日志
        /// </summary>
        public IActionResult Info() {
            Log.BusinessId( Guid.NewGuid().ToString() )
                .Module( "订单" )
                .Method( "PlaceOrder" )
                .Caption( "有人下单了" )
                .Params( "int","a","1" )
                .Params( "string", "b", "c" )
                .Content( "购买商品数量: {0}", 100 )
                .Content( "购买商品总额：{0}", 200 )
                .Sql( "select * from system.users" )
                .Sql( "select * from system.roles" )
                .SqlParams( "@a={0},@b={1}", 1, 2 )
                .SqlParams( "@userId={0}", Guid.NewGuid().ToString() )
                .Info();
            return Content( "写入成功，请查看c:/log/application/info目录" );
        }

        /// <summary>
        /// 写入错误日志
        /// </summary>
        public IActionResult Error() {
            try {
                Throw();
            }
            catch ( Exception ex ) {
                Log.BusinessId( Guid.NewGuid().ToString() )
                    .Exception( ex, "100" )
                    .Error();
            }
            return Content( "写入成功，请查看c:/log/application/error目录" );
        }

        /// <summary>
        /// 抛出异常
        /// </summary>
        private void Throw() {
            throw new NotImplementedException( "我还没有实现" );
        }
    }
}
