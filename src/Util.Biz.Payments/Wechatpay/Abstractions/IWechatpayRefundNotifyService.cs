using Util.Biz.Payments.Core;

namespace Util.Biz.Payments.Wechatpay.Abstractions {
    /// <summary>
    /// 微信退款回调服务
    /// </summary>
    public interface IWechatpayRefundNotifyService : INotifyService {
        /// <summary>
        /// 微信退款单号
        /// </summary>
        string RefundId { get; }
        /// <summary>
        /// 商户退款单号
        /// </summary>
        string RefundNo { get; }
    }
}
