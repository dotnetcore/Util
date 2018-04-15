using Microsoft.AspNetCore.Mvc;
using Util.Ui.Controllers;

namespace Util.Samples.Webs.Areas.Systems.Controllers {
    /// <summary>
    /// 角色控制器
    /// </summary>
    [Area( "Systems" )]
    public class RoleController : ViewControllerBase {        
        /// <summary>
        /// 首页
        /// </summary>
        public virtual IActionResult Index() {
            return View();
        }
        
        /// <summary>
        /// 创建页
        /// </summary>
        public virtual IActionResult Create() {
            return View();
        }
    }
}