using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util.Domains;

namespace Util.Datas.Tests.Samples.Domains.Models {
    /// <summary>
    /// 订单
    /// </summary>
    [Description( "订单" )]
    public class Order : AggregateRoot<Order> {
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
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            AddDescription( "订单编号", Id );
            AddDescription( "订单编码", Code );
            AddDescription( "订单名称", Name );
        }

        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( Order other ) {
            AddChange( t => t.Id, other.Id );
            AddChange( t => t.Code, other.Code );
            AddChange( t => t.Name, other.Name );
        }
    }
}