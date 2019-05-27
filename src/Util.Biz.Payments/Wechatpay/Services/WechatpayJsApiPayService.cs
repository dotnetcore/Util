﻿using System.Threading.Tasks;
using Util.Biz.Payments.Core;
using Util.Biz.Payments.Wechatpay.Abstractions;
using Util.Biz.Payments.Wechatpay.Configs;
using Util.Biz.Payments.Wechatpay.Parameters;
using Util.Biz.Payments.Wechatpay.Parameters.Requests;
using Util.Biz.Payments.Wechatpay.Results;
using Util.Biz.Payments.Wechatpay.Services.Base;
using Util.Exceptions;
using Util.Helpers;

namespace Util.Biz.Payments.Wechatpay.Services {
    /// <summary>
    /// 微信JsApi支付服务
    /// </summary>
    public class WechatpayJsApiPayService : WechatpayServiceBase, IWechatpayJsApiPayService {
        /// <summary>
        /// 初始化微信JsApi支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatpayJsApiPayService( IWechatpayConfigProvider provider ) : base( provider ) {
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="request">支付参数</param>
        public async Task<PayResult> PayAsync( WechatpayJsApiPayRequest request ) {
            return await PayAsync( request.ToParam() );
        }

        /// <summary>
        /// 获取支付方式
        /// </summary>
        protected override PayWay GetPayWay() {
            return PayWay.WechatpayJsApiPay;
        }

        /// <summary>
        /// 获取交易类型
        /// </summary>
        protected override string GetTradeType() {
            return "JSAPI";
        }

        /// <summary>
        /// 验证参数
        /// </summary>
        /// <param name="param">支付参数</param>
        protected override void ValidateParam( PayParam param ) {
            if( param.OpenId.IsEmpty() )
                throw new Warning( "必须设置OpenId" );
        }

        /// <summary>
        /// 初始化参数生成器
        /// </summary>
        /// <param name="builder">参数生成器</param>
        /// <param name="param">支付参数</param>
        protected override void InitBuilder( WechatpayParameterBuilder builder, PayParam param ) {
            builder.OpenId( param.OpenId );
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        /// <param name="config">支付配置</param>
        /// <param name="builder">参数生成器</param>
        /// <param name="result">支付结果</param>
        protected override string GetResult( WechatpayConfig config, WechatpayParameterBuilder builder, WechatpayResult result ) {
            return new WechatpayParameterBuilder( config )
                .Add( "appId", config.AppId )
                .Add( "timeStamp", Time.GetUnixTimestamp().SafeString() )
                .Add( "nonceStr", Id.Guid() )
                .Package( $"prepay_id={result.GetPrepayId()}" )
                .Add( "signType", config.SignType.Description() )
                .SignParamName( "paySign" )
                .ToJson();
        }
    }
}