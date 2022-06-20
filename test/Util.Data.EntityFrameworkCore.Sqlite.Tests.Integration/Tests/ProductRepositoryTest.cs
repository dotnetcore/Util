using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Exceptions;
using Util.Tests.Fakes;
using Util.Tests.Infrastructure;
using Util.Tests.Models;
using Util.Tests.Repositories;
using Util.Tests.UnitOfWorks;
using Xunit;
using Xunit.Abstractions;
using Xunit.DependencyInjection;

namespace Util.Data.EntityFrameworkCore.Tests {
    /// <summary>
    /// 产品仓储测试
    /// 说明:
    /// 1. 测试Guid类型标识
    /// 2. 测试仓储基础方法
    /// 3. 测试扩展属性
    /// </summary>
    public partial class ProductRepositoryTest : TestBase {

        #region 测试初始化

        /// <summary>
        /// 日志消息
        /// </summary>
        private readonly ITestOutputHelper _log;
        /// <summary>
        /// 仓储
        /// </summary>
        private readonly IProductRepository _repository;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ProductRepositoryTest( ITestOutputHelperAccessor accessor, IProductRepository repository, ITestUnitOfWork unitOfWork ) :base(unitOfWork) {
            _log = accessor.Output;
            _repository = repository;
        }

        #endregion

        #region 辅助方法

