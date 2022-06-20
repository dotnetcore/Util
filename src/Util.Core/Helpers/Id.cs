using System;
using System.Threading;

namespace Util.Helpers {
    /// <summary>
    /// 标识生成器
    /// </summary>
    public static class Id {
        /// <summary>
        /// 标识
        /// </summary>
        private static readonly AsyncLocal<string> _id = new();

        /// <summary>
        /// 设置标识
        /// </summary>
        /// <param name="id">标识</param>
        public static void SetId( string id ) {
            _id.Value = id;
        }

        /// <summary>
        /// 重置标识
        /// </summary>
        public static void Reset() {
            _id.Value = null;
        }

        /// <summary>
        /// 使用去掉分隔符的Guid创建标识
        /// </summary>
        public static string Create() {
            return string.IsNullOrEmpty( _id.Value ) ? System.Guid.NewGuid().ToString( "N" ) : _id.Value;
        }

        /// <summary>
        /// 创建Guid标识
        /// </summary>
        public static Guid CreateGuid() {
            return string.IsNullOrEmpty( _id.Value ) ? System.Guid.NewGuid() : _id.Value.ToGuid();
        }
    }
}
