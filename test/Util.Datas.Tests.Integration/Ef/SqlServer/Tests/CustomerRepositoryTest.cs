using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Datas.Ef;
using Util.Datas.Queries;
using Util.Datas.Tests.Commons.Datas.Criterias;
using Util.Datas.Tests.Commons.Datas.SqlServer.Configs;
using Util.Datas.Tests.Commons.Domains.Models;
using Util.Datas.Tests.Commons.Domains.Repositories;
using Util.Datas.Tests.Ef.SqlServer.UnitOfWorks;
using Util.Dependency;
using Util.Helpers;
using Xunit;

namespace Util.Datas.Tests.Ef.SqlServer.Tests {
    /// <summary>
    /// 客户仓储测试 - 主要测试审计和查询操作
    /// </summary>
    [Collection( "GlobalConfig" )]
    public class CustomerRepositoryTest : IDisposable {
        /// <summary>
        /// 容器作用域
        /// </summary>
        private readonly IScope _scope;

        /// <summary>
        /// 工作单元
        /// </summary>
        private readonly ISqlServerUnitOfWork _unitOfWork;

        /// <summary>
        /// 客户仓储
        /// </summary>
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public CustomerRepositoryTest() {
            _scope = Ioc.BeginScope();
            _unitOfWork = _scope.Create<ISqlServerUnitOfWork>();
            _customerRepository = _scope.Create<ICustomerRepository>();
        }

        /// <summary>
        /// 测试清理
        /// </summary>
        public void Dispose() {
            _scope.Dispose();
        }

        /// <summary>
        /// 添加客户集合
        /// </summary>
        private List<Customer> AddCustomers() {
            var customers = Customer.CreateCustomers();
            _customerRepository.Add( customers );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();
            return customers;
        }

        /// <summary>
        /// 测试添加 - 测试创建操作审计
        /// </summary>
        [Fact]
        public void TestAdd() {
            string id = Id.ObjectId();
            var customer = new Customer( id ) {Name = "util"};
            _customerRepository.Add( customer );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            var result = _customerRepository.Single( t => t.Id == id );
            Assert.NotNull( result.CreationTime );
            Assert.NotNull( result.LastModificationTime );
            Assert.Equal( AppConfig.UserId.ToGuidOrNull(), result.CreatorId );
            Assert.Equal( AppConfig.UserId.ToGuidOrNull(), result.LastModifierId );
        }

        /// <summary>
        /// 测试修改 - 测试修改操作审计
        /// </summary>
        [Fact]
        public void TestUpdate() {
            string id = Id.ObjectId();
            var customer = new Customer( id ) {Name = "util"};
            _customerRepository.Add( customer );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            var result = _customerRepository.Single( t => t.Id == id );
            var creationTime = result.CreationTime;
            var lastModificationTime = result.LastModificationTime;
            Assert.Equal( "util", result.Name );
            result.Name = "utilcore";
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            result = _customerRepository.Single( t => t.Id == id );
            Assert.Equal( "utilcore", result.Name );
            Assert.Equal( creationTime, result.CreationTime );
            Assert.NotEqual( lastModificationTime, result.LastModificationTime );
            Assert.Equal( AppConfig.UserId.ToGuidOrNull(), result.CreatorId );
            Assert.Equal( AppConfig.UserId.ToGuidOrNull(), result.LastModifierId );
        }

        /// <summary>
        /// 测试查询 - 通过查询条件对象过滤
        /// </summary>
        [Fact]
        public void TestFind_Criteria() {
            AddCustomers();
            var result = _customerRepository.Find( new CustomerCriteria( "B", "B1" ) ).FirstOrDefault();
            Assert.Equal( "3", result.Mobile );
        }

        /// <summary>
        /// 测试查询数量
        /// </summary>
        [Fact]
        public void TestCount() {
            var customers = AddCustomers();
            var ids = customers.Select( t => t.Id ).ToList();
            Assert.Equal( customers.Count, _customerRepository.Count( t => ids.Contains( t.Id ) ) );
        }

        /// <summary>
        /// 测试异步查询数量
        /// </summary>
        [Fact]
        public async Task TestCountAsync() {
            var customers = AddCustomers();
            var ids = customers.Select( t => t.Id ).ToList();
            Assert.Equal( customers.Count, await _customerRepository.CountAsync( t => ids.Contains( t.Id ) ) );
        }

        /// <summary>
        /// 测试查询 - 通过查询对象过滤
        /// </summary>
        [Fact]
        public void TestQuery() {
            AddCustomers();
            var query = new Query<Customer, string>();
            query.Where( t => t.Name == "B" && t.Nickname == "B1" );
            var result = _customerRepository.Query( query );
            Assert.Equal( "3", result.First().Mobile );
        }

        /// <summary>
        /// 测试异步查询 - 通过查询对象过滤
        /// </summary>
        [Fact]
        public async Task TestQueryAsync() {
            AddCustomers();
            var query = new Query<Customer, string>();
            query.Where( t => t.Name == "B" && t.Nickname == "B1" );
            var result = await _customerRepository.QueryAsync( query );
            Assert.Equal( "3", result.First().Mobile );
        }

