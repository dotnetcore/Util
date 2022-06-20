using System.Threading.Tasks;
using Util.Tests.EventHandlers;
using Util.Tests.Fakes;
using Util.Tests.Infrastructure;
using Util.Tests.Repositories;
using Util.Tests.UnitOfWorks;
using Xunit;
using Xunit.Abstractions;

namespace Util.Data.EntityFrameworkCore.Tests {
    /// <summary>
    /// 实体事件测试
    /// </summary>
    public class EntityEventsTest : TestBase {

        #region 测试初始化

        /// <summary>
        /// 测试输出
        /// </summary>
        private readonly ITestOutputHelper _testOutputHelper;
        /// <summary>
        /// 产品仓储
        /// </summary>
        private readonly IProductRepository _productRepository;
        /// <summary>
        /// 操作日志仓储
        /// </summary>
        private readonly IOperationLogRepository _operationLogRepository;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public EntityEventsTest( ITestOutputHelper testOutputHelper, IProductRepository productRepository, 
            IOperationLogRepository operationLogRepository, ITestUnitOfWork unitOfWork ) :base(unitOfWork){
            _testOutputHelper = testOutputHelper;
            _productRepository = productRepository;
            _operationLogRepository = operationLogRepository;
        }

        #endregion

        #region 实体创建事件

        /// <summary>
        /// 测试实体创建事件
        /// </summary>
        [Fact]
        public async Task TestEntityCreatedEvent() {
            //添加实体
            var entity = ProductFakeService.GetProduct();
            entity.Init();
            entity.Name = "EntityCreatedEvent";
            await _productRepository.AddAsync( entity );
            await UnitOfWork.CommitAsync();

            //验证
            Assert.True( await _operationLogRepository.ExistsAsync( t => t.Caption == "EntityCreatedEvent" && t.LogName == nameof( ProductCreatedEventHandler ) ) );
        }

        /// <summary>
        /// 测试实体变更事件 - 创建
        /// </summary>
        [Fact]
        public async Task TestEntityChangedEvent_Created() {
            //添加实体
            var entity = ProductFakeService.GetProduct();
            entity.Init();
            entity.Name = "EntityChangedEvent_Created";
            await _productRepository.AddAsync( entity );
            await UnitOfWork.CommitAsync();

            //验证
            Assert.True( await _operationLogRepository.ExistsAsync( t => t.Caption == "EntityChangedEvent_Created" && t.LogName == nameof( ProductChangedEventHandler ) ) );
        }

        #endregion

        #region 实体修改事件

        /// <summary>
        /// 测试实体修改事件
        /// </summary>
        [Fact]
        public async Task TestEntityUpdatedEvent() {
            //添加实体
            var entity = ProductFakeService.GetProduct();
            entity.Init();
            await _productRepository.AddAsync( entity );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //修改实体
            var product = await _productRepository.FindByIdAsync( entity.Id );
            product.Name = "EntityUpdatedEvent";
            await _productRepository.UpdateAsync( product );
            await UnitOfWork.CommitAsync();

            //验证
            Assert.True( await _operationLogRepository.ExistsAsync( t => t.Caption == "EntityUpdatedEvent" && t.LogName == nameof( ProductUpdatedEventHandler ) ) );
        }

        /// <summary>
        /// 测试实体变更事件 - 修改
        /// </summary>
        [Fact]
        public async Task TestEntityChangedEvent_Updated() {
            //添加实体
            var entity = ProductFakeService.GetProduct();
            entity.Init();
            await _productRepository.AddAsync( entity );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //修改实体
            var product = _productRepository.FindById( entity.Id );
            product.Name = "EntityChangedEvent_Updated";
            await _productRepository.UpdateAsync( product );
            await UnitOfWork.CommitAsync();

            //验证
            Assert.True( await _operationLogRepository.ExistsAsync( t => t.Caption == "EntityChangedEvent_Updated" && t.LogName == nameof( ProductChangedEventHandler ) ) );
        }

        #endregion

        #region 实体删除事件

        /// <summary>
        /// 测试实体删除事件 - 逻辑删除
        /// </summary>
        [Fact]
        public async Task TestEntityDeletedEvent_1() {
            //添加实体
            var entity = ProductFakeService.GetProduct();
            entity.Init();
            entity.Name = "EntityDeletedEvent";
            await _productRepository.AddAsync( entity );
            await UnitOfWork.CommitAsync();

            //删除实体
            await _productRepository.RemoveAsync( entity );
            await UnitOfWork.CommitAsync();

            //验证
            Assert.True( await _operationLogRepository.ExistsAsync( t => t.Caption == "EntityDeletedEvent" && t.LogName == nameof( ProductDeletedEventHandler ) ) );
        }

        /// <summary>
        /// 测试实体删除事件 - 物理删除
        /// </summary>
        [Fact]
        public async Task TestEntityDeletedEvent_2() {
            //添加实体
            var entity = OperationLogFakeService.GetOperationLog();
            entity.Init();
            entity.LogName = "EntityDeletedEvent";
            await _operationLogRepository.AddAsync( entity );
            await UnitOfWork.CommitAsync();

            //删除实体
            await _operationLogRepository.RemoveAsync( entity );
            await UnitOfWork.CommitAsync();

            //验证
            Assert.True( await _operationLogRepository.ExistsAsync( t => t.LogName == "Test" && t.Caption == nameof( OperationLogDeletedEventHandler ) && t.Content == "EntityDeletedEvent" ) );
        }

        /// <summary>
        /// 测试实体变更事件 - 逻辑删除
        /// </summary>
        [Fact]
        public async Task TestEntityChangedEvent_Deleted_1() {
            //添加实体
            var entity = ProductFakeService.GetProduct();
            entity.Init();
            entity.Name = "EntityChangedEvent_Deleted";
            await _productRepository.AddAsync( entity );
            await UnitOfWork.CommitAsync();

            //删除实体
            await _productRepository.RemoveAsync( entity );
            await UnitOfWork.CommitAsync();

            //验证
            Assert.True( await _operationLogRepository.ExistsAsync( t => t.Caption == "EntityChangedEvent_Deleted" && t.LogName == nameof( ProductChangedEventHandler ) ) );
        }

        /// <summary>
        /// 测试实体变更事件 - 物理删除
        /// </summary>
        [Fact]
        public async Task TestEntityChangedEvent_Deleted_2() {
            //添加实体
            var entity = OperationLogFakeService.GetOperationLog();
            entity.Init();
            entity.LogName = "EntityChangedEvent_Deleted";
            await _operationLogRepository.AddAsync( entity );
            await UnitOfWork.CommitAsync();

            //删除实体
            await _operationLogRepository.RemoveAsync( entity );
            await UnitOfWork.CommitAsync();

            //验证
            Assert.True( await _operationLogRepository.ExistsAsync( t => t.LogName == "Test" && t.Caption == nameof( OperationLogChangedEventHandler ) && t.Content == "EntityChangedEvent_Deleted" ) );
        }

        #endregion
    }
}
