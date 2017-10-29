using Util.Biz.Payments.Alipay.Configs;

namespace Util.Biz.Payments.Alipay {
    /// <summary>
    /// 支付宝配置提供器
    /// </summary>
    public interface IAlipayConfigProvider {
        /// <summary>
        /// 获取配置
        /// </summary>
        AlipayConfig GetConfig();
    }
}
