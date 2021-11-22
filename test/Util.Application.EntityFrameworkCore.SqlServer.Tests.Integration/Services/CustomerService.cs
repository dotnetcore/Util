using System;
using System.Linq;
using Util.Applications.Dtos;
using Util.Applications.Models;
using Util.Applications.Queries;
using Util.Applications.Repositories;
using Util.Applications.UnitOfWorks;

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
    }
}