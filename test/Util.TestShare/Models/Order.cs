using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util.Domain;
using Util.Domain.Entities;

namespace Util.Tests.Models {
    /// <summary>
    /// 订单
    /// </summary>
    [Description( "订单" )]
    public class Order : AggregateRoot<Order, string>, IDelete {
        /// <summary>
        /// 初始化订单
        /// </summary>
        public Order() : this( string.Empty ) {
        }

        /// <summary>
        /// 初始化订单
        /// </summary>
        /// <param name="id">订单标识</param>
        public Order( string id ) : base( id ) {
            OrderItems = new List<OrderItem>();
        }

        /// <summary>
        /// 客户标识
        ///</summary>
        [Description( "客户标识" )]
        public int? CustomerId { get; set; }
        /// <summary>
        /// 客户名称
        ///</summary>
        [Description( "客户名称" )]
        [MaxLength( 200 )]
        public string CustomerName { get; set; }
        /// <summary>
        /// 金额
        ///</summary>
        [Description( "金额" )]
        [Required( ErrorMessage = "金额不能为空" )]
        public decimal Amount { get; set; }
        /// <summary>
        /// 下单时间
        ///</summary>
        [Description( "下单时间" )]
        [Required( ErrorMessage = "下单时间不能为空" )]
        public DateTime PlaceOrderTime { get; set; }
        /// <summary>
        /// 订单状态
        ///</summary>
        [Description( "订单状态" )]
        [Required( ErrorMessage = "订单状态不能为空" )]
        public int State { get; set; }
        /// <summary>
        /// 是否删除
        ///</summary>
        [Description( "是否删除" )]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 订单项列表
        /// </summary>
        public ICollection<OrderItem> OrderItems { get; set; }

        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( Order other ) {
            AddChange( t => t.CustomerId, other.CustomerId );
            AddChange( t => t.CustomerName, other.CustomerName );
            AddChange( t => t.Amount, other.Amount );
            AddChange( t => t.PlaceOrderTime, other.PlaceOrderTime );
            AddChange( t => t.State, other.State );
        }
    }
}