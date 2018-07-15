using System.Threading.Tasks;
using Util.Biz.Payments.Wechatpay.Configs;
using Util.Biz.Payments.Wechatpay.Enums;

namespace Util.Biz.Tests.Integration.Payments.Wechatpay.Configs {
    /// <summary>
    /// 微信支付测试配置提供器
    /// </summary>
    public class TestConfigProvider : IWechatpayConfigProvider {
        /// <summary>
        /// 获取配置
        /// </summary>
        public Task<WechatpayConfig> GetConfigAsync() {
            var config = new WechatpayConfig {
                GatewayUrl = "https://api.mch.weixin.qq.com/",
                AppId = "wx8a80e1788a39eec6",
                MerchantId = "1483515572",
                PrivateKey = "SVHZOaMEj44WbX0f3Lj7DHkfwEqvlURF",
                NotifyUrl = "http://dealer.touchodd.com/Systems/UserRechargeOrder/WeixinRechargeableNotify"
            };
            return Task.FromResult( config );
        }
    }
}
