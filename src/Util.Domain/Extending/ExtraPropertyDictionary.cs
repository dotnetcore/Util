using System.Collections.Generic;

namespace Util.Domain.Extending {
    /// <summary>
    /// 扩展属性字典
    /// </summary>
    public class ExtraPropertyDictionary : Dictionary<string, object> {
        /// <summary>
        /// 初始化扩展属性字典
        /// </summary>
        public ExtraPropertyDictionary() {
        }

        /// <summary>
        /// 初始化扩展属性字典
        /// </summary>
        /// <param name="dictionary">字典</param>
        public ExtraPropertyDictionary( IDictionary<string, object> dictionary ) : base( dictionary ) {
        }

        /// <summary>
        /// 是否清除字符串两端的空白,默认为true
        /// </summary>
        public bool IsTrimString { get; set; } = true;
    }
}
