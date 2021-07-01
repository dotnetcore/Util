using System;

namespace Util.Helpers {
    /// <summary>
    /// 标识生成器
    /// </summary>
    public static class Id {
        /// <summary>
        /// 标识
        /// </summary>
        private static string _id;

        /// <summary>
        /// 设置标识
        /// </summary>
        /// <param name="id">Id</param>
        public static void SetId( string id ) {
            _id = id;
        }

        /// <summary>
        /// 重置标识
        /// </summary>
        public static void Reset() {
            _id = null;
        }

        /// <summary>
        /// 使用去掉分隔符的Guid创建标识
        /// </summary>
        public static string Create() {
            return string.IsNullOrWhiteSpace( _id ) ? System.Guid.NewGuid().ToString( "N" ) : _id;
        }

        /// <summary>
        /// 创建Guid标识
        /// </summary>
        public static Guid CreateGuid() {
            return string.IsNullOrWhiteSpace( _id ) ? System.Guid.NewGuid() : _id.ToGuid();
        }
    }
}
