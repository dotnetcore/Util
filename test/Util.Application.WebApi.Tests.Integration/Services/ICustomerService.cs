using Util.Applications.Dtos;
using Util.Applications.Queries;

namespace Util.Applications.Services {
    /// <summary>
    /// 客户服务
    /// </summary>
    public interface ICustomerService : ICrudService<CustomerDto,CustomerQuery> {
    }
}