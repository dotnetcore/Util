using Util.Biz.Payments.Core;

namespace Util.Biz.Payments.Wechatpay.Parameters.Requests {
    /// <summary>
    /// 微信退款参数
    /// </summary>
    public class WechatRefundRequest : PayParamBase {
        /// <summary>
        /// 退款原因
        /// </summary>
        public string RefundDescription { get; set; }
        /// <summary>
        /// 退款金额,单位：元
        /// </summary>
        public decimal RefundFee { get; set; }
        /// <summary>
        /// 商户退款单号
        /// </summary>
        public string RefundId { get; set; }
        /// <summary>
        /// 微信订单号或商户订单号
        /// </summary>
        public string TransactionId { get; set; }
    }
}
