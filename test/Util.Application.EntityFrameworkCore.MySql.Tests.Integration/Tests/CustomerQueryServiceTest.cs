using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Data.EntityFrameworkCore;
using Util.Tests.Fakes;
using Util.Tests.Infrastructure;
using Util.Tests.Models;
using Util.Tests.Queries;
using Util.Tests.Repositories;
using Util.Tests.Services;
using Util.Tests.UnitOfWorks;
using Xunit;
using Xunit.Abstractions;
using Xunit.DependencyInjection;

namespace Util.Applications.Tests {
    /// <summary>
    /// 客户查询服务测试
    /// 说明:
    /// 1. 测试查询服务操作
    /// </summary>
    public class CustomerQueryServiceTest : TestBase {

        #region 测试初始化

        /// <summary>
        /// 测试输出
        /// </summary>
        private readonly ITestOutputHelper _testOutputHelper;
        /// <summary>
        /// 客户仓储
        /// </summary>
        private readonly ICustomerRepository _repository;
        /// <summary>
        /// 客户查询服务
        /// </summary>
        private readonly ICustomerQueryService _service;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public CustomerQueryServiceTest( ITestOutputHelperAccessor testOutputHelperAccessor, ICustomerRepository repository,
            ICustomerQueryService service, ITestUnitOfWork unitOfWork ) : base( unitOfWork ) {
            _testOutputHelper = testOutputHelperAccessor.Output;
            _repository = repository;
            _service = service;
        }

        #endregion

        #region 辅助方法

        /// <summary>
        /// 添加客户
        /// </summary>
        public async Task<Customer> AddCustomerAsync() {
            return ( await AddCustomersAsync( 1 ) ).First();
        }

        /// <summary>
        /// 添加客户列表
        /// </summary>
        /// <param name="count">添加数量</param>
        /// <param name="name">客户姓名</param>
        public async Task<List<Customer>> AddCustomersAsync( int count = 2, string name = null ) {
            var customers = CustomerFakeService.GetCustomers( count );
            customers.ForEach( customer => {
                if ( name.IsEmpty() == false )
                    customer.Name = name;
            } );
            await _repository.AddAsync( customers );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();
            return customers.OrderBy( t => t.Code ).ToList();
        }

        /// <summary>
        /// 打印更改跟踪调试信息
        /// </summary>
        private void WriteTrackerDebug() {
            _testOutputHelper.WriteLine( UnitOfWork.GetChangeTrackerDebugView() );
        }

        #endregion

        #region GetAllAsync

        /// <summary>
        /// 测试获取全部实体
        /// </summary>
        [Fact]
        public async Task TestGetAllAsync() {
            var entities = await AddCustomersAsync();
            var dtos = await _service.GetAllAsync();
            Assert.True( dtos.Count >= entities.Count );
            Assert.Equal( entities[0].Name, dtos.Find( t => t.Id == entities[0].Id.ToString() )?.Name );
        }

        #endregion

        #region GetByIdAsync

        /// <summary>
        /// 测试通过标识获取实体
        /// </summary>
        [Fact]
        public async Task TestGetByIdAsync() {
            var entity = await AddCustomerAsync();
            var dto = await _service.GetByIdAsync( entity.Id );
            Assert.Equal( entity.Name, dto.Name );
        }

        #endregion

        #region GetByIdsAsync

        /// <summary>
        /// 测试通过标识列表获取实体列表
        /// </summary>
        [Fact]
        public async Task TestGetByIdsAsync() {
            var entities = await AddCustomersAsync();
            var dtos = await _service.GetByIdsAsync( entities.Select( t => t.Id ).Join() );
            Assert.Equal( entities.Count, dtos.Count );
            Assert.Equal( entities[0].Name, dtos.Find( t => t.Id == entities[0].Id.ToString() )?.Name );
        }

        #endregion

        #region QueryAsync

        /// <summary>
        /// 测试查询
        /// </summary>
        [Fact]
        public async Task TestQueryAsync() {
            //常量
            var name = "TestQueryAsync";

            //添加客户实体列表
            await AddCustomersAsync();
            var entities = await AddCustomersAsync( 5, name );

            //查询
            var query = new CustomerQuery {
                Name = name,
                Order = "Code"
            };
            var dtos = await _service.QueryAsync( query );
            WriteTrackerDebug();
            Assert.True( dtos.Count == entities.Count );
            Assert.Equal( entities[0].Id.ToString(), dtos[0].Id );
            Assert.Equal( entities[4].Id.ToString(), dtos[4].Id );
        }

        #endregion

        #region PageQueryAsync

        /// <summary>
        /// 测试分页查询 - 第1页
        /// </summary>
        [Fact]
        public async Task TestPageQueryAsync_1() {
            //常量
            var name = "TestPageQueryAsync_1";

            //添加客户实体列表
            await AddCustomersAsync();
            var entities = await AddCustomersAsync( 5, name );

            //查询
            var query = new CustomerQuery {
                PageSize = 3,
                Page = 1,
                Name = name,
                Order = "Code"
            };
            var dtos = await _service.PageQueryAsync( query );
            WriteTrackerDebug();
            Assert.Equal( 3, dtos.Data.Count );
            Assert.Equal( entities[0].Id.ToString(), dtos.Data[0].Id );
            Assert.Equal( entities[1].Id.ToString(), dtos.Data[1].Id );
            Assert.Equal( entities[2].Id.ToString(), dtos.Data[2].Id );
        }

        /// <summary>
        /// 测试分页查询 - 第2页
        /// </summary>
        [Fact]
        public async Task TestPageQueryAsync_2() {
            //常量
            var name = "TestPageQueryAsync_2";

            //添加客户实体列表
            await AddCustomersAsync();
            var entities = await AddCustomersAsync( 5, name );

            //查询
            var query = new CustomerQuery {
                PageSize = 3,
                Page = 2,
                Name = name,
                Order = "Code"
            };
            var dtos = await _service.PageQueryAsync( query );
            WriteTrackerDebug();
            Assert.Equal( 2, dtos.Data.Count );
            Assert.Equal( entities[3].Id.ToString(), dtos.Data[0].Id );
            Assert.Equal( entities[4].Id.ToString(), dtos.Data[1].Id );
        }

        #endregion
    }
}
