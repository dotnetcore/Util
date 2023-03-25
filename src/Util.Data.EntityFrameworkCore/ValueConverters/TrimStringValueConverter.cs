using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Util.Data.EntityFrameworkCore.ValueConverters {
    /// <summary>
    /// 字符串值转换器,用于清除两端空白
    /// </summary>
    public class TrimStringValueConverter : ValueConverter<string, string> {
        /// <summary>
        /// 初始化字符串值转换器
        /// </summary>
        public TrimStringValueConverter()
            : base( value => value.SafeString(), value => value ) {
        }
    }
}