using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Util.AspNetCore.Tests.Samples;

namespace Util.AspNetCore.Tests.Controllers {
    /// <summary>
    /// 测试Api控制器1
    /// </summary>
    [ApiController]
    [Route( "api/[controller]" )]
    public class Test1Controller : ControllerBase {
        /// <summary>
        /// 获取请求头操作
        /// </summary>
        [HttpGet("header")]
        public string GetHeader() {
            var header = Request.Headers["Authorization"].FirstOrDefault();
            return $"ok:{header}";
        }

        /// <summary>
        /// 默认Get操作
        /// </summary>
        [HttpGet]
        public string Get() {
            return "ok";
        }

        /// <summary>
        /// 通过id获取
        /// </summary>
        [HttpGet( "{id}" )]
        public string Get( string id ) {
            return $"ok:{id}";
        }

        /// <summary>
        /// 查询操作,通过query参数绑定
        /// </summary>
        [HttpGet( "Query" )]
        public string Query( [FromQuery] CustomerQuery query ) {
            return $"code:{query.Code},name:{query.Name}";
        }

        /// <summary>
        /// 查询操作,返回对象
        /// </summary>
        [HttpGet( "List" )]
        public ActionResult<List<CustomerDto>> List( [FromQuery] CustomerQuery query ) {
            var result = new List<CustomerDto> {
                new() {Code = query.Code},
                new() {Name = query.Name}
            };
            return result;
        }
    }
}
