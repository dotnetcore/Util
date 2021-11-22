using Util.Data.EntityFrameworkCore.Models;
using Util.Domain.Repositories;

namespace Util.Data.EntityFrameworkCore.Repositories {
    /// <summary>
    /// 订单仓储
    /// </summary>
    public interface IOrderRepository : IRepository<Order,string> {
    }
}