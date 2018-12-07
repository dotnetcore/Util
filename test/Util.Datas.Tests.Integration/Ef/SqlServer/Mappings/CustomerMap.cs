using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Util.Datas.Tests.Commons.Domains.Models;

namespace Util.Datas.Tests.Ef.SqlServer.Mappings {
    /// <summary>
    /// 客户映射配置
    /// </summary>
    public class CustomerMap : Util.Datas.Ef.SqlServer.AggregateRootMap<Customer> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<Customer> builder ) {
            builder.ToTable( "Customers", "Customers" );
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<Customer> builder ) {
            base.MapProperties( builder );
            //客户编号
            builder.Property( t => t.Id )
                .HasColumnName( "CustomerId" );
        }
    }
}
