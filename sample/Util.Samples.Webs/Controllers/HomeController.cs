using Microsoft.AspNetCore.Mvc;
using Util.Samples.Webs.Models;

namespace Util.Samples.Webs.Controllers {
    public class HomeController : Controller {

        public HomeController(  ) {
        }

        public IActionResult Index() {
            TestTagHelper a = new TestTagHelper();
            var b = a.ToString();
            return View();
        }

        public IActionResult Error() {
            return View();
        }

        public IActionResult A() {
            return View();
        }
    }
}
