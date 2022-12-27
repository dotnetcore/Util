using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Util.Data.Queries;
using Util.Tests.Fakes;
using Util.Tests.Infrastructure;
using Util.Tests.Models;
using Util.Tests.Repositories;
using Util.Tests.UnitOfWorks;
using Xunit;

namespace Util.Data.EntityFrameworkCore.Tests {
    /// <summary>
    /// 客户仓储测试
    /// 说明:
    /// 1. 测试自增长int类型标识
    /// 2. 测试日期范围查询
    /// 3. 测试分页查询
    /// 4. 测试Utc日期
    /// </summary>
    public class CustomerRepositoryTest : TestBase {

        #region 测试初始化

        /// <summary>
        /// 仓储
        /// </summary>
        private readonly ICustomerRepository _repository;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public CustomerRepositoryTest( ICustomerRepository repository, ITestUnitOfWork unitOfWork ) : base( unitOfWork ) {
            _repository = repository;
        }

        #endregion

        #region 辅助操作

        /// <summary>
        /// 添加实体列表
        /// </summary>
        /// <param name="count">添加数量</param>
        /// <param name="name">客户名称</param>
        private async Task<List<Customer>> AddCustomersAsync( int count = 2, string name = null ) {
            var customers = CustomerFakeService.GetCustomers( count );
            customers.ForEach( customer => {
                if ( name != null )
                    customer.Name = name;
                customer.CreationTime = null;
            } );
            await _repository.AddAsync( customers );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();
            return customers.OrderBy( t => t.Code ).ToList();
        }

        #endregion

        #region Between

        /// <summary>
        /// 测试添加范围查询条件 - 日期带时间
        /// </summary>
        [Fact]
        public async Task TestBetween_DateTime_1() {
            //常量
            var name = "TestBetween_DateTime_1";
            var birthday = "2005-5-5 05:05:05".ToDateTime();
            var minBirthday = "2005-5-6 06:05:05".ToDateTime();
            var maxBirthday = "2005-5-8 06:05:05".ToDateTime();

            //添加实体列表
            await AddCustomersAsync();
            var customers = CustomerFakeService.GetCustomers( 5 );
            customers.ForEach( customer => {
                customer.Name = name;
                customer.Birthday = birthday;
                birthday = birthday.AddDays( 1 );
            } );
            await _repository.AddAsync( customers );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //查询
            var result = await _repository.Find().Where( t => t.Name == name ).Between( t => t.Birthday, minBirthday, maxBirthday ).ToListAsync();

            //验证
            Assert.Equal( 2, result.Count );
        }

        /// <summary>
        /// 测试添加范围查询条件 - 日期带时间 - 包含左边界
        /// </summary>
        [Fact]
        public async Task TestBetween_DateTime_2() {
            //常量
            var name = "TestBetween_DateTime_2";
            var birthday = "2005-5-5 05:05:05".ToDateTime();
            var minBirthday = "2005-5-6 05:05:05".ToDateTime();
            var maxBirthday = "2005-5-8 05:05:05".ToDateTime();

            //添加实体列表
            await AddCustomersAsync();
            var customers = CustomerFakeService.GetCustomers( 5 );
            customers.ForEach( customer => {
                customer.Name = name;
                customer.Birthday = birthday;
                birthday = birthday.AddDays( 1 );
            } );
            await _repository.AddAsync( customers );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //查询
            var result = await _repository.Find().Where( t => t.Name == name ).Between( t => t.Birthday, minBirthday, maxBirthday, boundary: Boundary.Left ).ToListAsync();

            //验证
            Assert.Equal( 2, result.Count );
        }

