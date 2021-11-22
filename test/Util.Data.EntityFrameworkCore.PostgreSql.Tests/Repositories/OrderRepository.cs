using Util.Data.EntityFrameworkCore.Models;
using Util.Data.EntityFrameworkCore.UnitOfWorks;

namespace Util.Data.EntityFrameworkCore.Repositories {
    /// <summary>
    /// 订单仓储
    /// </summary>
    public class OrderRepository : RepositoryBase<Order,string>,IOrderRepository {
        /// <summary>
        /// 初始化订单仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public OrderRepository( IPgSqlUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}