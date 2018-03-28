namespace Util.Security.Identity.Options {
    /// <summary>
    /// 密码配置
    /// </summary>
    public class PasswordOptions {
        /// <summary>
        /// 密码最小长度，默认值为 1
        /// </summary>
        public int MinLength { get; set; } = 1;

        /// <summary>
        /// 密码应包含不重复的字符数，默认值为 1
        /// </summary>
        public int UniqueChars { get; set; } = 1;

        /// <summary>
        /// 密码应包含非字母和数字的特殊字符，比如 #，默认不启用
        /// </summary>
        public bool NonAlphanumeric { get; set; }

        /// <summary>
        /// 密码应包含大写字母，默认不启用
        /// </summary>
        public bool Uppercase { get; set; }

        /// <summary>
        /// 密码应包含数字，默认不启用
        /// </summary>
        public bool Digit { get; set; }
    }
}
