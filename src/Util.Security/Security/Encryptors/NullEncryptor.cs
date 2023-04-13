namespace Util.Security.Encryptors {
    /// <summary>
    /// 空加密器
    /// </summary>
    public class NullEncryptor : IEncryptor {
        /// <summary>
        /// 空加密器实例
        /// </summary>
        public static readonly IEncryptor Instance = new NullEncryptor();

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="data">原始数据</param>
        public string Encrypt( string data ) {
            return string.Empty;
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="data">已加密数据</param>
        public string Decrypt( string data ) {
            return string.Empty;
        }
    }
}
