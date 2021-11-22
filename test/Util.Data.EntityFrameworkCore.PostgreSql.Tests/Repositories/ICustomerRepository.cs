using Util.Data.EntityFrameworkCore.Models;
using Util.Domain.Repositories;

namespace Util.Data.EntityFrameworkCore.Repositories {
    /// <summary>
    /// 客户仓储
    /// </summary>
    public interface ICustomerRepository : IRepository<Customer,int> {
    }
}