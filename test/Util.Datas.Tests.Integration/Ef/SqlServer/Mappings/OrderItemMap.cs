using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Util.Datas.Tests.Commons.Domains.Models;

namespace Util.Datas.Tests.Ef.SqlServer.Mappings {
    /// <summary>
    /// 订单明细映射配置
    /// </summary>
    public class OrderItemMap : Util.Datas.Ef.SqlServer.EntityMap<OrderItem> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<OrderItem> builder ) {
            builder.ToTable( "OrderItems", "Sales" );
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<OrderItem> builder ) {
            base.MapProperties( builder );
            //订单明细编号
            builder.Property( t => t.Id )
                .HasColumnName( "OrderItemId" );
        }
    }
}
