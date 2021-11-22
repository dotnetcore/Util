using Microsoft.AspNetCore.Mvc;
using Util.AspNetCore.Tests.Samples;

namespace Util.AspNetCore.Tests.Controllers {
    /// <summary>
    /// 测试Api控制器4
    /// </summary>
    [ApiController]
    [Route( "api/[controller]" )]
    public class Test4Controller : ControllerBase {
        /// <summary>
        /// Delete操作
        /// </summary>
        [HttpDelete( "delete/{id}" )]
        public string Delete( string id ) {
            return $"ok:{id}";
        }

        /// <summary>
        /// Delete操作
        /// </summary>
        [HttpDelete( "{id}" )]
        public CustomerDto Delete2( string id ) {
            return new CustomerDto { Code = id }; 
        }
    }
}
