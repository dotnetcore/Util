namespace Util.Signatures {
    /// <summary>
    /// 签名密钥
    /// </summary>
    public class SignKey : ISignKey {
        /// <summary>
        /// 密钥
        /// </summary>
        private readonly string _key;

        /// <summary>
        /// 初始化签名密钥
        /// </summary>
        /// <param name="key">密钥</param>
        public SignKey( string key ) {
            _key = key;
        }

        /// <summary>
        /// 获取签名密钥
        /// </summary>
        public string GetKey() {
            return _key;
        }
    }
}
