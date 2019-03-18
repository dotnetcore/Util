using Microsoft.AspNetCore.Mvc;
using Util.Webs.Controllers;

namespace Util.Samples.Apis.Demo {
    /// <summary>
    /// 表单控制器
    /// </summary>
    [ApiController]
    public class FormController : WebApiControllerBase {
        /// <summary>
        /// 新增
        /// </summary>
        [HttpPost]
        public IActionResult Create( dynamic data ) {
            return Success( data );
        }
    }
}