        /// <summary>
        /// 测试添加范围查询条件 - 日期带时间 - 包含右边界
        /// </summary>
        [Fact]
        public async Task TestBetween_DateTime_3() {
            //常量
            var name = "TestBetween_DateTime_3";
            var birthday = "2005-5-5 05:05:05".ToDateTime();
            var minBirthday = "2005-5-6 05:05:05".ToDateTime();
            var maxBirthday = "2005-5-8 05:05:05".ToDateTime();

            //添加实体列表
            await AddCustomersAsync();
            var customers = CustomerFakeService.GetCustomers( 5 );
            customers.ForEach( customer => {
                customer.Name = name;
                customer.Birthday = birthday;
                birthday = birthday.AddDays( 1 );
            } );
            await _repository.AddAsync( customers );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //查询
            var result = await _repository.Find().Where( t => t.Name == name ).Between( t => t.Birthday, minBirthday, maxBirthday, boundary: Boundary.Right ).ToListAsync();

            //验证
            Assert.Equal( 2, result.Count );
        }

        /// <summary>
        /// 测试添加范围查询条件 - 日期带时间 - 包含两边
        /// </summary>
        [Fact]
        public async Task TestBetween_DateTime_4() {
            //常量
            var name = "TestBetween_DateTime_4";
            var birthday = "2005-5-5 05:05:05".ToDateTime();
            var minBirthday = "2005-5-6 05:05:05".ToDateTime();
            var maxBirthday = "2005-5-8 05:05:05".ToDateTime();

            //添加实体列表
            await AddCustomersAsync();
            var customers = CustomerFakeService.GetCustomers( 5 );
            customers.ForEach( customer => {
                customer.Name = name;
                customer.Birthday = birthday;
                birthday = birthday.AddDays( 1 );
            } );
            await _repository.AddAsync( customers );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //查询
            var result = await _repository.Find().Where( t => t.Name == name ).Between( t => t.Birthday, minBirthday, maxBirthday, boundary: Boundary.Both ).ToListAsync();

            //验证
            Assert.Equal( 3, result.Count );
        }

        /// <summary>
        /// 测试添加范围查询条件 - 日期带时间 - 不包含边界
        /// </summary>
        [Fact]
        public async Task TestBetween_DateTime_5() {
            //常量
            var name = "TestBetween_DateTime_5";
            var birthday = "2005-5-5 05:05:05".ToDateTime();
            var minBirthday = "2005-5-6 05:05:05".ToDateTime();
            var maxBirthday = "2005-5-8 05:05:05".ToDateTime();

            //添加实体列表
            await AddCustomersAsync();
            var customers = CustomerFakeService.GetCustomers( 5 );
            customers.ForEach( customer => {
                customer.Name = name;
                customer.Birthday = birthday;
                birthday = birthday.AddDays( 1 );
            } );
            await _repository.AddAsync( customers );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //查询
            var result = await _repository.Find().Where( t => t.Name == name ).Between( t => t.Birthday, minBirthday, maxBirthday, boundary: Boundary.Neither ).ToListAsync();

            //验证
            Assert.Single( result );
        }

        /// <summary>
        /// 测试添加范围查询条件 - 日期带时间 - 最大值为空
        /// </summary>
        [Fact]
        public async Task TestBetween_DateTime_6() {
            //常量
            var name = "TestBetween_DateTime_6";
            var birthday = "2005-5-5 05:05:05".ToDateTime();
            var minBirthday = "2005-5-6 05:05:05".ToDateTime();

            //添加实体列表
            await AddCustomersAsync();
            var customers = CustomerFakeService.GetCustomers( 5 );
            customers.ForEach( customer => {
                customer.Name = name;
                customer.Birthday = birthday;
                birthday = birthday.AddDays( 1 );
            } );
            await _repository.AddAsync( customers );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //查询
            var result = await _repository.Find().Where( t => t.Name == name ).Between( t => t.Birthday, minBirthday, null, boundary: Boundary.Both ).ToListAsync();

            //验证
            Assert.Equal( 4, result.Count );
        }

