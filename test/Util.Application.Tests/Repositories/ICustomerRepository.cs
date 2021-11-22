using Util.Applications.Models;
using Util.Domain.Repositories;

namespace Util.Applications.Repositories {
    /// <summary>
    /// 客户仓储
    /// </summary>
    public interface ICustomerRepository : IRepository<Customer,int> {
    }
}