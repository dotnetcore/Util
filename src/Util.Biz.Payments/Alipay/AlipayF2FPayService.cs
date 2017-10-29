using Util.Biz.Payments.Alipay.Configs;
using Util.Biz.Payments.Core;
using Util.Helpers;

namespace Util.Biz.Payments.Alipay {
    /// <summary>
    /// 支付宝当面付服务
    /// </summary>
    public class AlipayF2FPayService : AlipayServiceBase {
        /// <summary>
        /// 初始化支付宝当面付服务
        /// </summary>
        /// <param name="provider">支付宝配置提供器</param>
        public AlipayF2FPayService( IAlipayConfigProvider provider ) : base( provider ){
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="parameter">支付参数</param>
        /// <param name="config">支付配置</param>
        protected override PayResult Pay( PayParam parameter, AlipayConfig config ) {
            var result = Web.Client()
                .Post( config.GatewayUrl )
                .Result();
            return new PayResult( true, result );
        }
    }
}
