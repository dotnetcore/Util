using Util.Domain.Repositories;
using Util.Tests.Models;

namespace Util.Tests.Repositories {
    /// <summary>
    /// 客户仓储
    /// </summary>
    public interface ICustomerRepository : IRepository<Customer,int> {
    }
}