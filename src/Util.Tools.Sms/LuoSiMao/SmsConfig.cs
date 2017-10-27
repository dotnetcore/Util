namespace Util.Tools.Sms.LuoSiMao {
    /// <summary>
    /// LuoSiMao短信配置
    /// </summary>
    public class SmsConfig {
        /// <summary>
        /// 初始化短信配置
        /// </summary>
        /// <param name="key">密钥</param>
        public SmsConfig( string key ) {
            Key = key;
        }

        /// <summary>
        /// 密钥
        /// </summary>
        public string Key { get; }
    }
}
