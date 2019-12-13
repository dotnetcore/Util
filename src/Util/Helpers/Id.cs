using System;

namespace Util.Helpers {
    /// <summary>
    /// 标识生成器
    /// </summary>
    public static partial class Id {
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
        /// 创建标识
        /// </summary>
        public static string ObjectId() {
            return string.IsNullOrWhiteSpace( _id ) ? Util.Helpers.Internal.ObjectId.GenerateNewStringId() : _id;
        }

        /// <summary>
        /// 用Guid创建标识,去掉分隔符
        /// </summary>
        public static string Guid() {
            return string.IsNullOrWhiteSpace( _id ) ? System.Guid.NewGuid().ToString( "N" ) : _id;
        }

        /// <summary>
        /// 获取Guid
        /// </summary>
        public static Guid GetGuid() {
            return string.IsNullOrWhiteSpace( _id ) ? System.Guid.NewGuid() : _id.ToGuid();
        }
    }
}
