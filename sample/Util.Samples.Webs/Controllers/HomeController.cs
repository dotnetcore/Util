using Microsoft.AspNetCore.Mvc;
using Util.Datas.Queries;
using Util.Dependency;
using Util.Reflections;

namespace Util.Samples.Webs.Controllers {
    public class HomeController : Controller
    {
        public HomeController() {
        }


        public IActionResult Index() {
            var log = Util.Logs.Log.GetLog( this );
            log.Warn("哈哈");
            return View();
        }
    }
}
