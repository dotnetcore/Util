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

        [HttpPost]
        public IActionResult B([FromBody] Test a) {
            return Json( new {A = Request.Headers["a"], B = Request.Headers["b"],C= a.A } );
        }

        public IActionResult Error() {
            return Content( "" );
        }

        public IActionResult Main( ) {
            return View();
        }
    }

    public class Test {
        public string A { get; set; }
        public string B { get; set; }
    }
}
