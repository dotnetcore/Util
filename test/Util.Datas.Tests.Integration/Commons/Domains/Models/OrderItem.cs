using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Util.Domains;

namespace Util.Datas.Tests.Commons.Domains.Models {
    /// <summary>
    /// 订单明细
    /// </summary>
    [Description( "订单明细" )]
    public class OrderItem : EntityBase<OrderItem> {
        /// <summary>
        /// 初始化订单明细
        /// </summary>
        public OrderItem() : this( Guid.Empty, null ) {
        }
        /// <summary>
        /// 初始化订单明细
        /// </summary>
        /// <param name="order">订单</param>
        public OrderItem( Order order ) : this( Guid.Empty, order ) {
        }

        /// <summary>
        /// 初始化订单明细
        /// </summary>
        /// <param name="id">订单明细标识</param>
        /// <param name="order">订单</param>
        public OrderItem( Guid id,Order order ) : base( id ) {
            if ( order == null )
                return;
            Order = order;
            OrderId = order.Id;
        }

        /// <summary>
        /// 商品名称
        /// </summary>
        [DisplayName( "商品名称" )]
        [Required( ErrorMessage = "商品名称不能为空" )]
        [StringLength( 200, ErrorMessage = "商品名称输入过长，不能超过200位" )]
        public string ProductName { get; private set; }

        /// <summary>
        /// 数量
        /// </summary>
        [DisplayName( "数量" )]
        [Required( ErrorMessage = "数量不能为空" )]
        public int Quantity { get; private set; }

        /// <summary>
        /// 单价
        /// </summary>
        [DisplayName( "单价" )]
        [Required( ErrorMessage = "单价不能为空" )]
        public decimal Price { get; private set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductId { get; private set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public Guid OrderId { get; private set; }

        /// <summary>
        /// 订单
        /// </summary>
        [ForeignKey( "OrderId" )]
        public Order Order { get; private set; }

        /// <summary>
        /// 订购 
        /// </summary>
        /// <param name="product">商品</param>
        /// <param name="quantity">数量</param>
        public void Booking( Product product, int quantity ) {
            ProductId = product.Id;
            ProductName = product.Name;
            Price = product.Price.SafeValue();
            Quantity = quantity;
        }
    }
}