namespace Util {
    /// <summary>
    /// 系统扩展 - 格式化
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 获取描述
        /// </summary>
        /// <param name="value">布尔值</param>
        public static string Description( this bool value ) {
            return value ? "是" : "否";
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
