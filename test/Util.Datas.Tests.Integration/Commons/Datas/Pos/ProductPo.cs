using Util.Datas.Persistence;
using Util.Domains;

namespace Util.Datas.Tests.Commons.Datas.Pos {
    /// <summary>
    /// 商品持久化对象
    /// </summary>
    public class ProductPo : PersistentObjectBase<int>, IDelete {
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
        /// <summary>
        /// 价格
        /// </summary>  
        public decimal? Price { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>  
        public bool IsDeleted { get; set; }
    }
}