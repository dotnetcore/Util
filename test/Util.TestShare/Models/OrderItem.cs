using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util.Domain.Entities;

namespace Util.Tests.Models {
    /// <summary>
    /// 订单明细
    /// </summary>
    [Description( "订单明细" )]
    public class OrderItem : EntityBase<OrderItem> {
        /// <summary>
        /// 初始化订单明细
        /// </summary>
        public OrderItem() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化订单明细
        /// </summary>
        /// <param name="id">订单明细标识</param>
        public OrderItem( Guid id ) : base( id ) {
        }

        /// <summary>
        /// 订单标识
        ///</summary>
        [Description( "订单标识" )]
        [Required( ErrorMessage = "订单标识不能为空" )]
        [MaxLength( 256 )]
        public string OrderId { get; set; }
        /// <summary>
        /// 产品标识
        ///</summary>
        [Description( "产品标识" )]
        public Guid? ProductId { get; set; }
        /// <summary>
        /// 产品名称
        ///</summary>
        [Description( "产品名称" )]
        [MaxLength( 500 )]
        public string ProductName { get; set; }
        /// <summary>
        /// 单价
        ///</summary>
        [Description( "单价" )]
        public decimal Price { get; set; }
        /// <summary>
        /// 数量
        ///</summary>
        [Description( "数量" )]
        public int Quantity { get; set; }

        /// <summary>
        /// 订单
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( OrderItem other ) {
            AddChange( t => t.OrderId, other.OrderId );
            AddChange( t => t.ProductId, other.ProductId );
            AddChange( t => t.ProductName, other.ProductName );
            AddChange( t => t.Price, other.Price );
            AddChange( t => t.Quantity, other.Quantity );
        }
    }
}