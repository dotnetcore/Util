using Microsoft.AspNetCore.Mvc;

namespace Util.Samples.Webs.Areas.Logs.Controllers {
    /// <summary>
    /// NLog日志控制器
    /// </summary>
    public class NLog1Controller : LogControllerBase {
        /// <summary>
        /// 首页
        /// </summary>
        public IActionResult Index() {
            return View();
        }
    }
}
