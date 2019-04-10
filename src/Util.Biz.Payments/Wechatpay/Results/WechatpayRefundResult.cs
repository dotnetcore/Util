using Util.Biz.Payments.Wechatpay.Configs;
using Util.Logs.Extensions;

namespace Util.Biz.Payments.Wechatpay.Results {
    /// <summary>
    /// 微信退款结果
    /// </summary>
    public class WechatpayRefundResult : WechatpayResult {
        /// <summary>
        /// 初始化微信退款结果
        /// </summary>
        /// <param name="configProvider">配置提供器</param>
        /// <param name="response">xml响应消息</param>
        public WechatpayRefundResult( IWechatpayConfigProvider configProvider, string response )
            : base( configProvider, response ) {
        }

        /// <summary>
        /// 写日志
        /// </summary>
        protected override void WriteLog() {
            var log = GetLog();
            if( log.IsTraceEnabled == false )
                return;
            log.Class( GetType().FullName )
                .Caption( "微信退款返回结果" )
                .Content( "参数:" )
                .Content( GetParams() )
                .Content()
                .Content( "原始响应:" )
                .Content( Raw )
                .Trace();
        }

        /// <summary>
        /// 获取微信退款单号
        /// </summary>
        public string GetRefundId() {
            return GetParam( "refund_id" );
        }
    }
}
