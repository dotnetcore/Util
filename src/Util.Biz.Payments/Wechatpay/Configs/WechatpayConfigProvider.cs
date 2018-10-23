﻿using System.Threading.Tasks;
using Util.Parameters;

namespace Util.Biz.Payments.Wechatpay.Configs {
    /// <summary>
    /// 微信支付配置提供器
    /// </summary>
    public class WechatpayConfigProvider : IWechatpayConfigProvider {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly WechatpayConfig _config;

        /// <summary>
        /// 初始化微信支付配置提供器
        /// </summary>
        /// <param name="config">微信支付配置</param>
        public WechatpayConfigProvider( WechatpayConfig config ) {
            _config = config;
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="parameters">参数服务</param>
        public Task<WechatpayConfig> GetConfigAsync( IParameterManager parameters = null ) {
            return Task.FromResult( _config );
        }
    }
}