        /// <summary>
        /// 测试添加范围查询条件 - 日期带时间 - 最小值为空
        /// </summary>
        [Fact]
        public async Task TestBetween_DateTime_7() {
            //常量
            var name = "TestBetween_DateTime_7";
            var birthday = "2005-5-5 05:05:05".ToDateTime();
            var maxBirthday = "2005-5-8 05:05:05".ToDateTime();

            //添加实体列表
            await AddCustomersAsync();
            var customers = CustomerFakeService.GetCustomers( 5 );
            customers.ForEach( customer => {
                customer.Name = name;
                customer.Birthday = birthday;
                birthday = birthday.AddDays( 1 );
            } );
            await _repository.AddAsync( customers );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //查询
            var result = await _repository.Find().Where( t => t.Name == name ).Between( t => t.Birthday, null, maxBirthday, boundary: Boundary.Both ).ToListAsync();

            //验证
            Assert.Equal( 4, result.Count );
        }

        /// <summary>
        /// 测试添加范围查询条件 - 日期不带时间 - 包含左边界
        /// </summary>
        [Fact]
        public async Task TestBetween_Date_1() {
            //常量
            var name = "TestBetween_Date_1";
            var birthday = "2005-5-5 05:05:05".ToDateTime();
            var minBirthday = "2005-5-6".ToDateTime();
            var maxBirthday = "2005-5-8".ToDateTime();

            //添加实体列表
            await AddCustomersAsync();
            var customers = CustomerFakeService.GetCustomers( 5 );
            customers.ForEach( customer => {
                customer.Name = name;
                customer.Birthday = birthday;
                birthday = birthday.AddDays( 1 );
            } );
            await _repository.AddAsync( customers );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //查询
            var result = await _repository.Find()
                .Where( t => t.Name == name )
                .Between( t => t.Birthday, minBirthday, maxBirthday, false, Boundary.Left )
                .OrderBy( t => t.Birthday )
                .ToListAsync();

            //验证
            Assert.Equal( 2, result.Count );
            Assert.Equal( 6, result[0].Birthday.SafeValue().Day );
            Assert.Equal( 7, result[1].Birthday.SafeValue().Day );
        }

        /// <summary>
        /// 测试添加范围查询条件 - 日期不带时间 - 包含右边界
        /// </summary>
        [Fact]
        public async Task TestBetween_Date_2() {
            //常量
            var name = "TestBetween_Date_2";
            var birthday = "2005-5-5 05:05:05".ToDateTime();
            var minBirthday = "2005-5-6".ToDateTime();
            var maxBirthday = "2005-5-8".ToDateTime();

            //添加实体列表
            await AddCustomersAsync();
            var customers = CustomerFakeService.GetCustomers( 5 );
            customers.ForEach( customer => {
                customer.Name = name;
                customer.Birthday = birthday;
                birthday = birthday.AddDays( 1 );
            } );
            await _repository.AddAsync( customers );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //查询
            var result = await _repository.Find()
                .Where( t => t.Name == name )
                .Between( t => t.Birthday, minBirthday, maxBirthday, false, Boundary.Right )
                .OrderBy( t => t.Birthday )
                .ToListAsync();

            //验证
            Assert.Equal( 2, result.Count );
            Assert.Equal( 7, result[0].Birthday.SafeValue().Day );
            Assert.Equal( 8, result[1].Birthday.SafeValue().Day );
        }

        /// <summary>
        /// 测试添加范围查询条件 - 日期不带时间 - 包含两边
        /// </summary>
        [Fact]
        public async Task TestBetween_Date_3() {
            //常量
            var name = "TestBetween_Date_3";
            var birthday = "2005-5-5 05:05:05".ToDateTime();
            var minBirthday = "2005-5-6".ToDateTime();
            var maxBirthday = "2005-5-8".ToDateTime();

            //添加实体列表
            await AddCustomersAsync();
            var customers = CustomerFakeService.GetCustomers( 5 );
            customers.ForEach( customer => {
                customer.Name = name;
                customer.Birthday = birthday;
                birthday = birthday.AddDays( 1 );
            } );
            await _repository.AddAsync( customers );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //查询
            var result = await _repository.Find()
                .Where( t => t.Name == name )
                .Between( t => t.Birthday, minBirthday, maxBirthday, false, Boundary.Both )
                .OrderBy( t => t.Birthday )
                .ToListAsync();

            //验证
            Assert.Equal( 3, result.Count );
            Assert.Equal( 6, result[0].Birthday.SafeValue().Day );
            Assert.Equal( 7, result[1].Birthday.SafeValue().Day );
            Assert.Equal( 8, result[2].Birthday.SafeValue().Day );
        }

