using Microsoft.AspNetCore.Mvc;
using Util.Helpers;

namespace Util.Samples.Webs.Controllers {
    public class HomeController : Controller {

        public HomeController() {
        }

        public IActionResult Index( string id ) {
            return View();
        }

        public IActionResult A() {
            return View();
        }

        public IActionResult B() {
            var a = Request;
            return Content( "success" );
        }

        public IActionResult Error() {
            return Content( "" );
        }
    }
}
