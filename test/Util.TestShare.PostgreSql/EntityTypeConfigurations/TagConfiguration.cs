using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Util.Tests.Models;

namespace Util.Tests.EntityTypeConfigurations {
    /// <summary>
    /// 标签类型配置
    /// </summary>
    public class TagConfiguration : IEntityTypeConfiguration<Tag> {
        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="builder">实体类型生成器</param>
        public void Configure( EntityTypeBuilder<Tag> builder ) {
            ConfigTable( builder );
            ConfigId( builder );
            ConfigProperties( builder );
        }

        /// <summary>
        /// 配置表
        /// </summary>
        private void ConfigTable( EntityTypeBuilder<Tag> builder ) {
            builder.ToTable( "Tag", "Blogs" ).HasComment( "标签" );
        }

        /// <summary>
        /// 配置标识
        /// </summary>
        private void ConfigId( EntityTypeBuilder<Tag> builder ) {
            builder.Property( t => t.Id )
                .HasColumnName( "TagId" )
                .HasComment( "标签标识" );
        }

        /// <summary>
        /// 配置属性
        /// </summary>
        private void ConfigProperties( EntityTypeBuilder<Tag> builder ) {
            builder.Property( t => t.Name )
                .HasColumnName( "Name" )
                .HasComment( "标签名称" );
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
        }
    }
}