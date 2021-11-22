using System;
using System.Linq;
using Util.Applications.Dtos;
using Util.Applications.Models;
using Util.Applications.Queries;
using Util.Applications.Repositories;
using Util.Applications.UnitOfWorks;
using Util.Data;

namespace Util.Applications.Services {
    /// <summary>
    /// 客户服务
    /// </summary>
    public class CustomerService : CrudServiceBase<Customer,CustomerDto,CustomerQuery,int>, ICustomerService {
        /// <summary>
        /// 初始化客户服务
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="repository">仓储</param>
        public CustomerService( IServiceProvider serviceProvider,ISqlServerUnitOfWork unitOfWork, ICustomerRepository repository ) : base( serviceProvider,unitOfWork, repository ) {
        }

        /// <summary>
        /// 过滤
        /// </summary>
        /// <param name="queryable">查询对象</param>
        /// <param name="query">查询参数</param>
        protected override IQueryable<Customer> Filter( IQueryable<Customer> queryable, CustomerQuery query ) {
            return queryable.WhereIfNotEmpty( t => t.Name == query.Name );
        }
    }
}