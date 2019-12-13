using System.Threading.Tasks;
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
    /// 微信小程序支付服务
    /// </summary>
    public class WechatpayMiniProgramPayService : WechatpayPayServiceBase, IWechatpayMiniProgramPayService {
        /// <summary>
        /// 初始化微信小程序支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatpayMiniProgramPayService( IWechatpayConfigProvider provider ) : base( provider ) {
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="request">支付参数</param>
        public async Task<PayResult> PayAsync( WechatpayMiniProgramPayRequest request ) {
            return await PayAsync( request.ToParam() );
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
                throw new Warning( "小程序支付必须设置OpenId" );
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
        /// <param name="result">支付结果</param>
        protected override string GetResult( WechatpayResult result ) {
            return new WechatpayParameterBuilder( result.Config )
                .Add( "appId", result.Config.AppId )
                .Add( "timeStamp", Time.GetUnixTimestamp().SafeString() )
                .Add( "nonceStr", Id.Guid() )
                .Package( $"prepay_id={result.GetPrepayId()}" )
                .Add( "signType", result.Config.SignType.Description() )
                .ToJson();
        }
    }
}