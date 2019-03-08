using Microsoft.AspNetCore.Mvc;
using Util.Ui.Controllers;

namespace Util.Samples.Areas.Systems.Controllers {
    /// <summary>
    /// 应用程序控制器
    /// </summary>
    [Area( "Systems" )]
    public class ApplicationController : ViewControllerBase {
        /// <summary>
        /// 首页
        /// </summary>
        public virtual IActionResult Index() {
            return View();
        }

        /// <summary>
        /// 编辑页
        /// </summary>
        public virtual IActionResult Edit() {
            return View();
        }

        /// <summary>
        /// 详细页
        /// </summary>
        public virtual IActionResult Detail() {
            return View();
        }
    }
}