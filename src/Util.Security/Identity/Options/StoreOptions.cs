namespace Util.Security.Identity.Options {
    /// <summary>
    /// 存储配置
    /// </summary>
    public class StoreOptions {
        /// <summary>
        /// 键最大长度
        /// </summary>
        public int MaxLengthForKeys { get; set; }
        /// <summary>
        /// 加密存储标记为[ProtectedPersonalData]的用户数据，默认不启用
        /// </summary>
        public bool ProtectPersonalData { get; set; }
        /// <summary>
        /// 存储原始密码，默认不启用
        /// </summary>
        public bool StoreOriginalPassword { get; set; }
    }
}
