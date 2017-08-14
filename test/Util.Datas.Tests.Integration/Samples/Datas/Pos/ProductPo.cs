using Util.Datas.Persistence;

namespace Util.Datas.Tests.Samples.Datas.Pos {
    /// <summary>
    /// 商品持久化对象
    /// </summary>
    public class ProductPo : PersistentObjectBase<int> {
        /// <summary>
        /// 商品编码
        /// </summary>  
        public string Code { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>  
        public string Name { get; set; }
        /// <summary>
        /// 扩展属性
        /// </summary>  
        public string Extends { get; set; }
    }
}