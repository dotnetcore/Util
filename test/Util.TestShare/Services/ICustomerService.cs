using Util.Applications;
using Util.Tests.Dtos;
using Util.Tests.Queries;

namespace Util.Tests.Services {
    /// <summary>
    /// 客户服务
    /// </summary>
    public interface ICustomerService : ICrudService<CustomerDto,CustomerQuery> {
    }
}