using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Util.Datas.Tests.Samples.Datas.Pos;

namespace Util.Datas.Tests.Samples.Datas.SqlServer.Mappings {
    /// <summary>
    /// 商品持久化对象映射配置
    /// </summary>
    public class ProductPoMap : Util.Datas.Ef.SqlServer.Map<ProductPo> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<ProductPo> builder ) {
            builder.ToTable( "Products", "Productions" );
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<ProductPo> builder ) {
            base.MapProperties( builder );
            //商品编号
            builder.Property( t => t.Id )
                .HasColumnName( "ProductId" );
        }

        /// <summary>
        /// 映射导航属性
        /// </summary>
        protected override void MapAssociations( EntityTypeBuilder<ProductPo> builder ) {
        }
    }
}