        /// <summary>
        /// 测试添加范围查询条件 - 日期不带时间 - 不包含边界
        /// </summary>
        [Fact]
        public async Task TestBetween_Date_4() {
            //常量
            var name = "TestBetween_Date_4";
            var birthday = "2005-5-5 05:05:05".ToDateTime();
            var minBirthday = "2005-5-6".ToDateTime();
            var maxBirthday = "2005-5-8".ToDateTime();

            //添加实体列表
            await AddCustomersAsync();
            var customers = CustomerFakeService.GetCustomers( 5 );
            customers.ForEach( customer => {
                customer.Name = name;
                customer.Birthday = birthday;
                birthday = birthday.AddDays( 1 );
            } );
            await _repository.AddAsync( customers );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //查询
            var result = await _repository.Find()
                .Where( t => t.Name == name )
                .Between( t => t.Birthday, minBirthday, maxBirthday, false, Boundary.Neither )
                .ToListAsync();

            //验证
            Assert.Single( result );
            Assert.Equal( 7, result[0].Birthday.SafeValue().Day );
        }

        /// <summary>
        /// 测试添加范围查询条件 - 日期不带时间 - 最大值为空
        /// </summary>
        [Fact]
        public async Task TestBetween_Date_5() {
            //常量
            var name = "TestBetween_Date_5";
            var birthday = "2005-5-5 05:05:05".ToDateTime();
            var minBirthday = "2005-5-6".ToDateTime();

            //添加实体列表
            await AddCustomersAsync();
            var customers = CustomerFakeService.GetCustomers( 5 );
            customers.ForEach( customer => {
                customer.Nickname = name;
                customer.Name = name;
                customer.Birthday = birthday;
                birthday = birthday.AddDays( 1 );
            } );
            await _repository.AddAsync( customers );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //查询
            var result = await _repository.Find()
                .Where( t => t.Name == name )
                .Between( t => t.Birthday, minBirthday, null, false )
                .OrderBy( t => t.Birthday )
                .ToListAsync();

            //验证
            Assert.Equal( 4, result.Count );
            Assert.Equal( 6, result[0].Birthday.SafeValue().Day );
        }

        /// <summary>
        /// 测试添加范围查询条件 - 日期不带时间 - 最小值为空
        /// </summary>
        [Fact]
        public async Task TestBetween_Date_6() {
            //常量
            var name = "TestBetween_Date_6";
            var birthday = "2005-5-5 05:05:05".ToDateTime();
            var maxBirthday = "2005-5-8".ToDateTime();

            //添加实体列表
            await AddCustomersAsync();
            var customers = CustomerFakeService.GetCustomers( 5 );
            customers.ForEach( customer => {
                customer.Name = name;
                customer.Birthday = birthday;
                birthday = birthday.AddDays( 1 );
            } );
            await _repository.AddAsync( customers );
            await UnitOfWork.CommitAsync();
            UnitOfWork.ClearCache();

            //查询
            var result = await _repository.Find()
                .Where( t => t.Name == name )
                .Between( t => t.Birthday, null, maxBirthday, false )
                .ToListAsync();

            //验证
            Assert.Equal( 4, result.Count );
        }

        #endregion

        #region ToPageList

