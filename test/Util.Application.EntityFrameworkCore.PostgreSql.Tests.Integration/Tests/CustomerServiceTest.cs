using System.Threading.Tasks;
using Util.Tests.Fakes;
using Util.Tests.Services;
using Xunit;

namespace Util.Applications.Tests {
    /// <summary>
    /// 客户服务测试
    /// </summary>
    public class CustomerServiceTest {
        /// <summary>
        /// 客户服务
        /// </summary>
        private readonly ICustomerService _service;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public CustomerServiceTest( ICustomerService service ) {
            _service = service;
        }

        /// <summary>
        /// 测试创建
        /// </summary>
        [Fact]
        public async Task TestCreateAsync() {
            //创建
            var dto = CustomerFakeService.GetCustomerDto();
            var id = await _service.CreateAsync( dto );

            //验证
            var result = await _service.GetByIdAsync( id );
            Assert.NotNull( result );
            Assert.Equal( id, result.Id );
            Assert.Equal( dto.Code, result.Code );
            Assert.Equal( dto.Name, result.Name );
        }
    }
}