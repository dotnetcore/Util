using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Util.Samples.Domain.Models;

namespace Util.Samples.Data.Mappings.Systems.Oracle {
    /// <summary>
    /// 角色映射配置
    /// </summary>
    public class RoleMap : Util.Datas.Ef.Oracle.AggregateRootMap<Role> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<Role> builder ) {
            builder.ToTable( "Role", "Systems" );
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<Role> builder ) {
            builder.Property( t => t.Id ).HasColumnName( "RoleId" );
            builder.Property( t => t.Path ).HasColumnName( "Path" );
            builder.Property( t => t.Level ).HasColumnName( "Level" );
            builder.Property( t => t.IsAdmin ).HasColumnName( "IsAdmin" );
            builder.HasQueryFilter( t => t.IsDeleted == false );
        }
    }
}