        /// <summary>
        /// 测试获取分页列表
        /// </summary>
        [Fact]
        public async Task TestToPageList_1() {
            //常量
            var name = "TestToPageList_1";

            //添加实体列表
            var customers = await AddCustomersAsync( 10, name );

            //创建查询参数
            var parameter = new QueryParameter { PageSize = 3, Page = 1, Order = "Code" };

            //查询
            var result = _repository.Find().Where( t => t.Name == name ).ToPageList( parameter );

            //验证
            Assert.Equal( 4, result.PageCount );
            Assert.Equal( 1, result.Page );
            Assert.Equal( 3, result.PageSize );
            Assert.Equal( 10, result.Total );
            Assert.Equal( 3, result.Data.Count );
            Assert.Equal( customers[0].Id, result.Data[0].Id );
            Assert.Equal( customers[1].Id, result.Data[1].Id );
            Assert.Equal( customers[2].Id, result.Data[2].Id );
        }

        /// <summary>
        /// 测试获取分页列表 - 第二页
        /// </summary>
        [Fact]
        public async Task TestToPageList_2() {
            //常量
            var name = "TestToPageList_2";

            //添加实体列表
            var customers = await AddCustomersAsync( 10, name );

            //创建查询参数
            var parameter = new QueryParameter { PageSize = 3, Page = 2, Order = "Code" };

            //查询
            var result = _repository.Find().Where( t => t.Name == name ).ToPageList( parameter );

            //验证
            Assert.Equal( 4, result.PageCount );
            Assert.Equal( 2, result.Page );
            Assert.Equal( 3, result.PageSize );
            Assert.Equal( 10, result.Total );
            Assert.Equal( 3, result.Data.Count );
            Assert.Equal( customers[3].Id, result.Data[0].Id );
            Assert.Equal( customers[4].Id, result.Data[1].Id );
            Assert.Equal( customers[5].Id, result.Data[2].Id );
        }

        /// <summary>
        /// 测试获取分页列表 - Queryable设置排序
        /// </summary>
        [Fact]
        public async Task TestToPageList_3() {
            //常量
            var name = "TestToPageList_3";

            //添加实体列表
            var customers = await AddCustomersAsync( 10, name );

            //创建查询参数
            var parameter = new QueryParameter { PageSize = 3, Page = 2 };

            //查询
            var result = _repository.Find().Where( t => t.Name == name ).OrderBy( t => t.Code ).ToPageList( parameter );

            //验证
            Assert.Equal( 4, result.PageCount );
            Assert.Equal( 2, result.Page );
            Assert.Equal( 3, result.PageSize );
            Assert.Equal( 10, result.Total );
            Assert.Equal( 3, result.Data.Count );
            Assert.Equal( customers[3].Id, result.Data[0].Id );
            Assert.Equal( customers[4].Id, result.Data[1].Id );
            Assert.Equal( customers[5].Id, result.Data[2].Id );
        }

        #endregion

        #region ToPageListAsync

        /// <summary>
        /// 测试获取分页列表
        /// </summary>
        [Fact]
        public async Task TestToPageListAsync() {
            //常量
            var name = "TestToPageListAsync";

            //添加实体列表
            var customers = await AddCustomersAsync( 10, name );

            //创建查询参数
            var parameter = new QueryParameter { PageSize = 3, Page = 2, Order = "Code" };

            //查询
            var result = await _repository.Find().Where( t => t.Name == name ).ToPageListAsync( parameter );

            //验证
            Assert.Equal( 4, result.PageCount );
            Assert.Equal( 2, result.Page );
            Assert.Equal( 3, result.PageSize );
            Assert.Equal( 10, result.Total );
            Assert.Equal( 3, result.Data.Count );
            Assert.Equal( customers[3].Id, result.Data[0].Id );
            Assert.Equal( customers[4].Id, result.Data[1].Id );
            Assert.Equal( customers[5].Id, result.Data[2].Id );
        }

        #endregion
    }
}