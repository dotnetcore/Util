using System.Collections.Generic;

namespace Util.Datas.Tests.Commons.Domains.Models {
    /// <summary>
    /// 商品类型
    /// </summary>
    public class ProductType : Util.Domains.ValueObjectBase<ProductType> {
        /// <summary>
        /// 商品属性集合
        /// </summary>
        private readonly List<ProductProperty> _properties;

        /// <summary>
        /// 初始化商品类型
        /// </summary>
        /// <param name="name">商品类型名称</param>
        /// <param name="properties">商品属性集合</param>
        public ProductType( string name,List<ProductProperty> properties ) {
            Name = name;
            _properties = properties;
        }

        /// <summary>
        /// 商品类型名称
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 商品属性集合
        /// </summary>
        public IReadOnlyCollection<ProductProperty> Properties => _properties?.AsReadOnly();
    }
}
