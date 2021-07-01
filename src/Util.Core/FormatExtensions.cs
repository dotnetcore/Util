using Util.Properties;

namespace Util {
    /// <summary>
    /// 格式化扩展
    /// </summary>
    public static class FormatExtensions {
        /// <summary>
        /// 获取描述
        /// </summary>
        /// <param name="value">布尔值</param>
        public static string Description( this bool value ) {
            return value ? R.Yes : R.No;
        }

        /// <summary>
        /// 获取描述
        /// </summary>
        /// <param name="value">布尔值</param>
        public static string Description( this bool? value ) {
            return value == null ? "" : Description( value.Value );
        }
    }
}
