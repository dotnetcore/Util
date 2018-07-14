using Util.Biz.Payments.Core;

namespace Util.Biz.Payments.Alipay.Parameters.Requests {
    /// <summary>
    /// 支付宝支付参数
    /// </summary>
    public class AlipayRequestBase : PayParamBase {
        /// <summary>
        /// 支付订单付款超时时间，单位：分钟，默认为90分钟
        /// </summary>
        public int Timeout { get; set; } = 90;
    }
}