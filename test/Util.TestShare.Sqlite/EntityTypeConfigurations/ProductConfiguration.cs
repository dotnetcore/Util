using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Util.Tests.Configs;
using Util.Tests.Models;

namespace Util.Tests.EntityTypeConfigurations {
    /// <summary>
    /// 产品类型配置
    /// </summary>
    public class ProductConfiguration : IEntityTypeConfiguration<Product> {
        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="builder">实体类型生成器</param>
        public void Configure( EntityTypeBuilder<Product> builder ) {
            ConfigTable( builder );
            ConfigId( builder );
            ConfigProperties( builder );
            InitData( builder );
        }

        /// <summary>
        /// 配置表
        /// </summary>
        private void ConfigTable( EntityTypeBuilder<Product> builder ) {
            builder.ToTable( "Product" ).HasComment( "产品" );
        }

        /// <summary>
        /// 配置标识
        /// </summary>
        private void ConfigId( EntityTypeBuilder<Product> builder ) {
            builder.Property( t => t.Id )
                .HasColumnName( "ProductId" )
                .HasComment( "产品标识" );
        }

        /// <summary>
        /// 配置属性
        /// </summary>
        private void ConfigProperties( EntityTypeBuilder<Product> builder ) {
            builder.Property( t => t.Code )
                .HasColumnName( "Code" )
                .HasComment( "产品编码" );
            builder.Property( t => t.Name )
                .HasColumnName( "Name" )
                .HasComment( "产品名称" );
            builder.Property( t => t.Price )
                .HasColumnName( "Price" )
                .HasComment( "价格" )
                .HasDefaultValue( 0 )
                .HasPrecision( 12, 2 );
            builder.Property( t => t.IntPrice )
                .HasColumnName( "IntPrice" )
                .HasComment( "价格" )
                .HasDefaultValue( 0 );
            builder.Property( t => t.LongPrice )
                .HasColumnName( "LongPrice" )
                .HasComment( "价格" )
                .HasDefaultValue( 0 );
            builder.Property( t => t.FloatPrice )
                .HasColumnName( "FloatPrice" )
                .HasComment( "价格" )
                .HasDefaultValue( 0 );
            builder.Property( t => t.Description )
                .HasColumnName( "Description" )
                .HasComment( "描述" );
            builder.Property( t => t.Enabled )
                .HasColumnName( "Enabled" )
                .HasDefaultValue( TestConfig.BoolValue )
                .HasComment( "启用" );
            builder.Property( t => t.CreationTime )
                .HasColumnName( "CreationTime" )
                .HasComment( "创建时间" );
            builder.Property( t => t.CreatorId )
                .HasColumnName( "CreatorId" )
                .HasComment( "创建人" );
            builder.Property( t => t.LastModificationTime )
                .HasColumnName( "LastModificationTime" )
                .HasComment( "最后修改时间" );
            builder.Property( t => t.LastModifierId )
                .HasColumnName( "LastModifierId" )
                .HasComment( "最后修改人" );
            builder.Property( t => t.IsDeleted )
                .HasDefaultValue( false );
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData( EntityTypeBuilder<Product> builder ) {
            var product = new Product( TestConfig.Id ) {
                Code = TestConfig.Value,
                Price = TestConfig.DecimalValue,
                IntPrice = TestConfig.IntValue,
                LongPrice = TestConfig.LongValue,
                FloatPrice = TestConfig.FloatValue
            };
            builder.HasData( product );
        }
    }
}