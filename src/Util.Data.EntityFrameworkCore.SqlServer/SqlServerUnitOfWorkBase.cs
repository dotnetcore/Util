using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Util.Domain;

namespace Util.Data.EntityFrameworkCore {
    /// <summary>
    /// SqlServer工作单元基类
    /// </summary>
    public abstract class SqlServerUnitOfWorkBase : UnitOfWorkBase {
        /// <summary>
        /// 初始化SqlServer工作单元
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="options">配置</param>
        protected SqlServerUnitOfWorkBase( IServiceProvider serviceProvider,DbContextOptions options )
            : base( serviceProvider, options ) {
        }

        /// <summary>
        /// 配置乐观锁
        /// </summary>
        /// <param name="modelBuilder">模型生成器</param>
        /// <param name="entityType">实体类型</param>
        protected override void ApplyVersion( ModelBuilder modelBuilder, IMutableEntityType entityType ) {
            if( typeof( IVersion ).IsAssignableFrom( entityType.ClrType ) == false )
                return;
            modelBuilder.Entity( entityType.ClrType )
                .Property( "Version" )
                .HasColumnName( "Version" )
                .IsRowVersion();
        }

        /// <summary>
        /// 获取版本号
        /// </summary>
        protected override byte[] GetVersion() {
            return null;
        }
    }
}
