using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Util.Tests.Models;

namespace Util.Tests.EntityTypeConfigurations {
    /// <summary>
    /// 操作日志类型配置
    /// </summary>
    public class OperationLogConfiguration : IEntityTypeConfiguration<OperationLog> {
        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="builder">实体类型生成器</param>
        public void Configure( EntityTypeBuilder<OperationLog> builder ) {
            ConfigTable( builder );
            ConfigId( builder );
            ConfigProperties( builder );
        }

        /// <summary>
        /// 配置表
        /// </summary>
        private void ConfigTable( EntityTypeBuilder<OperationLog> builder ) {
            builder.ToTable( "OperationLog", "Systems" ).HasComment( "操作日志" );
        }

        /// <summary>
        /// 配置标识
        /// </summary>
        private void ConfigId( EntityTypeBuilder<OperationLog> builder ) {
            builder.Property( t => t.Id )
                .HasColumnName( "LogId" )
                .HasComment( "操作标识" )
                .ValueGeneratedOnAdd();
        }

        /// <summary>
        /// 配置属性
        /// </summary>
        private void ConfigProperties( EntityTypeBuilder<OperationLog> builder ) {
            builder.Property( t => t.LogName )
                .HasColumnName( "LogName" )
                .HasComment( "日志名称" );
            builder.Property( t => t.OperationTime )
                .HasColumnName( "OperationTime" )
                .HasComment( "操作时间" );
            builder.Property( t => t.Caption )
                .HasColumnName( "Caption" )
                .HasComment( "标题" );
            builder.Property( t => t.Content )
                .HasColumnName( "Content" )
                .HasComment( "内容" );
        }
    }
}