using System.Threading.Tasks;

namespace Util.Tools.Sms.LuoSiMao {
    /// <summary>
    /// 短信配置提供器
    /// </summary>
    public class SmsConfigProvider : ISmsConfigProvider {
        /// <summary>
        /// 短信配置
        /// </summary>
        private readonly SmsConfig _config;

        /// <summary>
        /// 初始化短信配置提供器
        /// </summary>
        /// <param name="key">密钥</param>
        public SmsConfigProvider( string key ) {
            _config = new SmsConfig( key );
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        public Task<SmsConfig> GetConfigAsync() {
            return Task.FromResult( _config );
        }
    }
}
