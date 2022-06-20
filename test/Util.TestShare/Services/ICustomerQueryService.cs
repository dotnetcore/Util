using Util.Applications;
using Util.Tests.Dtos;
using Util.Tests.Queries;

namespace Util.Tests.Services {
    /// <summary>
    /// 客户查询服务
    /// </summary>
    public interface ICustomerQueryService : IQueryService<CustomerDto,CustomerQuery> {
    }
}