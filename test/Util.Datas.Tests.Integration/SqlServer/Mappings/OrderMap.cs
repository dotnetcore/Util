using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Util.Datas.Tests.Samples;

namespace Util.Datas.Tests.SqlServer.Mappings {
    /// <summary>
    /// 订单映射 - SqlServer
    /// </summary>
    public class OrderMap : Util.Datas.Ef.SqlServer.AggregateRootMapBase<Order> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<Order> builder ) {
            builder.ToTable( "Orders", "Sales" );
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<Order> builder ) {
            base.MapProperties( builder );
            builder.Property( t => t.Id ).HasColumnName( "OrderId" );
        }
    }
}
