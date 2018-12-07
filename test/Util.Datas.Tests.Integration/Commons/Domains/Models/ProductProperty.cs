namespace Util.Datas.Tests.Commons.Domains.Models {
    /// <summary>
    /// 商品属性
    /// </summary>
    public class ProductProperty : Util.Domains.ValueObjectBase<ProductProperty> {
        /// <summary>
        /// 初始化商品属性
        /// </summary>
        /// <param name="name">属性名</param>
        /// <param name="value">属性值</param>
        public ProductProperty( string name,string value ) {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// 属性名
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// 属性值
        /// </summary>
        public string Value { get; }
    }
}
