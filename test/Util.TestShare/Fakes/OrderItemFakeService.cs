using System.Collections.Generic;
using System.Linq;
using AutoBogus;
using Util.Tests.Models;

namespace Util.Tests.Fakes {
    /// <summary>
    /// 订单明细模拟数据服务
    /// </summary>
    public static class OrderItemFakeService {
        /// <summary>
        /// 获取订单明细
        /// </summary>
        public static OrderItem GetOrderItem() {
            return GetOrderItems( 1 ).First();
        }

        /// <summary>
        /// 获取订单明细列表
        /// </summary>
        /// <param name="count">行数</param>
        public static List<OrderItem> GetOrderItems( int count ) {
            return new AutoFaker<OrderItem>()
                .Ignore( t => t.Order )
                .Generate( count );
        }
    }
}