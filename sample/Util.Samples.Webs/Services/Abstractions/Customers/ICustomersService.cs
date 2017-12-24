using Util.Applications;
using Donau.Services.Queries.Customers;
using Donau.Services.Dtos.Customers;

namespace Donau.Services.Abstractions.Customers {
    /// <summary>
    /// 客户服务
    /// </summary>
    public interface ICustomersService : ICrudService<CustomersDto, CustomersQuery> {
    }
}