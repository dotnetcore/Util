using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Util.Datas.Tests.Commons.Domains.Models;

namespace Util.Datas.Tests.Ef.SqlServer.Mappings {
    /// <summary>
    /// 订单映射配置
    /// </summary>
    public class OrderMap : Util.Datas.Ef.SqlServer.AggregateRootMap<Order> {
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
            //订单编号
            builder.Property( t => t.Id )
                .HasColumnName( "OrderId" );
        }
    }
}
