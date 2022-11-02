using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Util.Tests.Models;

namespace Util.Tests.EntityTypeConfigurations {
    /// <summary>
    /// 资源类型配置
    /// </summary>
    public class ResourceConfiguration : IEntityTypeConfiguration<Resource> {
        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="builder">实体类型生成器</param>
        public void Configure( EntityTypeBuilder<Resource> builder ) {
            ConfigTable( builder );
            ConfigId( builder );
            ConfigProperties( builder );
        }

        /// <summary>
        /// 配置表
        /// </summary>
        private void ConfigTable( EntityTypeBuilder<Resource> builder ) {
            builder.ToTable( "Resource", "Permissions" ).HasComment( "资源" );
        }

        /// <summary>
        /// 配置标识
        /// </summary>
        private void ConfigId( EntityTypeBuilder<Resource> builder ) {
            builder.Property( t => t.Id )
                .HasColumnName( "ResourceId" )
                .HasComment( "资源标识" );
        }

        /// <summary>
        /// 配置属性
        /// </summary>
        private void ConfigProperties( EntityTypeBuilder<Resource> builder ) {
            builder.Property( t => t.Uri )
                .HasColumnName( "Uri" )
                .HasComment( "资源标识符" );
            builder.Property( t => t.Name )
                .HasColumnName( "Name" )
                .HasComment( "资源名称" );
            builder.Property( t => t.ParentId )
                .HasColumnName( "ParentId" )
                .HasComment( "父标识" );
            builder.Property( t => t.Path )
                .HasColumnName( "Path" )
                .HasComment( "路径" );
            builder.Property( t => t.Level )
                .HasColumnName( "Level" )
                .HasComment( "层级" );
            builder.Property( t => t.Remark )
                .HasColumnName( "Remark" )
                .HasComment( "备注" );
            builder.Property( t => t.Enabled )
                .HasColumnName( "Enabled" )
                .HasComment( "启用" );
            builder.Property( t => t.SortId )
                .HasColumnName( "SortId" )
                .HasComment( "排序号" );
            builder.Property( t => t.CreationTime )
                .HasColumnName( "CreationTime" )
                .HasComment( "创建时间" );
            builder.Property( t => t.CreatorId )
                .HasColumnName( "CreatorId" )
                .HasComment( "创建人标识" );
            builder.Property( t => t.LastModificationTime )
                .HasColumnName( "LastModificationTime" )
                .HasComment( "最后修改时间" );
            builder.Property( t => t.LastModifierId )
                .HasColumnName( "LastModifierId" )
                .HasComment( "最后修改人标识" );
        }
    }
}