        /// <summary>
        /// 添加产品
        /// </summary>
        private async Task<Product> AddProductAsync( string name = null ) {
            var entity = ProductFakeService.GetProduct();
            entity.Init();
            if( name != null )
                entity.Name = name;
            await _repository.AddAsync( entity );
            await UnitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        /// 添加实体列表
        /// </summary>
        /// <param name="count">添加数量</param>
        /// <param name="name">产品名称</param>
        private async Task<List<Product>> AddProductsAsync( int count = 2, string name = null ) {
            var products = ProductFakeService.GetProducts( count );
            products.ForEach( product => {
                product.Init();
                if( name != null )
                    product.Name = name;
            } );
            await _repository.AddAsync( products );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();
            return products.OrderBy( t => t.Id ).ToList();
        }

        /// <summary>
        /// 打印更改跟踪调试信息
        /// </summary>
        private void WriteTrackerDebug() {
            _log.WriteLine( UnitOfWork.GetChangeTrackerDebugView() );
        }

        #endregion

        #region FindById

        /// <summary>
        /// 测试通过标识查找实体 - 跟踪实体
        /// </summary>
        [Fact]
        public async Task TestFindById_Tracking_1() {
            //添加实体
            var entity = await AddProductAsync();
            UnitOfWork.ClearCache();

            //验证
            var result = _repository.FindById( entity.Id );
            WriteTrackerDebug();
            Assert.Equal( entity.Code, result.Code );
        }

        /// <summary>
        /// 测试通过标识查找实体 - 跟踪实体 - 字符串标识
        /// </summary>
        [Fact]
        public async Task TestFindById_Tracking_2() {
            //添加实体
            var entity = await AddProductAsync();
            UnitOfWork.ClearCache();

            //验证
            var result = _repository.FindById( entity.Id.ToString() );
            WriteTrackerDebug();
            Assert.Equal( entity.Code, result.Code );
        }

        /// <summary>
        /// 测试通过标识查找实体 - 不跟踪实体
        /// </summary>
        [Fact]
        public async Task TestFindById_NoTracking() {
            //添加实体
            var entity = await AddProductAsync();
            UnitOfWork.ClearCache();

            //验证
            var result = _repository.NoTracking().FindById( entity.Id );
            WriteTrackerDebug();
            Assert.Equal( entity.Code, result.Code );
        }

        #endregion

        #region FindByIdAsync

        /// <summary>
        /// 测试通过标识查找实体 - 跟踪 - 异步
        /// </summary>
        [Fact]
        public async Task TestFindByIdAsync_Tracking_1() {
            //添加实体
            var entity = await AddProductAsync();
            UnitOfWork.ClearCache();

            //验证
            var result = await _repository.FindByIdAsync( entity.Id );
            WriteTrackerDebug();
            Assert.Equal( entity.Code, result.Code );
        }

        /// <summary>
        /// 测试通过标识查找实体 - 跟踪 - 异步 - 字符串标识
        /// </summary>
        [Fact]
        public async Task TestFindByIdAsync_Tracking_2() {
            //添加实体
            var entity = await AddProductAsync();
            UnitOfWork.ClearCache();

            //验证
            var result = await _repository.FindByIdAsync( entity.Id.ToString() );
            WriteTrackerDebug();
            Assert.Equal( entity.Code, result.Code );
        }

        /// <summary>
        /// 测试通过标识查找实体 - 不跟踪 - 异步
        /// </summary>
        [Fact]
        public async Task TestFindByIdAsync_NoTracking() {
            //添加实体
            var entity = await AddProductAsync();
            UnitOfWork.ClearCache();

            //验证
            var result = await _repository.NoTracking().FindByIdAsync( entity.Id );
            WriteTrackerDebug();
            Assert.Equal( entity.Code, result.Code );
        }

        #endregion

        #region FindByIds

        /// <summary>
        /// 测试通过标识列表查找实体列表 - 传入逗号分隔的标识列表
        /// </summary>
        [Fact]
        public async Task TestFindByIds_1() {
            //常量
            var count = 3;

            //添加实体列表
            var products = ProductFakeService.GetProducts( count ).OrderBy( t => t.Code ).ToList();
            products.ForEach( product => {
                product.Init();
            } );
            await _repository.AddAsync( products );
            await UnitOfWork.CommitAsync();

            //验证
            var result = _repository.FindByIds( products[0].Id, products[1].Id, products[2].Id ).OrderBy( t => t.Code ).ToList();
            Assert.Equal( products[0].Description, result[0].Description );
            Assert.Equal( products[1].Description, result[1].Description );
            Assert.Equal( products[2].Description, result[2].Description );
        }

        /// <summary>
        /// 测试通过标识列表查找实体列表 - 传入集合
        /// </summary>
        [Fact]
        public async Task TestFindByIds_2() {
            //常量
            var count = 3;

            //添加实体列表
            var products = ProductFakeService.GetProducts( count ).OrderBy( t => t.Code ).ToList();
            products.ForEach( product => {
                product.Init();
            } );
            await _repository.AddAsync( products );
            await UnitOfWork.CommitAsync();

            //验证
            var result = _repository.FindByIds( products.Select( t => t.Id ) ).OrderBy( t => t.Code ).ToList();
            Assert.Equal( products[0].Description, result[0].Description );
            Assert.Equal( products[1].Description, result[1].Description );
            Assert.Equal( products[2].Description, result[2].Description );
        }

        /// <summary>
        /// 测试通过标识列表查找实体列表 - 传入标识列表字符串
        /// </summary>
        [Fact]
        public async Task TestFindByIds_3() {
            //常量
            var count = 3;

            //添加实体列表
            var products = ProductFakeService.GetProducts( count ).OrderBy( t => t.Code ).ToList();
            products.ForEach( product => {
                product.Init();
            } );
            await _repository.AddAsync( products );
            await UnitOfWork.CommitAsync();

            //验证
            var result = _repository.FindByIds( products.Select( t => t.Id ).Join() ).OrderBy( t => t.Code ).ToList();
            Assert.Equal( products[0].Description, result[0].Description );
            Assert.Equal( products[1].Description, result[1].Description );
            Assert.Equal( products[2].Description, result[2].Description );
        }

        #endregion

        #region FindByIdsAsync

        /// <summary>
        /// 测试通过标识列表查找实体列表 - 传入逗号分隔的标识列表 - 异步
        /// </summary>
        [Fact]
        public async Task TestFindByIdsAsync_1() {
            //常量
            var count = 3;

            //添加实体列表
            var products = ProductFakeService.GetProducts( count ).OrderBy( t => t.Code ).ToList();
            products.ForEach( product => {
                product.Init();
            } );
            await _repository.AddAsync( products );
            await UnitOfWork.CommitAsync();

            //验证
            var result = ( await _repository.FindByIdsAsync( products[0].Id, products[1].Id, products[2].Id ) ).OrderBy( t => t.Code ).ToList();
            Assert.Equal( products[0].Description, result[0].Description );
            Assert.Equal( products[1].Description, result[1].Description );
            Assert.Equal( products[2].Description, result[2].Description );
        }

        /// <summary>
        /// 测试通过标识列表查找实体列表 - 传入集合 - 异步
        /// </summary>
        [Fact]
        public async Task TestFindByIdsAsync_2() {
            //常量
            var count = 3;

            //添加实体列表
            var products = ProductFakeService.GetProducts( count ).OrderBy( t => t.Code ).ToList();
            products.ForEach( product => {
                product.Init();
            } );
            await _repository.AddAsync( products );
            await UnitOfWork.CommitAsync();

            //验证
            var result = ( await _repository.FindByIdsAsync( products.Select( t => t.Id ) ) ).OrderBy( t => t.Code ).ToList();
            Assert.Equal( products[0].Description, result[0].Description );
            Assert.Equal( products[1].Description, result[1].Description );
            Assert.Equal( products[2].Description, result[2].Description );
        }

        /// <summary>
        /// 测试通过标识列表查找实体列表 - 传入标识列表字符串 - 异步
        /// </summary>
        [Fact]
        public async Task TestFindByIdsAsync_3() {
            //常量
            var count = 3;

            //添加实体列表
            var products = ProductFakeService.GetProducts( count ).OrderBy( t => t.Code ).ToList();
            products.ForEach( product => {
                product.Init();
            } );
            await _repository.AddAsync( products );
            await UnitOfWork.CommitAsync();

            //验证
            var result = ( await _repository.FindByIdsAsync( products.Select( t => t.Id ).Join() ) ).OrderBy( t => t.Code ).ToList();
            Assert.Equal( products[0].Description, result[0].Description );
            Assert.Equal( products[1].Description, result[1].Description );
            Assert.Equal( products[2].Description, result[2].Description );
        }

        #endregion

        #region Single

        /// <summary>
        /// 测试查找单个实体
        /// </summary>
        [Fact]
        public async Task TestSingle_1() {
            //常量
            var name = "TestSingle";

            //添加实体
            var entity = await AddProductAsync( name );
            UnitOfWork.ClearCache();

            //验证
            var result = _repository.Single( t => t.Name == name );
            Assert.Equal( entity.Code, result.Code );
        }

        #endregion

        #region SingleAsync

        /// <summary>
        /// 测试查找单个实体 - 异步
        /// </summary>
        [Fact]
        public async Task TestSingleAsync() {
            //常量
            var name = "TestSingleAsync";

            //添加实体
            var entity = await AddProductAsync( name );
            UnitOfWork.ClearCache();

            //验证
            var result = await _repository.SingleAsync( t => t.Name == name );
            Assert.Equal( entity.Code, result.Code );
        }

        #endregion

        #region Exists

        /// <summary>
        /// 测试判断是否存在
        /// </summary>
        [Fact]
        public async Task TestExists() {
            //添加实体
            var entity = await AddProductAsync();
            UnitOfWork.ClearCache();

            //验证
            Assert.True( _repository.Exists( t => t.Id == entity.Id ) );
        }

        #endregion

        #region ExistsAsync

        /// <summary>
        /// 测试判断是否存在 - 异步
        /// </summary>
        [Fact]
        public async Task TestExistsAsync() {
            //添加实体
            var entity = await AddProductAsync();
            UnitOfWork.ClearCache();

            //验证
            Assert.True( await _repository.ExistsAsync( t => t.Id == entity.Id ) );
        }

        #endregion

        #region Count

        /// <summary>
        /// 测试查找数量
        /// </summary>
        [Fact]
        public async Task TestCount() {
            //常量
            var name = "TestCount";
            var count = 3;

            //添加实体列表
            var products = ProductFakeService.GetProducts( count );
            products.ForEach( product => {
                product.Init();
                product.Name = name;
            } );
            await _repository.AddAsync( products );
            await UnitOfWork.CommitAsync();

            //验证
            var result = _repository.Count( t => t.Name == name );
            Assert.Equal( count, result );
        }

        #endregion

        #region CountAsync

        /// <summary>
        /// 测试查找数量 - 异步
        /// </summary>
        [Fact]
        public async Task TestCountAsync() {
            //常量
            var name = "TestCountAsync";
            var count = 3;

            //添加实体列表
            var products = ProductFakeService.GetProducts( count );
            products.ForEach( product => {
                product.Init();
                product.Name = name;
            } );
            await _repository.AddAsync( products );
            await UnitOfWork.CommitAsync();

            //验证
            var result = await _repository.CountAsync( t => t.Name == name );
            Assert.Equal( count, result );
        }

        #endregion

        #region Update

        /// <summary>
        /// 测试更新方法1 - 查找并修改实体,直接提交工作单元
        /// </summary>
        [Fact]
        public async Task TestUpdate_1() {
            //常量
            var code = "TestUpdate_1_Code";

            //添加实体
            var entity = await AddProductAsync();
            UnitOfWork.ClearCache();

            //查找实体并修改
            var product = await _repository.FindByIdAsync( entity.Id );
            product.Code = code;

            //直接提交工作单元
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            var result = await _repository.FindByIdAsync( entity.Id );
            Assert.Equal( code, result.Code );
        }

        /// <summary>
        /// 测试更新并发 - 使用更新方法1
        /// 更新方法1的缺陷: 通过赋值的方式更新查找实体的版本号,无法触发乐观锁
        /// </summary>
        [Fact]
        public async Task TestUpdate_1_Concurrency() {
            //常量
            var code = "TestUpdate_1_Concurrency_Code";
            var description = "TestUpdate_1_Concurrency_Description";

            //添加实体
            var entity = await AddProductAsync();
            UnitOfWork.ClearCache();

            //此处模拟用户1打开表单并修改,但尚未提交,这将保存旧实体
            var product = await _repository.FindByIdAsync( entity.Id );
            product.Code = code;
            UnitOfWork.ClearCache();

            //此处模拟用户2更新该实体,这将导致版本号变化
            var product2 = await _repository.FindByIdAsync( entity.Id );
            product2.Description = description;
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //此处模拟用户1提交表单,查找实体,并进行赋值
            var result = _repository.FindById( entity.Id );
            result.Code = product.Code;
            result.Description = product.Description;
            result.Version = product.Version;
            //提交工作单元,由于版本号变化,预期应触发乐观锁,但实际未触发
            await UnitOfWork.CommitAsync();

            //结果:用户1覆盖了用户2设置的Description属性
            Assert.Equal( code, result.Code );
            Assert.NotEqual( description, result.Description );
        }

        /// <summary>
        /// 测试更新方法2 - 创建未跟踪实体,调用dbcontext.Update方法
        /// </summary>
        [Fact]
        public async Task TestUpdate_2() {
            //常量
            var code = "TestUpdate_2_Code";

            //添加实体
            var entity = await AddProductAsync();
            UnitOfWork.ClearCache();

            //创建未跟踪实体
            var product = entity.MapTo<Product>();
            product.Code = code;
            //调用dbcontext.Update方法更新实体
            _repository.UpdateProduct( product );
            //提交工作单元
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            var result = await _repository.FindByIdAsync( entity.Id );
            Assert.Equal( code, result.Code );
        }

        /// <summary>
        /// 测试更新方法2的陷阱
        /// 如果在创建未跟踪实体并调用dbcontext.Update方法之前,从dbcontext中已查找出该实体,将发生异常
        /// </summary>
        [Fact]
        public async Task TestUpdate_2_InvalidOperation() {
            //常量
            var code = "TestUpdate_2_InvalidOperation_Code";

            //添加实体
            var entity = await AddProductAsync();
            UnitOfWork.ClearCache();

            //模拟更新之前无意中已查找出该实体
            await _repository.FindByIdAsync( entity.Id );

            //创建未跟踪实体
            var product = entity.MapTo<Product>();
            product.Code = code;

            //由于实体已被跟踪,调用dbcontext.Update方法更新实体将触发异常
            Assert.Throws<InvalidOperationException>( () => {
                _repository.UpdateProduct( product );
            } );
        }

        /// <summary>
        /// 测试更新并发 - 使用更新方法2
        /// </summary>
        [Fact]
        public async Task TestUpdate_2_Concurrency() {
            //常量
            var code = "TestUpdate_2_Concurrency_Code";
            var description = "TestUpdate_2_Concurrency_Description";

            //添加实体
            var entity = await AddProductAsync();
            UnitOfWork.ClearCache();

            //此处模拟用户1打开表单并修改,但尚未提交,这将保存旧实体
            var product = await _repository.FindByIdAsync( entity.Id );
            product.Code = code;
            UnitOfWork.ClearCache();

            //此处模拟用户2更新该实体,这将导致版本号变化
            var product2 = await _repository.FindByIdAsync( entity.Id );
            product2.Description = description;
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //此处模拟用户1提交表单,创建一个新的实体,并赋值
            var result = product.MapTo<Product>();

            //调用dbcontext.Update方法更新实体
            _repository.UpdateProduct( result );

            //提交工作单元,由于版本号变化,触发乐观锁
            await Assert.ThrowsAsync<ConcurrencyException>( async () => {
                await UnitOfWork.CommitAsync();
            } );
        }

        /// <summary>
        /// 测试Util Update更新方法 - 查找并修改实体,提交工作单元
        /// </summary>
        [Fact]
        public async Task TestUpdate_3_1() {
            //常量
            var code = "TestUpdate_3_1_Code";

            //添加实体
            var entity = await AddProductAsync();
            UnitOfWork.ClearCache();

            //查找实体并修改
            var product = await _repository.FindByIdAsync( entity.Id );
            product.Code = code;

            //调用Update方法
            await _repository.UpdateAsync( product );

            //提交工作单元
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            var result = _repository.FindById( entity.Id );
            Assert.Equal( code, result.Code );
        }

        /// <summary>
        /// 测试Util Update更新方法 - 创建未跟踪实体,调用Update方法
        /// </summary>
        [Fact]
        public async Task TestUpdate_3_2() {
            //常量
            var code = "TestUpdate_3_2_Code";

            //添加实体
            var entity = await AddProductAsync();
            UnitOfWork.ClearCache();

            //创建未跟踪实体
            var product = entity.MapTo<Product>();
            product.Code = code;

            //调用Update方法更新实体
            await _repository.UpdateAsync( product );

            //提交工作单元
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            var result = await _repository.FindByIdAsync( entity.Id );
            Assert.Equal( code, result.Code );
        }

        /// <summary>
        /// 测试Util Update更新方法 - 允许在创建未跟踪实体并调用Update方法之前查找实体,不会发生异常
        /// </summary>
        [Fact]
        public async Task TestUpdate_3_3() {
            //常量
            var code = "TestUpdate_3_3_InvalidOperation_Code";

            //添加实体
            var entity = await AddProductAsync();
            UnitOfWork.ClearCache();

            //模拟更新之前无意中已查找出该实体
            await _repository.FindByIdAsync( entity.Id );

            //创建未跟踪实体
            var product = entity.MapTo<Product>();
            product.Code = code;

            //调用Update方法更新实体
            await _repository.UpdateAsync( product );

            //提交工作单元
            _log.WriteLine( UnitOfWork.GetChangeTrackerDebugView() );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            var result = _repository.FindById( entity.Id );
            Assert.Equal( code, result.Code );
        }

        /// <summary>
        /// 测试更新并发 - 使用Util Update更新方法
        /// 通过赋值的方式更新查找实体的版本号,触发乐观锁
        /// </summary>
        [Fact]
        public async Task TestUpdate_3_Concurrency_1() {
            //常量
            var code = "TestUpdate_3_Concurrency_1_Code";
            var description = "TestUpdate_3_Concurrency_1_Description";

            //添加实体
            var entity = await AddProductAsync();
            UnitOfWork.ClearCache();

            //此处模拟用户1打开表单并修改,但尚未提交,这将保存旧实体
            var product = await _repository.FindByIdAsync( entity.Id );
            product.Code = code;
            UnitOfWork.ClearCache();

            //此处模拟用户2更新该实体,这将导致版本号变化
            var product2 = await _repository.FindByIdAsync( entity.Id );
            product2.Description = description;
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //此处模拟用户1提交表单,查找实体,并进行赋值
            var result = await _repository.FindByIdAsync( entity.Id );
            result.Code = product.Code;
            result.Description = product.Description;
            result.Version = product.Version;

            //调用Update方法更新实体时触发乐观锁
            await Assert.ThrowsAsync<ConcurrencyException>( async () => {
                await _repository.UpdateAsync( result );
            } );
        }

        /// <summary>
        /// 测试更新并发 - 使用Util Update更新方法
        /// 更新未跟踪实体触发乐观锁
        /// </summary>
        [Fact]
        public async Task TestUpdate_3_Concurrency_2() {
            //常量
            var code = "TestUpdate_3_Concurrency_2_Code";
            var description = "TestUpdate_3_Concurrency_2_Description";

            //添加实体
            var entity = await AddProductAsync();
            UnitOfWork.ClearCache();

            //此处模拟用户1打开表单并修改,但尚未提交,这将保存旧实体
            var product = await _repository.FindByIdAsync( entity.Id );
            product.Code = code;
            UnitOfWork.ClearCache();

            //此处模拟用户2更新该实体,这将导致版本号变化
            var product2 = await _repository.FindByIdAsync( entity.Id );
            product2.Description = description;
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //此处模拟用户1提交表单,创建一个新的实体,并赋值
            var result = product.MapTo<Product>();

            //调用Update方法更新实体
            await _repository.UpdateAsync( result );

            //提交工作单元,由于版本号变化,触发乐观锁
            await Assert.ThrowsAsync<ConcurrencyException>( async () => {
                await UnitOfWork.CommitAsync();
            } );
        }

        /// <summary>
        /// 测试更新集合
        /// </summary>
        [Fact]
        public async Task TestUpdate_4() {
            //常量
            var count = 3;
            var code = "TestUpdate_4_Code";

            //添加实体列表
            var entities = ProductFakeService.GetProducts( count );
            entities.ForEach( product => {
                product.Init();
            } );
            await _repository.AddAsync( entities );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //查找实体,赋值,调用Update方法,提交工作单元
            var products = await _repository.FindByIdsAsync( entities.Select( t => t.Id ) );
            products.ForEach( product => product.Code = code );
            await _repository.UpdateAsync( products );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            var result = await _repository.FindByIdsAsync( entities.Select( t => t.Id ) );
            Assert.Equal( code, result[0].Code );
            Assert.Equal( code, result[1].Code );
            Assert.Equal( code, result[2].Code );
        }

        #endregion

        #region Remove

        /// <summary>
        /// 测试通过标识移除实体 - 逻辑删除
        /// </summary>
        [Fact]
        public async Task TestRemoveAsync_Id_1() {
            //添加实体
            var entity = await AddProductAsync();
            UnitOfWork.ClearCache();

            //移除实体
            await _repository.RemoveAsync( entity.Id );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            var result = await _repository.FindByIdAsync( entity.Id );
            Assert.Null( result );
        }

        /// <summary>
        /// 测试通过标识移除实体 - 逻辑删除 - 使用工作单元禁用逻辑删除过滤器
        /// </summary>
        [Fact]
        public async Task TestRemoveAsync_Id_2() {
            //添加实体
            var entity = await AddProductAsync();
            UnitOfWork.ClearCache();

            //移除实体
            await _repository.RemoveAsync( entity.Id );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //使用工作单元禁用逻辑删除过滤器,可以查出
            using( UnitOfWork.DisableDeleteFilter() ) {
                var product = await _repository.FindByIdAsync( entity.Id );
                Assert.True( product.IsDeleted );
                Assert.Equal( entity.Code, product.Code );
            }
            UnitOfWork.ClearCache();

            //逻辑删除过滤器已启用,无法查出
            var result = await _repository.FindByIdAsync( entity.Id );
            Assert.Null( result );
        }

        /// <summary>
        /// 测试通过标识移除实体 - 逻辑删除 - 使用仓储禁用逻辑删除过滤器
        /// </summary>
        [Fact]
        public async Task TestRemoveAsync_Id_3() {
            //添加实体
            var entity = await AddProductAsync();
            UnitOfWork.ClearCache();

            //移除实体
            await _repository.RemoveAsync( entity.Id );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //使用仓储禁用逻辑删除过滤器,可以查出
            using( _repository.DisableDeleteFilter() ) {
                var product = await _repository.FindByIdAsync( entity.Id );
                Assert.True( product.IsDeleted );
                Assert.Equal( entity.Code, product.Code );
            }
            UnitOfWork.ClearCache();

            //逻辑删除过滤器已启用,无法查出
            var result = await _repository.FindByIdAsync( entity.Id );
            Assert.Null( result );
        }

        /// <summary>
        /// 测试移除实体 - 逻辑删除
        /// </summary>
        [Fact]
        public async Task TestRemoveAsync_Entity() {
            //添加实体
            var entity = await AddProductAsync();
            UnitOfWork.ClearCache();

            //移除实体
            await _repository.RemoveAsync( entity );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            var result = await _repository.FindByIdAsync( entity.Id );
            Assert.Null( result );
        }

        /// <summary>
        /// 测试移除实体集合 - 逻辑删除 - 通过标识列表
        /// </summary>
        [Fact]
        public async Task TestRemoveAsync_Entities_1() {
            //常量
            var count = 3;

            //添加实体列表
            var products = ProductFakeService.GetProducts( count ).ToList();
            products.ForEach( product => {
                product.Init();
            } );
            await _repository.AddAsync( products );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //移除实体集合
            var ids = products.Select( t => t.Id ).ToList();
            await _repository.RemoveAsync( ids );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            using( _repository.DisableDeleteFilter() ) {
                var result = await _repository.FindByIdsAsync( ids );
                Assert.Equal( count, result.Count );
                result.ForEach( t => Assert.True( t.IsDeleted ) );
            }
        }

        /// <summary>
        /// 测试移除实体集合 - 逻辑删除 - 通过实体列表
        /// </summary>
        [Fact]
        public async Task TestRemoveAsync_Entities_2() {
            //常量
            var count = 3;

            //添加实体列表
            var products = ProductFakeService.GetProducts( count ).ToList();
            products.ForEach( product => {
                product.Init();
            } );
            await _repository.AddAsync( products );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //移除实体集合
            await _repository.RemoveAsync( products );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            using( _repository.DisableDeleteFilter() ) {
                var result = await _repository.FindByIdsAsync( products.Select( t => t.Id ) );
                Assert.Equal( count, result.Count );
                result.ForEach( t => Assert.True( t.IsDeleted ) );
            }
        }

        #endregion

        #region Audit

        /// <summary>
        /// 测试设置创建审计属性
        /// </summary>
        [Fact]
        public async Task TestCreationAudit() {
            var entity = ProductFakeService.GetProduct();
            entity.Init();
            await _repository.AddAsync( entity );
            Assert.NotEqual( TestSession.TestUserId, entity.CreatorId );
            await UnitOfWork.CommitAsync();
            Assert.Equal( TestSession.TestUserId, entity.CreatorId );
            Assert.Equal( TestSession.TestUserId, entity.LastModifierId );
        }

        /// <summary>
        /// 测试设置修改审计属性
        /// </summary>
        [Fact]
        public async Task TestModificationAudit() {
            //工作单元
            var unitOfWork = (SqliteUnitOfWork)UnitOfWork;

            //常量
            var code = "TestModificationAudit";

            //添加实体
            var entity = await AddProductAsync();
            unitOfWork.ClearCache();

            //修改
            var product = entity.MapTo<Product>();
            product.Code = code;
            await _repository.UpdateAsync( product );
            unitOfWork.SetSession( new TestSession { UserId = TestSession.TestUserId2.ToString() } );

            //验证修改前审计属性
            Assert.Equal( TestSession.TestUserId, product.CreatorId );
            Assert.Equal( TestSession.TestUserId, product.LastModifierId );

            //提交
            await unitOfWork.CommitAsync();

            //验证修改后审计属性
            Assert.Equal( TestSession.TestUserId, product.CreatorId );
            Assert.Equal( TestSession.TestUserId2, product.LastModifierId );
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

            //添加实体
            var entity = new Product();
            entity.Init();
            entity.TestProperty1 = value;
            await _repository.AddAsync( entity );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            var result = await _repository.FindByIdAsync( entity.Id );
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
            var entity = new Product();
            entity.Init();
            entity.TestProperty1 = oldValue;
            await _repository.AddAsync( entity );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            var oldEntity = await _repository.FindByIdAsync( entity.Id );
            Assert.Equal( oldValue, oldEntity.TestProperty1 );

            //修改实体
            oldEntity.TestProperty1 = newValue;
            await _repository.UpdateAsync( oldEntity );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            var result = await _repository.FindByIdAsync( entity.Id );
            Assert.Equal( newValue, result.TestProperty1 );
        }

        /// <summary>
        /// 测试扩展属性 - 添加对象扩展属性
        /// </summary>
        [Fact]
        public async Task TestExtraProperties_3() {
            //常量
            var code = 2;
            var name = "TestExtraProperties_3";
            var enumValue = ProductEnum.World;

            //添加实体
            var entity = new Product();
            entity.Init();
            entity.TestProperty2.Code = code;
            entity.TestProperty2.Name = name;
            entity.TestProperty2.EnumValue = enumValue;
            await _repository.AddAsync( entity );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            var result = _repository.FindById( entity.Id );
            Assert.Equal( code, result.TestProperty2.Code );
            Assert.Equal( name, result.TestProperty2.Name );
            Assert.Equal( enumValue, result.TestProperty2.EnumValue );
        }

        /// <summary>
        /// 测试扩展属性 - 修改对象扩展属性
        /// </summary>
        [Fact]
        public async Task TestExtraProperties_4() {
            //常量
            var code = 2;
            var oldName = "TestExtraProperties_4_1";
            var newName = "TestExtraProperties_4_2";
            var oldEnumValue = ProductEnum.Hello;
            var newEnumValue = ProductEnum.World;

            //添加实体
            var entity = new Product();
            entity.Init();
            entity.TestProperty2.Code = code;
            entity.TestProperty2.Name = oldName;
            entity.TestProperty2.EnumValue = oldEnumValue;
            await _repository.AddAsync( entity );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            var oldEntity = await _repository.FindByIdAsync( entity.Id );
            Assert.Equal( code, oldEntity.TestProperty2.Code );
            Assert.Equal( oldName, oldEntity.TestProperty2.Name );
            Assert.Equal( oldEnumValue, oldEntity.TestProperty2.EnumValue );

            //修改实体
            oldEntity.TestProperty2.Name = newName;
            oldEntity.TestProperty2.EnumValue = newEnumValue;
            WriteTrackerDebug();
            await _repository.UpdateAsync( oldEntity );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            var result = await _repository.FindByIdAsync( entity.Id );
            Assert.Equal( newName, result.TestProperty2.Name );
            Assert.Equal( newEnumValue, result.TestProperty2.EnumValue );
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
            var entity = new Product();
            entity.Init();
            entity.TestProperties.Add( new ProductItem { Code = code, Name = name1 } );
            entity.TestProperties.Add( new ProductItem { Code = code, Name = name2 } );
            await _repository.AddAsync( entity );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            var result = await _repository.FindByIdAsync( entity.Id );
            Assert.Equal( 2, result.TestProperties.Count );
            Assert.Equal( code, result.TestProperties[0].Code );
            Assert.Equal( name1, result.TestProperties[0].Name );
            Assert.Equal( code, result.TestProperties[1].Code );
            Assert.Equal( name2, result.TestProperties[1].Name );
        }

        /// <summary>
        /// 测试扩展属性 - 修改对象集合扩展属性
        /// </summary>
        [Fact]
        public async Task TestExtraProperties_6() {
            //常量
            var code = 1;
            var oldName = "TestExtraProperties_6_1";
            var newName = "TestExtraProperties_6_2";
            var name3 = "TestExtraProperties_6_3";

            //添加实体
            var entity = new Product();
            entity.Init();
            entity.TestProperties.Add( new ProductItem { Code = code, Name = oldName } );
            entity.TestProperties.Add( new ProductItem { Code = code, Name = oldName } );
            await _repository.AddAsync( entity );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            var oldEntity = await _repository.FindByIdAsync( entity.Id );
            Assert.Equal( 2, oldEntity.TestProperties.Count );

            //修改实体
            oldEntity.TestProperties[0].Name = newName;
            oldEntity.TestProperties[1].Name = newName;
            oldEntity.TestProperties.Add( new ProductItem { Code = code, Name = name3 } );
            await _repository.UpdateAsync( oldEntity );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            var result = await _repository.FindByIdAsync( entity.Id );
            Assert.Equal( 3, result.TestProperties.Count );
            Assert.Equal( code, result.TestProperties[0].Code );
            Assert.Equal( newName, result.TestProperties[0].Name );
            Assert.Equal( code, result.TestProperties[1].Code );
            Assert.Equal( newName, result.TestProperties[1].Name );
            Assert.Equal( code, result.TestProperties[2].Code );
            Assert.Equal( name3, result.TestProperties[2].Name );
        }

        /// <summary>
        /// 测试扩展属性 - 添加多个扩展属性
        /// </summary>
        [Fact]
        public async Task TestExtraProperties_7() {
            //常量
            var code = 2;
            var name = "TestExtraProperties_7";

            //添加实体
            var entity = new Product();
            entity.Init();
            entity.TestProperty1 = name;
            entity.TestProperty2.Code = code;
            entity.TestProperty2.Name = name;
            entity.TestProperties.Add( new ProductItem { Code = code, Name = name } );
            entity.TestProperties.Add( new ProductItem { Code = code, Name = name } );
            await _repository.AddAsync( entity );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            var result = await _repository.FindByIdAsync( entity.Id );
            Assert.Equal( name, result.TestProperty1 );
            Assert.Equal( code, result.TestProperty2.Code );
            Assert.Equal( name, result.TestProperty2.Name );
            Assert.Equal( code, result.TestProperties[0].Code );
            Assert.Equal( name, result.TestProperties[0].Name );
            Assert.Equal( code, result.TestProperties[1].Code );
            Assert.Equal( name, result.TestProperties[1].Name );
        }

        /// <summary>
        /// 测试扩展属性 - 修改多个扩展属性
        /// </summary>
        [Fact]
        public async Task TestExtraProperties_8() {
            //常量
            var code = 2;
            var oldName = "TestExtraProperties_8_1";
            var newName = "TestExtraProperties_8_2";

            //添加实体
            var entity = new Product();
            entity.Init();
            entity.TestProperty1 = oldName;
            entity.TestProperty2.Code = code;
            entity.TestProperty2.Name = oldName;
            entity.TestProperties.Add( new ProductItem { Code = code, Name = oldName } );
            entity.TestProperties.Add( new ProductItem { Code = code, Name = oldName } );
            await _repository.AddAsync( entity );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            var oldEntity = await _repository.FindByIdAsync( entity.Id );
            Assert.Equal( oldName, oldEntity.TestProperty1 );
            Assert.Equal( code, oldEntity.TestProperty2.Code );
            Assert.Equal( oldName, oldEntity.TestProperty2.Name );
            Assert.Equal( 2, oldEntity.TestProperties.Count );

            //修改实体
            oldEntity.TestProperty1 = newName;
            oldEntity.TestProperty2.Name = newName;
            oldEntity.TestProperties[0].Name = newName;
            oldEntity.TestProperties[1].Name = newName;
            oldEntity.TestProperties.Add( new ProductItem{ Code = code, Name = newName } );
            await _repository.UpdateAsync( oldEntity );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            var result = await _repository.FindByIdAsync( entity.Id );
            Assert.Equal( newName, result.TestProperty1 );
            Assert.Equal( newName, result.TestProperty2.Name );
            Assert.Equal( 3, result.TestProperties.Count );
            Assert.Equal( newName, result.TestProperties[0].Name );
            Assert.Equal( newName, result.TestProperties[1].Name );
            Assert.Equal( newName, result.TestProperties[2].Name );
        }

        /// <summary>
        /// 测试扩展属性 - 添加枚举扩展属性
        /// </summary>
        [Fact]
        public async Task TestExtraProperties_9() {
            //常量
            ProductEnum value = ProductEnum.World;

            //添加实体
            var entity = new Product();
            entity.Init();
            entity.TestProperty3 = value;
            await _repository.AddAsync( entity );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            var result = await _repository.FindByIdAsync( entity.Id );
            Assert.Equal( value, result.TestProperty3 );
        }

        /// <summary>
        /// 测试扩展属性 - 修改枚举扩展属性
        /// </summary>
        [Fact]
        public async Task TestExtraProperties_10() {
            //常量
            ProductEnum oldValue = ProductEnum.Hello;
            ProductEnum newValue = ProductEnum.World;

            //添加实体
            var entity = new Product();
            entity.Init();
            entity.TestProperty3 = oldValue;
            await _repository.AddAsync( entity );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            var oldEntity = await _repository.FindByIdAsync( entity.Id );
            Assert.Equal( oldValue, oldEntity.TestProperty3 );

            //修改实体
            oldEntity.TestProperty3 = newValue;
            await _repository.UpdateAsync( oldEntity );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            var result = await _repository.FindByIdAsync( entity.Id );
            Assert.Equal( newValue, result.TestProperty3 );
        }

        /// <summary>
        /// 测试扩展属性 - 添加不可变对象扩展属性
        /// </summary>
        [Fact]
        public async Task TestExtraProperties_11() {
            //常量
            var code = 2;
            var name = "TestExtraProperties_11";

            //添加实体
            var entity = new Product();
            entity.Init();
            entity.TestProperty4 = new ProductItem2( code, name );
            await _repository.AddAsync( entity );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            var result = await _repository.FindByIdAsync( entity.Id );
            Assert.Equal( code, result.TestProperty4.Code );
            Assert.Equal( name, result.TestProperty4.Name );
        }

        /// <summary>
        /// 测试扩展属性 - 修改对象扩展属性
        /// </summary>
        [Fact]
        public async Task TestExtraProperties_12() {
            //常量
            var code = 2;
            var oldName = "TestExtraProperties_12_1";
            var newName = "TestExtraProperties_12_2";

            //添加实体
            var entity = new Product();
            entity.Init();
            entity.TestProperty4 = new ProductItem2( code, oldName );
            await _repository.AddAsync( entity );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            var oldEntity = await _repository.FindByIdAsync( entity.Id );
            Assert.Equal( code, oldEntity.TestProperty4.Code );
            Assert.Equal( oldName, oldEntity.TestProperty4.Name );

            //修改实体
            oldEntity.TestProperty4 =  new ProductItem2( code, newName );
            WriteTrackerDebug();
            await _repository.UpdateAsync( oldEntity );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //验证
            var result = await _repository.FindByIdAsync( entity.Id );
            Assert.Equal( newName, result.TestProperty4.Name );
        }

        #endregion
    }
}