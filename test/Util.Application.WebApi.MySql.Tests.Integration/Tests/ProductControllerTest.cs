using System.Threading.Tasks;
using Util.Helpers;
using Util.Http;
using Util.Tests.Dtos;
using Util.Tests.Fakes;
using Util.Tests.Infrastructure;
using Util.Tests.Services;
using Xunit;
using Xunit.Abstractions;
using Xunit.DependencyInjection;

namespace Util.Applications.Tests {
    /// <summary>
    /// 产品控制器测试
    /// </summary>
    public class ProductControllerTest : ControllerTestBase {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _testOutputHelper;
        /// <summary>
        /// 产品服务
        /// </summary>
        private readonly IProductService _service;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ProductControllerTest( ITestOutputHelperAccessor testOutputHelperAccessor, IProductService service, IHttpClient client ) : base( client ) {
            _testOutputHelper = testOutputHelperAccessor.Output;
            _service = service;
        }

        /// <summary>
        /// 测试创建
        /// </summary>
        [Fact]
        public async Task TestCreateAsync() {
            //服务地址
            var url = "/api/product";

            //创建实体
            var dto = ProductFakeService.GetProductDto();
            var result = await PostAsync<ProductDto>( url, dto );

            //验证
            Assert.Equal( StateCode.Ok, result.Code );
            Assert.NotEmpty( result.Data.Id );
            _testOutputHelper.WriteLine( Json.ToJson( result ) );
        }

        /// <summary>
        /// 测试修改
        /// </summary>
        [Fact]
        public async Task TestUpdateAsync() {
            //常量
            var name = "TestUpdateAsync";

            //创建实体
            var dto = ProductFakeService.GetProductDto();
            var id = await _service.CreateAsync( dto );

            //服务地址
            var url = $"/api/product/{id}";

            //修改实体
            dto = await _service.GetByIdAsync( id );
            dto.Name = name;
            var result = await PutAsync<ProductDto>( url, dto );

            //重新获取实体
            dto = await _service.GetByIdAsync( id );

            //验证
            Assert.Equal( StateCode.Ok, result.Code );
            Assert.Equal( name, dto.Name );
            _testOutputHelper.WriteLine( Json.ToJson( result ) );
        }

        /// <summary>
        /// 测试删除
        /// </summary>
        [Fact]
        public async Task TestDeleteAsync() {
            //创建实体
            var dto = ProductFakeService.GetProductDto();
            var id = await _service.CreateAsync( dto );

            //服务地址
            var url = $"/api/product/{id}";

            //删除实体
            var result = await DeleteAsync<ProductDto>( url );

            //重新获取实体
            dto = await _service.GetByIdAsync( id );

            //验证
            Assert.Equal( StateCode.Ok, result.Code );
            Assert.Null( dto );
            _testOutputHelper.WriteLine( Json.ToJson( result ) );
        }

        /// <summary>
        /// 测试批量删除
        /// </summary>
        [Fact]
        public async Task TestBatchDeleteAsync() {
            //创建实体
            var dtos = ProductFakeService.GetProductDtos(2);
            var id = await _service.CreateAsync( dtos[0] );
            var id2 = await _service.CreateAsync( dtos[1] );

            //服务地址
            var url = "/api/product/delete";

            //删除实体列表
            var result = await PostAsync<ProductDto>( url,$"{id},{id2}" );

            //重新获取实体
            var dto = await _service.GetByIdAsync( id );
            var dto2 = await _service.GetByIdAsync( id2 );

            //验证
            Assert.Equal( StateCode.Ok, result.Code );
            Assert.Null( dto );
            Assert.Null( dto2 );
            _testOutputHelper.WriteLine( Json.ToJson( result ) );
        }
    }
}