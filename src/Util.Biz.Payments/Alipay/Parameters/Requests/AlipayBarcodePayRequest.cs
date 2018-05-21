using Util.Biz.Payments.Core;
using Util.Maps;

namespace Util.Biz.Payments.Alipay.Parameters.Requests {
    /// <summary>
    /// 条码支付参数
    /// </summary>
    public class AlipayBarcodePayRequest : PayParamBase {
        /// <summary>
        /// 用户付款授权码
        /// </summary>
        public string AuthCode { get; set; }

        /// <summary>
        /// 转换为支付参数
        /// </summary>
        public PayParam ToParam() {
            return this.MapTo<PayParam>();
        }
    }
}