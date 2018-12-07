using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util.Domains;

namespace Util.Datas.Tests.Commons.Domains.Models {
    /// <summary>
    /// 订单
    /// </summary>
    [Description( "订单" )]
    public class Order : AggregateRoot<Order> {
        /// <summary>
        /// 订单明细列表
        /// </summary>
        private readonly List<OrderItem> _items;

        /// <summary>
        /// 初始化订单
        /// </summary>
        public Order() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化订单
        /// </summary>
        /// <param name="id">订单标识</param>
        public Order( Guid id ) : base( id ) {
            _items = new List<OrderItem>();
        }

        /// <summary>
        /// 订单编码
        /// </summary>
        [Required( ErrorMessage = "订单编码不能为空" )]
        [StringLength( 30, ErrorMessage = "订单编码输入过长，不能超过30位" )]
        public string Code { get; set; }
        /// <summary>
        /// 订单名称
        /// </summary>
        [Required( ErrorMessage = "订单名称不能为空" )]
        [StringLength( 200, ErrorMessage = "订单名称输入过长，不能超过200位" )]
        public string Name { get; set; }

        /// <summary>
        /// 订单明细列表
        /// </summary>
        public IReadOnlyCollection<OrderItem> Items => _items;

        /// <summary>
        /// 添加订单明细
        /// </summary>
        /// <param name="product">商品</param>
        /// <param name="quantity">数量</param>
        public void AddItem( Product product, int quantity ) {
            var item = new OrderItem( Guid.NewGuid(), this );
            item.Booking( product, quantity );
            _items.Add( item );
        }

        /// <summary>
        /// 移除订单明细
        /// </summary>
        /// <param name="itemId">订单明细编号</param>
        public void RemoveItem( Guid itemId ) {
            _items.Remove( FindItem( itemId ) );
        }

        /// <summary>
        /// 查找订单明细
        /// </summary>
        /// <param name="itemId">订单明细编号</param>
        public OrderItem FindItem( Guid itemId ) {
            return _items.Find( t => t.Id == itemId );
        }
    }
}