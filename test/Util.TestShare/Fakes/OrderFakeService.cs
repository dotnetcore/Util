using System.Collections.Generic;
using System.Linq;
using AutoBogus;
using Util.Tests.Models;

namespace Util.Tests.Fakes {
    /// <summary>
    /// 订单模拟数据服务
    /// </summary>
    public static class OrderFakeService {
        /// <summary>
        /// 获取订单
        /// </summary>
        public static Order GetOrder() {
            return GetOrders( 1 ).First();
        }

        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="count">行数</param>
        public static List<Order> GetOrders( int count ) {
            return new AutoFaker<Order>()
                .Ignore( t => t.OrderItems )
                .RuleFor( t => t.IsDeleted, false )
                .Generate( count );
        }
    }
}