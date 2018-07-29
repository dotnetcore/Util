using System;
using System.Threading.Tasks;
using Util.Datas.Sql.Queries;
using Util.Datas.Tests.Commons.Domains.Models;
using Util.Datas.Tests.Commons.Domains.Repositories;
using Util.Datas.Tests.Ef.SqlServer.UnitOfWorks;
using Util.Dependency;
using Util.Helpers;
using Xunit;

namespace Util.Datas.Tests.Dapper.SqlServer {
    /// <summary>
    /// Sql Server查询对象测试
    /// </summary>
    [Collection( "GlobalConfig" )]
    public class SqlQueryTest : IDisposable {
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
        /// 查询对象
        /// </summary>
        private readonly ISqlQuery _query;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public SqlQueryTest() {
            _scope = Ioc.BeginScope();
            _unitOfWork = _scope.Create<ISqlServerUnitOfWork>();
            _customerRepository = _scope.Create<ICustomerRepository>();
            _query = _scope.Create<ISqlQuery>();
        }

        /// <summary>
        /// 测试清理
        /// </summary>
        public void Dispose() {
            _scope.Dispose();
        }

        /// <summary>
        /// 获取单个对象
        /// </summary>
        [Fact]
        public async Task TestToAsync() {
            string id = Id.ObjectId();
            string name = Id.Guid().Substring( 0, 10 );
            var customer = new Customer( id ) { Name = name };
            await _customerRepository.AddAsync( customer );
            await _unitOfWork.CommitAsync();

            var result = await _query.Select<Customer>( t => new object[] { t.Name } )
                .From( "Customers.Customers" )
                .Where( "CustomerId",id )
                .ToAsync<Customer>();
            Assert.Equal( name, result.Name );
        }
    }
}
