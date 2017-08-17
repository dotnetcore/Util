using Util.Helpers.Internal;

namespace Util.Helpers {
    /// <summary>
    /// Id生成器
    /// </summary>
    public static class Id {
        /// <summary>
        /// 创建Id
        /// </summary>
        public static string Create() {
            return ObjectId.GenerateNewStringId();
        }
    }
}
