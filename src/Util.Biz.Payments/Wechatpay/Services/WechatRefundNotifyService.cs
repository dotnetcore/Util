using Util.Biz.Payments.Wechatpay.Abstractions;
using Util.Biz.Payments.Wechatpay.Configs;

namespace Util.Biz.Payments.Wechatpay.Services
{
    /// <summary>
    /// 微信退款回调服务
    /// </summary>
    public class WechatRefundNotifyService:WechatpayNotifyService,IWechatRefundNotifyService
    {
        /// <summary>
        /// 初始化微信退款服务
        /// </summary>
        /// <param name="configProvider"></param>
        public WechatRefundNotifyService(IWechatpayConfigProvider configProvider) : base(configProvider)
        {
        }
        /// <summary>
        /// 微信退款单号
        /// </summary>
        public string RefundId => GetParam("refund_id");

        /// <summary>
        /// 商户退款单号
        /// </summary>
        public string RefundNo=> GetParam("out_refund_no");
    }
}
