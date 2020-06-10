using System.Threading.Tasks;
using Util.Biz.Payments.Wechatpay.Configs;

namespace Util.Biz.Tests.Integration.Payments.Wechatpay.Configs {
    /// <summary>
    /// 微信支付测试配置提供器
    /// </summary>
    public class TestConfigProvider : IWechatpayConfigProvider {
        /// <summary>
        /// 请填写正确的微信支付配置
        /// </summary>
        public Task<WechatpayConfig> GetConfigAsync( object parameter = null ) {
            var config = new WechatpayConfig {
                AppId = "",
                MerchantId = "",
                PrivateKey = "",
                NotifyUrl = ""
            };
            return Task.FromResult( config );
        }
    }
}
