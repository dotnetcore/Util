using Util.Applications.Dtos;
using Util.Applications.Queries;

namespace Util.Applications.Services {
    /// <summary>
    /// 客户查询服务
    /// </summary>
    public interface ICustomerQueryService : IQueryService<CustomerDto,CustomerQuery> {
    }
}