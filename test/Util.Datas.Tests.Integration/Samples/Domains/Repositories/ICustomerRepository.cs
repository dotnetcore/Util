using Util.Datas.Tests.Samples.Domains.Models;
using Util.Domains.Repositories;

namespace Util.Datas.Tests.Samples.Domains.Repositories {
    /// <summary>
    /// 客户仓储
    /// </summary>
    public interface ICustomerRepository : IRepository<Customer,string> {
    }
}
