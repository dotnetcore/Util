using System;

namespace Util.Datas.Tests.Samples {
    /// <summary>
    /// 订单 - Guid标识
    /// </summary>
    public class Order : Util.Domains.AggregateRoot<Order> {
        /// <summary>
        /// 初始化订单
        /// </summary>
        public Order() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化订单
        /// </summary>
        /// <param name="id">标识</param>
        public Order( Guid id ) : base( id ) {
        }

        /// <summary>
        /// 订单编码
        /// </summary>
        public string Code { get; set; }
    }
}
