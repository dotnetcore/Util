using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Util.Tests.Configs;
using Util.Tests.Models;

namespace Util.Tests.EntityTypeConfigurations {
    /// <summary>
    /// 订单类型配置
    /// </summary>
    public class OrderConfiguration : IEntityTypeConfiguration<Order> {
        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="builder">实体类型生成器</param>
        public void Configure( EntityTypeBuilder<Order> builder ) {
            ConfigTable( builder );
            ConfigId( builder );
            ConfigProperties( builder );
        }

        /// <summary>
        /// 配置表
        /// </summary>
        private void ConfigTable( EntityTypeBuilder<Order> builder ) {
            builder.ToTable( "Order", "Sales",t => t.HasComment( "订单" ) );
        }

        /// <summary>
        /// 配置标识
        /// </summary>
        private void ConfigId( EntityTypeBuilder<Order> builder ) {
            builder.Property( t => t.Id )
                .HasMaxLength( 50 )
                .HasColumnName( "OrderId" )
                .HasComment( "订单标识" );
        }

        /// <summary>
        /// 配置属性
        /// </summary>
        private void ConfigProperties( EntityTypeBuilder<Order> builder ) {
            builder.Property( t => t.CustomerId )
                .HasColumnName( "CustomerId" )
                .HasComment( "客户标识" );
            builder.Property( t => t.CustomerName )
                .HasColumnName( "CustomerName" )
                .HasComment( "客户名称" );
            builder.Property( t => t.Amount )
                .HasColumnName( "Amount" )
                .HasComment( "金额" )
                .HasPrecision(15,2)
                .HasDefaultValue( 0 );
            builder.Property( t => t.PlaceOrderTime )
                .HasColumnName( "PlaceOrderTime" )
                .HasComment( "下单时间" );
            builder.Property( t => t.State )
                .HasColumnName( "State" )
                .HasComment( "订单状态" )
                .HasDefaultValue( 0 );
            builder.Property( t => t.IsDeleted )
                .HasDefaultValue( false );
        }
    }
}