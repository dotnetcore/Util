using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Util.Tests.Models;

namespace Util.Tests.EntityTypeConfigurations {
    /// <summary>
    /// 订单明细类型配置
    /// </summary>
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem> {
        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="builder">实体类型生成器</param>
        public void Configure( EntityTypeBuilder<OrderItem> builder ) {
            ConfigTable( builder );
            ConfigId( builder );
            ConfigProperties( builder );
            ConfigAssociations( builder );
        }

        /// <summary>
        /// 配置表
        /// </summary>
        private void ConfigTable( EntityTypeBuilder<OrderItem> builder ) {
            builder.ToTable( "OrderItem", "Sales" ).HasComment( "订单明细" );
        }

        /// <summary>
        /// 配置标识
        /// </summary>
        private void ConfigId( EntityTypeBuilder<OrderItem> builder ) {
            builder.Property( t => t.Id )
                .HasColumnName( "OrderItemId" )
                .HasComment( "订单明细标识" );
        }

        /// <summary>
        /// 配置属性
        /// </summary>
        private void ConfigProperties( EntityTypeBuilder<OrderItem> builder ) {
            builder.Property( t => t.OrderId )
                .HasColumnName( "OrderId" )
                .HasMaxLength( 50 )
                .HasComment( "订单标识" );
            builder.Property( t => t.ProductId )
                .HasColumnName( "ProductId" )
                .HasComment( "产品标识" );
            builder.Property( t => t.ProductName )
                .HasColumnName( "ProductName" )
                .HasComment( "产品名称" );
            builder.Property( t => t.Price )
                .HasColumnName( "Price" )
                .HasComment( "单价" )
                .HasPrecision(12,2);
            builder.Property( t => t.Quantity )
                .HasColumnName( "Quantity" )
                .HasComment( "数量" )
                .HasDefaultValue(1);
        }

        /// <summary>
        /// 映射导航属性
        /// </summary>
        private void ConfigAssociations( EntityTypeBuilder<OrderItem> builder ) {
            builder.HasOne( t => t.Order )
                .WithMany( t => t.OrderItems )
                .HasForeignKey(  t => t.OrderId );
        }
    }
}