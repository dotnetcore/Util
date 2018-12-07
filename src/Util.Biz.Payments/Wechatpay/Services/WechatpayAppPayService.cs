﻿using System.Threading.Tasks;
using Util.Biz.Payments.Core;
using Util.Biz.Payments.Wechatpay.Abstractions;
using Util.Biz.Payments.Wechatpay.Configs;
using Util.Biz.Payments.Wechatpay.Parameters;
using Util.Biz.Payments.Wechatpay.Parameters.Requests;
using Util.Biz.Payments.Wechatpay.Results;
using Util.Biz.Payments.Wechatpay.Services.Base;
using Util.Helpers;

namespace Util.Biz.Payments.Wechatpay.Services {
    /// <summary>
    /// 微信App支付服务
    /// </summary>
    public class WechatpayAppPayService : WechatpayServiceBase, IWechatpayAppPayService {
        /// <summary>
        /// 初始化微信App支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatpayAppPayService( IWechatpayConfigProvider provider ) : base( provider ) {
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="request">支付参数</param>
        public async Task<PayResult> PayAsync( WechatpayAppPayRequest request ) {
            return await PayAsync( request.ToParam() );
        }

        /// <summary>
        /// 获取支付方式
        /// </summary>
        protected override PayWay GetPayWay() {
            return PayWay.WechatpayAppPay;
        }

        /// <summary>
        /// 获取交易类型
        /// </summary>
        protected override string GetTradeType() {
            return "APP";
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        /// <param name="config">支付配置</param>
        /// <param name="builder">参数生成器</param>
        /// <param name="result">支付结果</param>
        protected override string GetResult( WechatpayConfig config, WechatpayParameterBuilder builder, WechatpayResult result ) {
            return new WechatpayParameterBuilder( config )
                .AppId( config.AppId )
                .PartnerId( config.MerchantId )
                .Add( "prepayid", result.GetPrepayId() )
                .Add( "noncestr", Id.Guid() )
                .Timestamp()
                .Package()
                .ToJson();
        }
    }
}
