using Util.Domain.Repositories;
using Util.Tests.Models;

namespace Util.Tests.Repositories {
    /// <summary>
    /// 订单仓储
    /// </summary>
    public interface IOrderRepository : IRepository<Order,string> {
    }
}