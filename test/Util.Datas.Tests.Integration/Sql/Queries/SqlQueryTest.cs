using System;
using System.Threading.Tasks;
using Util.Datas.Sql;
using Util.Datas.Tests.Commons.Domains.Models;
using Util.Datas.Tests.Commons.Domains.Repositories;
using Util.Datas.Tests.Ef.SqlServer.UnitOfWorks;
using Util.Dependency;
using Util.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Datas.Tests.Sql.Queries {
    /// <summary>
    /// Sql Server查询对象测试
    /// </summary>
    [Collection( "GlobalConfig" )]
    public class SqlQueryTest : IDisposable {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
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
        public SqlQueryTest( ITestOutputHelper output ) {
            _output = output;
            _scope = Ioc.BeginScope();
            _unitOfWork = _scope.Create<ISqlServerUnitOfWork>();
            _customerRepository = _scope.Create<ICustomerRepository>();
            _query = _scope.Create<ISqlQuery>();
            _query.ClearAfterExecution( false );
        }

        /// <summary>
        /// 测试清理
        /// </summary>
        public void Dispose() {
            _scope.Dispose();
        }

        /// <summary>
        /// 获取字符串结果
        /// </summary>
        [Fact]
        public async Task TestToStringAsync() {
            string id = Id.ObjectId();
            string name = Id.Guid().Substring( 0, 10 );
            var customer = new Customer( id ) { Name = name };
            await _customerRepository.AddAsync( customer );
            await _unitOfWork.CommitAsync();

            var result = await _query
                .Select<Customer>( t => t.Name )
                .From<Customer>( "c" )
                .Where<Customer>( t => t.Id == id )
                .ToStringAsync();
            _output.WriteLine( _query.GetDebugSql() );
            Assert.Equal( name, result );
        }

        /// <summary>
        /// 获取分页结果
        /// </summary>
        [Fact]
        public async Task TestToPagerListAsync() {
            string id = Id.ObjectId();
            string name = Id.Guid().Substring( 0, 10 );
            var customer = new Customer( id ) { Name = name };
            await _customerRepository.AddAsync( customer );
            await _unitOfWork.CommitAsync();

            var result = await _query
                .Select<Customer>( t => new object[] { t.Id, t.Name } )
                .From<Customer>( "c" )
                .Where<Customer>( t => t.Id == id )
                .OrderBy<Customer>( t => t.Name )
                .ToPagerListAsync<Customer>(1,20);
            _output.WriteLine( _query.GetDebugSql() );
            Assert.Equal( 1, result.PageCount );
        }
    }
}
