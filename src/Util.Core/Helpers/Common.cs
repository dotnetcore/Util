using System;

namespace Util.Helpers {
    /// <summary>
    /// 公共操作
    /// </summary>
    public static class Common {
        /// <summary>
        /// 换行符
        /// </summary>
        public static string Line => System.Environment.NewLine;

        /// <summary>
        /// 获取类型
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        public static Type GetType<T>() {
            return GetType( typeof( T ) );
        }

        /// <summary>
        /// 获取类型
        /// </summary>
        /// <param name="type">类型</param>
        public static Type GetType( Type type ) {
            return Nullable.GetUnderlyingType( type ) ?? type;
        }
    }
}
