using Util.Biz.Payments.Alipay.Configs;
using Util.Biz.Payments.Core;

namespace Util.Biz.Payments.Alipay {
    /// <summary>
    /// 支付宝支付服务
    /// </summary>
    public abstract class AlipayServiceBase : IPayService {
        /// <summary>
        /// 支付宝配置提供器
        /// </summary>
        private readonly IAlipayConfigProvider _provider;

        /// <summary>
        /// 初始化支付宝支付服务
        /// </summary>
        /// <param name="provider">支付宝配置提供器</param>
        protected AlipayServiceBase( IAlipayConfigProvider provider ) {
            provider.CheckNull( nameof( provider ) );
            _provider = provider;
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="parameter">支付参数</param>
        public PayResult Pay( PayParam parameter ) {
            parameter.CheckNull( nameof( parameter ) );
            parameter.Validate();
            var config = _provider.GetConfig();
            config.Validate();
            return Pay( parameter, config );
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="parameter">支付参数</param>
        /// <param name="config">支付配置</param>
        protected abstract PayResult Pay( PayParam parameter, AlipayConfig config );
    }
}
