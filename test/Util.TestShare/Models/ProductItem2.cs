
namespace Util.Tests.Models {
    /// <summary>
    /// 用于测试不可变扩展属性
    /// </summary>
    public class ProductItem2 {

        public ProductItem2() {
        }

        public ProductItem2( int code, string name ) {
            Code = code;
            Name = name;
        }

        /// <summary>
        /// 编码
        /// </summary>
        public int Code { get; init; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; init; }
    }
}
