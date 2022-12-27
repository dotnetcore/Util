using System.Threading.Tasks;
using Util.Tests.Dtos;
using Util.Tests.Fakes;
using Util.Tests.Models;
using Util.Tests.Services;
using Xunit;

namespace Util.Applications.Tests {
    /// <summary>
    /// 产品服务测试
    /// </summary>
    public class ProductServiceTest {

        #region 测试初始化

        /// <summary>
        /// 产品服务
        /// </summary>
        private readonly IProductService _service;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ProductServiceTest( IProductService service ) {
            _service = service;
        }

        #endregion

        #region CreateAsync

        /// <summary>
        /// 测试创建
        /// </summary>
        [Fact]
        public async Task TestCreateAsync() {
            //创建
            var dto = ProductFakeService.GetProductDto();
            var id = await _service.CreateAsync( dto );

            //验证
            var result = await _service.GetByIdAsync( id );
            Assert.NotNull( result );
            Assert.Equal( id, result.Id );
            Assert.Equal( dto.Code, result.Code );
            Assert.Equal( dto.Name, result.Name );
        }

        #endregion

        #region UpdateAsync

        /// <summary>
        /// 测试修改
        /// </summary>
        [Fact]
        public async Task TestUpdateAsync() {
            //常量
            var code = "TestUpdateAsync";

            //创建
            var dto = ProductFakeService.GetProductDto();
            var id = await _service.CreateAsync( dto );

            //修改
            var updateDto = await _service.GetByIdAsync( id );
            updateDto.Code = code;
            await _service.UpdateAsync( updateDto );

            //验证
            var result = await _service.GetByIdAsync( id );
            Assert.Equal( code, result.Code );
        }

        #endregion

        #region DeleteAsync

        /// <summary>
        /// 测试删除
        /// </summary>
        [Fact]
        public async Task TestDeleteAsync() {
            //创建
            var dto = ProductFakeService.GetProductDto();
            var id = await _service.CreateAsync( dto );

            //删除
            await _service.DeleteAsync( id );

            //验证
            var result = await _service.GetByIdAsync( id );
            Assert.Null( result );
        }

        #endregion

        #region ExtraProperties

        /// <summary>
        /// 测试扩展属性 - 添加简单扩展属性
        /// </summary>
        [Fact]
        public async Task TestExtraProperties_1() {
            //常量
            var value = "TestExtraProperties_1";

            //创建
            var dto = new ProductDto { TestProperty1 = value };
            var id = await _service.CreateAsync( dto );

            //验证
            var result = await _service.GetByIdAsync( id );
            Assert.Equal( value, result.TestProperty1 );
        }

        /// <summary>
        /// 测试扩展属性 - 修改简单扩展属性
        /// </summary>
        [Fact]
        public async Task TestExtraProperties_2() {
            //常量
            var oldValue = "TestExtraProperties_2_1";
            var newValue = "TestExtraProperties_2_2";

            //添加实体
            var dto = new ProductDto { TestProperty1 = oldValue };
            var id = await _service.CreateAsync( dto );

            //验证
            var oldDto = await _service.GetByIdAsync( id );
            Assert.Equal( oldValue, oldDto.TestProperty1 );

            //修改实体
            oldDto.TestProperty1 = newValue;
            await _service.UpdateAsync( oldDto );

            //验证
            var result = await _service.GetByIdAsync( id );
            Assert.Equal( newValue, result.TestProperty1 );
        }

        /// <summary>
        /// 测试扩展属性 - 添加复杂扩展属性
        /// </summary>
        [Fact]
        public async Task TestExtraProperties_3() {
            //常量
            var code = 2;
            var name = "TestExtraProperties_3";

            //添加实体
            var dto = new ProductDto { TestProperty2 = { Code = code, Name = name } };
            var id = await _service.CreateAsync( dto );

            //验证
            var result = await _service.GetByIdAsync( id );
            Assert.Equal( code, result.TestProperty2.Code );
            Assert.Equal( name, result.TestProperty2.Name );
        }

        /// <summary>
        /// 测试扩展属性 - 修改复杂扩展属性
        /// </summary>
        [Fact]
        public async Task TestExtraProperties_4() {
            //常量
            var code = 2;
            var oldName = "TestExtraProperties_4_1";
            var newName = "TestExtraProperties_4_2";

            //添加实体
            var dto = new ProductDto { TestProperty2 = { Code = code, Name = oldName } };
            var id = await _service.CreateAsync( dto );

            //验证
            var oldDto = await _service.GetByIdAsync( id );
            Assert.Equal( code, oldDto.TestProperty2.Code );
            Assert.Equal( oldName, oldDto.TestProperty2.Name );

            //修改实体
            oldDto.TestProperty2.Name = newName;
            await _service.UpdateAsync( oldDto );

            //验证
            var result = await _service.GetByIdAsync( id );
            Assert.Equal( newName, result.TestProperty2.Name );
        }

        /// <summary>
        /// 测试扩展属性 - 添加对象集合扩展属性
        /// </summary>
        [Fact]
        public async Task TestExtraProperties_5() {
            //常量
            var code = 1;
            var name1 = "TestExtraProperties_5_1";
            var name2 = "TestExtraProperties_5_2";

            //添加实体
            var dto = new ProductDto();
            dto.TestProperties.Add( new ProductItem2 { Code = code, Name = name1 } );
            dto.TestProperties.Add( new ProductItem2 { Code = code, Name = name2 } );
            var id = await _service.CreateAsync( dto );

            //验证
            var result = await _service.GetByIdAsync( id );
            Assert.Equal( 2, result.TestProperties.Count );
            Assert.Equal( code, result.TestProperties[0].Code );
            Assert.Equal( name1, result.TestProperties[0].Name );
            Assert.Equal( code, result.TestProperties[1].Code );
            Assert.Equal( name2, result.TestProperties[1].Name );
        }

        #endregion
    }
}