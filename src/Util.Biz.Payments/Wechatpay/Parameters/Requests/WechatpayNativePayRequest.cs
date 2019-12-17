using Util.Biz.Payments.Core;

namespace Util.Biz.Payments.Wechatpay.Parameters.Requests {
    /// <summary>
    /// 微信扫码支付参数
    /// </summary>
    public class WechatpayNativePayRequest : PayParamBase {
        /// <summary>
        /// 附加数据，通知时原样返回
        /// </summary>
        public string Attach { get; set; }
    }
}
