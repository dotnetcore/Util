using Util.Exceptions;
using Util.Microservices.Dapr.WebApiSample.Dtos;

namespace Util.Microservices.Dapr.WebApiSample.Controllers {
    /// <summary>
    /// 测试2控制器 - 用于测试使用服务调用获取未包装的原始对象
    /// </summary>
    [ApiController]
    [Route("Test2")]
    public class Test2Controller : ControllerBase {
        /// <summary>
        /// 测试Get方法访问 - 无参数 - 无返回值 - 成功
        /// </summary>
        [HttpGet]
        public void Get() {
        }

        /// <summary>
        /// 测试Get方法访问 - 无参数 - 无返回值 - 失败
        /// </summary>
        [HttpGet( "fail" )]
        public IActionResult Get_Fail() {
            return new BadRequestResult();
        }

        /// <summary>
        /// 测试Post方法访问 - 有参数 - 无返回值
        /// </summary>
        [HttpPost]
        public void Post( CustomerDto dto ) {
            if ( dto.Code != "2" )
                throw new Warning( "id必须为2" );
        }

        /// <summary>
        /// 测试Get方法访问 - 无参数 - 有返回值
        /// </summary>
        [HttpGet( "customer" )]
        public CustomerDto Get_Customer() {
            var dto = new CustomerDto {
                Name = "ok"
            };
            return dto;
        }

        /// <summary>
        /// 测试Get方法访问 - 有参数 - 有返回值
        /// </summary>
        [HttpGet( "query" )]
        public CustomerDto Query( [FromQuery] CustomerQuery query ) {
            var dto = new CustomerDto {
                Name = query.Name
            };
            return dto;
        }
    }
}