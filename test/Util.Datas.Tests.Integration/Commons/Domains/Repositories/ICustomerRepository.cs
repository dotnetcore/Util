using Util.Datas.Tests.Commons.Domains.Models;
using Util.Domains.Repositories;

namespace Util.Datas.Tests.Commons.Domains.Repositories {
    /// <summary>
    /// 客户仓储
    /// </summary>
    public interface ICustomerRepository : IRepository<Customer,string> {
    }
}
