using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Util.Tests.Models;

namespace Util.Tests.EntityTypeConfigurations {
    /// <summary>
    /// 贴子类型配置
    /// </summary>
    public class PostConfiguration : IEntityTypeConfiguration<Post> {
        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="builder">实体类型生成器</param>
        public void Configure( EntityTypeBuilder<Post> builder ) {
            ConfigTable( builder );
            ConfigId( builder );
            ConfigProperties( builder );
        }

        /// <summary>
        /// 配置表
        /// </summary>
        private void ConfigTable( EntityTypeBuilder<Post> builder ) {
            builder.ToTable( "Post", "Blogs" ).HasComment( "贴子" );
        }

        /// <summary>
        /// 配置标识
        /// </summary>
        private void ConfigId( EntityTypeBuilder<Post> builder ) {
            builder.Property( t => t.Id )
                .HasColumnName( "PostId" )
                .HasComment( "贴子标识" );
        }

        /// <summary>
        /// 配置属性
        /// </summary>
        private void ConfigProperties( EntityTypeBuilder<Post> builder ) {
            builder.Property( t => t.Title )
                .HasColumnName( "Title" )
                .HasComment( "标题" );
            builder.Property( t => t.Content )
                .HasColumnName( "Content" )
                .HasComment( "内容" );
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
            builder.HasMany( t => t.Tags )
                .WithMany( t => t.Posts )
                .UsingEntity( t => t.ToTable( "PostTag2" ) );
        }
    }
}