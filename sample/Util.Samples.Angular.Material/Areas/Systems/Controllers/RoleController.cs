using Microsoft.AspNetCore.Mvc;
using Util.Ui.Controllers;

namespace Util.Samples.Areas.Systems.Controllers {
    /// <summary>
    /// 角色控制器
    /// </summary>
    [Area( "Systems" )]
    public class RoleController : ViewControllerBase {
        /// <summary>
        /// 首页
        /// </summary>
        public IActionResult Index() {
            return View();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        public IActionResult Edit() {
            return View();
        }

        /// <summary>
        /// 详细
        /// </summary>
        public IActionResult Detail() {
            return View();
        }

        /// <summary>
        /// 选择角色弹出框
        /// </summary>
        public IActionResult SelectRoleDialog() {
            return View();
        }
    }
}