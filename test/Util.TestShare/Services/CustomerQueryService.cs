using System;
using System.Linq;
using Util.Applications;
using Util.Data;
using Util.Tests.Dtos;
using Util.Tests.Models;
using Util.Tests.Queries;
using Util.Tests.Repositories;

namespace Util.Tests.Services {
    /// <summary>
    /// 客户查询服务
    /// </summary>
    public class CustomerQueryService : QueryServiceBase<Customer,CustomerDto,CustomerQuery,int>,ICustomerQueryService {
        /// <summary>
        /// 初始化客户查询服务
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="repository">客户仓储</param>
        public CustomerQueryService( IServiceProvider serviceProvider,ICustomerRepository repository ) : base( serviceProvider,repository ) {
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