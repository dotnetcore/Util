using Microsoft.AspNetCore.Mvc;
using Util.Helpers;
using Util.Webs.Filters;

namespace Util.Samples.Webs.Controllers {

    public class HomeController : Controller {

        public HomeController() {
            
        }

        public IActionResult Index( string id ) {



            









            return View();
        }

        public IActionResult Demo() {
            return View();
        }

        public IActionResult Error() {
            return Content( "" );
        }

        public IActionResult Main( ) {
            return View();
        }


        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public IActionResult Login() {
            return PartialView( "Login" );
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Admin() {
            return PartialView( "Admin" );
        }


        /// <summary>
        /// 品牌
        /// </summary>
        /// <returns></returns>
        public IActionResult Brand() {
            return PartialView( "Admin/Brand" );
        }

        /// <summary>
        /// 导航栏 
        /// </summary>
        /// <returns></returns>
        public IActionResult Sidenav() {
            return PartialView( "Admin/sidenav" );
        }

        /// <summary>
        /// 导航列表
        /// </summary>
        /// <returns></returns>
        public IActionResult Item() {
            return PartialView( "Admin/sidenav/Item" );
        }


        /// <summary>
        /// 页面头部
        /// </summary>
        /// <returns></returns>
        public IActionResult Header() {
            return PartialView( "Admin/Header" );
        }

        /// <summary>
        /// 消息通知
        /// </summary>
        /// <returns></returns>
        public IActionResult Notification() {
            return PartialView( "Admin/Header/Notification" );
        }

        /// <summary>
        /// 用户设置
        /// </summary>
        /// <returns></returns>
        public IActionResult User() {
            return PartialView( "Admin/Header/User" );
        }

        /// <summary>
        /// 页面底部
        /// </summary>
        /// <returns></returns>
        public IActionResult Footer() {
            return PartialView( "Admin/Footer" );
        }
    }

    public class Test {
        public string A { get; set; }
        public string B { get; set; }
    }
}
