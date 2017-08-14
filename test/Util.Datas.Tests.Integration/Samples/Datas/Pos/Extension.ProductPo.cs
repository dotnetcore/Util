using Util.Datas.Tests.Samples.Domains.Models;
using Util.Maps;

namespace Util.Datas.Tests.Samples.Datas.Pos {
    /// <summary>
    /// 商品持久化对象扩展
    /// </summary>
    public static partial class Extension {
        /// <summary>
        /// 转换为商品实体
        /// </summary>
        /// <param name="po">商品持久化对象</param>
        public static Product ToEntity( this ProductPo po ) {
            if( po == null )
                return new Product();
            var entity = po.MapTo( new Product( po.Id ) );
            entity.ProductType = Util.Helpers.Json.ToObject<ProductType>( po.Extends );
            return entity;
        }

        /// <summary>
        /// 转换为商品持久化对象
        /// </summary>
        /// <param name="entity">商品实体</param>
        public static ProductPo ToPo( this Product entity ) {
            if( entity == null )
                return new ProductPo();
            var po = entity.MapTo<ProductPo>();
            po.Extends = Util.Helpers.Json.ToJson( entity.ProductType );
            return po;
        }
    }
}
