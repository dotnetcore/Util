using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Data;
using Util.Helpers;
using Util.Http;
using Util.Tests.Dtos;
using Util.Tests.Fakes;
using Util.Tests.Infrastructure;
using Util.Tests.Queries;
using Util.Tests.Services;
using Xunit;
using Xunit.Abstractions;
using Xunit.DependencyInjection;

namespace Util.Applications.Tests {
    /// <summary>
    /// 客户控制器测试
    /// </summary>
    public class CustomerControllerTest : ControllerTestBase {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _testOutputHelper;
        /// <summary>
        /// 客户服务
        /// </summary>
        private readonly ICustomerService _service;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public CustomerControllerTest( ITestOutputHelperAccessor testOutputHelperAccessor, ICustomerService service,IHttpClient client ) : base(client){
            _testOutputHelper = testOutputHelperAccessor.Output;
            _service = service;
        }

        /// <summary>
        /// 测试获取单个实体
        /// </summary>
        [Fact]
        public async Task TestGetAsync() {
            //创建实体
            var dto = CustomerFakeService.GetCustomerDto();
            var id = await _service.CreateAsync( dto );

            //获取单个实体
            var url = $"/api/customer/{id}";
            var result = await GetAsync<CustomerDto>( url, dto );

            //验证
            Assert.Equal( StateCode.Ok, result.Code );
            Assert.Equal( dto.Email, result.Data.Email );
            _testOutputHelper.WriteLine( Json.ToJson( result ) );
        }

        /// <summary>
        /// 测试查询
        /// </summary>
        [Fact]
        public async Task TestQueryAsync() {
            //常量
            var name = "TestQueryAsync";
            var url = "/api/customer/query";

            //创建3个实体,前两个设置了名称
            var dtos = CustomerFakeService.GetCustomerDtos(3);
            dtos[0].Name = name;
            dtos[1].Name = name;
            await _service.CreateAsync( dtos[0] );
            await _service.CreateAsync( dtos[1] );
            await _service.CreateAsync( dtos[2] );

            //使用名称查询
            var query = new CustomerQuery { Name = name };
            var result = await GetAsync<List<CustomerDto>>( url, query );

            //验证
            Assert.Equal( StateCode.Ok, result.Code );
            Assert.Equal( 2, result.Data.Count );
            _testOutputHelper.WriteLine( Json.ToJson( result ) );
        }

        /// <summary>
        /// 测试分页查询
        /// </summary>
        [Fact]
        public async Task TestPageQueryAsync() {
            //常量
            var name = "TestPageQueryAsync";
            var url = "/api/customer";

            //创建5个实体,前4个设置了名称,并使用Id属性排序
            var dtos = CustomerFakeService.GetCustomerDtos( 5 ).OrderBy( t => t.Id ).ToList();
            for ( int i = 0; i < 4; i++ ) {
                dtos[i].Name = name;
            }
            foreach ( var dto in dtos ) {
                await _service.CreateAsync( dto );
            }

            //使用名称查询第二页,每页2行,并使用Id属性排序
            var query = new CustomerQuery { Page = 2, PageSize = 2, Name = name,Order = "Id" };
            var result = await GetAsync<PageList<CustomerDto>>( url, query );

            //验证
            Assert.Equal( StateCode.Ok, result.Code );
            Assert.Equal( 2, result.Data.PageCount );
            Assert.Equal( 4, result.Data.Total );
            Assert.Equal( dtos[2].Email, result.Data.Data[0].Email );
            Assert.Equal( dtos[3].Email, result.Data.Data[1].Email );
            _testOutputHelper.WriteLine( Json.ToJson( result ) );
        }
    }
}
