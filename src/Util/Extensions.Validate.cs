using System;

namespace Util {
    /// <summary>
    /// 系统扩展 - 验证
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="value">值</param>
        public static bool IsEmpty( this string value ) {
            return string.IsNullOrWhiteSpace( value );
        }

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="value">值</param>
        public static bool IsEmpty( this Guid value ) {
            return value == Guid.Empty;
        }

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="value">值</param>
        public static bool IsEmpty( this Guid? value ) {
            if ( value == null )
                return true;
            return value == Guid.Empty;
        }
    }
}
