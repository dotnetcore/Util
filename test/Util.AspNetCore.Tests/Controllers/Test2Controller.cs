using Microsoft.AspNetCore.Mvc;
using Util.AspNetCore.Tests.Samples;

namespace Util.AspNetCore.Tests.Controllers {
    /// <summary>
    /// 测试Api控制器2
    /// </summary>
    [ApiController]
    [Route( "api/[controller]" )]
    public class Test2Controller : ControllerBase {
        /// <summary>
        /// Post操作
        /// </summary>
        [HttpPost("create")]
        public string Create( CustomerDto dto ) {
            return $"ok:{dto.Code}";
        }

        /// <summary>
        /// Post操作
        /// </summary>
        [HttpPost]
        public IActionResult Create2( CustomerDto dto ) {
            return new JsonResult( dto );
        }
    }
}
