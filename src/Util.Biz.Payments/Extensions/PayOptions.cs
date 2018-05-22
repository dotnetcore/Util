using Util.Biz.Payments.Alipay.Configs;

namespace Util.Biz.Payments.Extensions {
    /// <summary>
    /// 支付配置
    /// </summary>
    public class PayOptions {
        /// <summary>
        /// 支付宝配置
        /// </summary>
        public AlipayConfig AlipayOptions { get; set; } = new AlipayConfig();
    }
}