        /// <summary>
        /// 测试查询 - 通过查询对象过滤，获取未跟踪实体
        /// </summary>
        [Fact]
        public void TestQueryAsNoTracking() {
            AddCustomers();
            var query = new Query<Customer, string>();
            query.Where( t => t.Name == "B" && t.Nickname == "B1" );
            var entity = _customerRepository.QueryAsNoTracking( query ).First();
            Assert.Equal( "3", entity.Mobile );

            var id = entity.Id;
            entity.Name = "abc";
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            Assert.False( _customerRepository.Exists( t => t.Id == id && t.Name == "abc" ) );
        }

        /// <summary>
        /// 测试查询 - 通过查询对象过滤，获取未跟踪实体
        /// </summary>
        [Fact]
        public async Task TestQueryAsNoTrackingAsync() {
            AddCustomers();
            var query = new Query<Customer, string>();
            query.Where( t => t.Name == "B" && t.Nickname == "B1" );
            var result = await _customerRepository.QueryAsNoTrackingAsync( query );
            var entity = result.First();
            Assert.Equal( "3", entity.Mobile );

            var id = entity.Id;
            entity.Name = "abc";
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            Assert.False( await _customerRepository.ExistsAsync( t => t.Id == id && t.Name == "abc" ) );
        }

        /// <summary>
        /// 测试分页查询
        /// </summary>
        [Fact]
        public void TestPagerQuery() {
            var ids = AddCustomers().Select( t => t.Id ).ToList();
            QueryParameter parameter = new QueryParameter {PageSize = 2, Page = 2};
            var query = new Query<Customer, string>( parameter );
            query.Where( t => ids.Contains( t.Id ) );
            var result = _customerRepository.PagerQuery( query );
            Assert.Equal( 5, result.TotalCount );
            Assert.Equal( 3, result.PageCount );
            Assert.Equal( 2, result.Data.Count );
        }

        /// <summary>
        /// 测试异步分页查询
        /// </summary>
        [Fact]
        public async Task TestPagerQueryAsync() {
            var ids = AddCustomers().Select( t => t.Id ).ToList();
            QueryParameter parameter = new QueryParameter {PageSize = 2, Page = 2};
            var query = new Query<Customer, string>( parameter );
            query.Where( t => ids.Contains( t.Id ) );
            var result = await _customerRepository.PagerQueryAsync( query );
            Assert.Equal( 5, result.TotalCount );
            Assert.Equal( 3, result.PageCount );
            Assert.Equal( 2, result.Data.Count );
        }

        /// <summary>
        /// 测试查询 - 选择性添加条件
        /// </summary>
        [Fact]
        public void TestWhereIf() {
            var ids = AddCustomers().Select( t => t.Id ).ToList();
            Assert.Single( _customerRepository.Find().WhereIf( t => t.Id == ids[0], true ).ToList() );
            Assert.Equal( ids.Count,
                _customerRepository.Find().Where( t => ids.Contains( t.Id ) ).WhereIf( t => t.Name == "C", false )
                    .ToList().Count );
        }

        /// <summary>
        /// 测试查询 - 选择性添加条件
        /// </summary>
        [Fact]
        public void TestWhereIf_2() {
            var ids = AddCustomers().Select( t => t.Id ).ToList();

            var query = new Query<Customer>();
            query.WhereIf( t => t.Id == ids[0], true );
            Assert.Single( _customerRepository.Find( query ).ToList() );

            query = new Query<Customer>();
            query.Where( t => ids.Contains( t.Id ) );
            query.WhereIf( t => ids.Contains( t.Id ), false );
            Assert.Equal( ids.Count, _customerRepository.Find( query ).ToList().Count );
        }

        /// <summary>
        /// 测试查询 - 添加条件 - 自动判断空值
        /// </summary>
        [Fact]
        public void TestWhereIfNotEmpty() {
            var ids = AddCustomers().Select( t => t.Id ).ToList();
            Assert.NotEmpty( _customerRepository.Find().Where( t => ids.Contains( t.Id ) )
                .WhereIfNotEmpty( t => t.Name == "" ).ToList() );
            Assert.Single( _customerRepository.Find().Where( t => ids.Contains( t.Id ) )
                .WhereIfNotEmpty( t => t.Name == "C" ).ToList() );
        }

        /// <summary>
        /// 测试查询 - 添加条件 - 自动判断空值
        /// </summary>
        [Fact]
        public void TestWhereIfNotEmpty_2() {
            var ids = AddCustomers().Select( t => t.Id ).ToList();

            var query = new Query<Customer>();
            query.Where( t => ids.Contains( t.Id ) );
            query.WhereIfNotEmpty( t => t.Name == "" );
            Assert.NotEmpty( _customerRepository.Find( query ).ToList() );

            query = new Query<Customer>();
            query.Where( t => ids.Contains( t.Id ) );
            query.WhereIfNotEmpty( t => t.Name == "C" );
            Assert.Single( _customerRepository.Find( query ).ToList() );
        }
    }
}
