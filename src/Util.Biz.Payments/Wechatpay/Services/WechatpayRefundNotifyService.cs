using Util.Biz.Payments.Wechatpay.Abstractions;
using Util.Biz.Payments.Wechatpay.Configs;

namespace Util.Biz.Payments.Wechatpay.Services {
    /// <summary>
    /// 微信退款回调服务
    /// </summary>
    public class WechatpayRefundNotifyService : WechatpayNotifyService, IWechatpayRefundNotifyService {
        /// <summary>
        /// 初始化微信退款回调服务
        /// </summary>
        /// <param name="configProvider">配置提供器</param>
        public WechatpayRefundNotifyService( IWechatpayConfigProvider configProvider ) : base( configProvider ) {
        }

        /// <summary>
        /// 微信退款单号
        /// </summary>
        public string RefundId => GetParam( "refund_id" );

        /// <summary>
        /// 商户退款单号
        /// </summary>
        public string RefundNo => GetParam( "out_refund_no" );
    }
}
