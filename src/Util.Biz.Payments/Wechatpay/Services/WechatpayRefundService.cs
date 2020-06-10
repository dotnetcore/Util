using System.Threading.Tasks;
using Util.Biz.Payments.Core;
using Util.Biz.Payments.Wechatpay.Abstractions;
using Util.Biz.Payments.Wechatpay.Configs;
using Util.Biz.Payments.Wechatpay.Parameters;
using Util.Biz.Payments.Wechatpay.Parameters.Requests;
using Util.Biz.Payments.Wechatpay.Results;
using Util.Exceptions;
using Util.Helpers;
using Util.Logs;
using Util.Logs.Extensions;

namespace Util.Biz.Payments.Wechatpay.Services {
    /// <summary>
    /// 微信退款服务
    /// </summary>
    public class WechatpayRefundService : IWechatpayRefundService {
        /// <summary>
        /// 微信配置提供器
        /// </summary>
        private IWechatpayConfigProvider ConfigProvider { get; }

        /// <summary>
        /// 是否发送请求
        /// </summary>
        public bool IsSend { get; set; } = true;

        /// <summary>
        /// 初始化微信支付退款服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatpayRefundService( IWechatpayConfigProvider provider ) {
            ConfigProvider = provider;
        }

        /// <summary>
        /// 退款
        /// </summary>
        /// <param name="request">退款参数</param>
        public async Task<RefundResult> RefundAsync( WechatRefundRequest request ) {
            var config = await ConfigProvider.GetConfigAsync( request );
            Validate( config, request );
            var builder = new WechatpayRefundParameterBuilder( config );
            Config( builder, request );
            return await RequstResult( config, builder );
        }

        /// <summary>
        /// 验证
        /// </summary>
        protected void Validate( WechatpayConfig config, WechatRefundRequest param ) {
            config.CheckNull( nameof( config ) );
            param.CheckNull( nameof( param ) );
            config.Validate();
            param.Validate();
            ValidateConfig( config );
            ValidateParam( param );
        }

        /// <summary>
        /// 验证配置
        /// </summary>
        /// <param name="config">配置参数</param>
        protected void ValidateConfig( WechatpayConfig config ) {
            if( config.Certificate.IsEmpty() )
                throw new Warning( "必须设置证书" );
        }

        /// <summary>
        /// 验证参数
        /// </summary>
        /// <param name="param">支付参数</param>
        protected void ValidateParam( WechatRefundRequest param ) {
            if( param.TransactionId.IsEmpty() && param.OrderId.IsEmpty() )
                throw new Warning( "商户订单号和微信订单号只能设置一个" );
            if( param.RefundFee > param.Money )
                throw new Warning( "退款金额不能超过支付金额" );
        }

        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="builder">参数生成器</param>
        /// <param name="param">支付参数</param>
        protected void Config( WechatpayRefundParameterBuilder builder, WechatRefundRequest param ) {
            builder.Init( param );
        }

        /// <summary>
        /// 请求结果
        /// </summary>
        protected virtual async Task<RefundResult> RequstResult( WechatpayConfig config, WechatpayRefundParameterBuilder builder ) {
            var response = await Request( config, builder );
            var result = new WechatpayResult( ConfigProvider, response );
            WriteLog( config, builder, result );
            return await CreateResult( config, builder, result );
        }

        /// <summary>
        /// 发送请求
        /// </summary>
        protected virtual async Task<string> Request( WechatpayConfig config, WechatpayRefundParameterBuilder builder ) {
            if( IsSend == false )
                return string.Empty;
            return await Web.Client()
                .Post( config.GetRefundUrl() )
                .Certificate( config.Certificate, config.CertificatePassword )
                .XmlData( builder.ToXml() )
                .ResultAsync();
        }

        /// <summary>
        /// 创建退款结果
        /// </summary>
        /// <param name="config">支付配置</param>
        /// <param name="builder">参数生成器</param>
        /// <param name="result">支付结果</param>
        protected virtual async Task<RefundResult> CreateResult( WechatpayConfig config, WechatpayRefundParameterBuilder builder, WechatpayResult result ) {
            var success = ( await result.ValidateAsync() ).IsValid;
            return new RefundResult( success, result.GetRefundId(), result.Raw ) {
                Parameter = builder.ToString(),
                Message = result.GetReturnMessage(),
                Result = success ? GetResult( config, builder, result ) : null
            };
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        /// <param name="config">支付配置</param>
        /// <param name="builder">参数生成器</param>
        /// <param name="result">支付结果</param>
        protected string GetResult( WechatpayConfig config, WechatpayRefundParameterBuilder builder, WechatpayResult result ) {
            return new WechatpayParameterBuilder( config )
                .Add( "appId", config.AppId )
                .Add( "timeStamp", Time.GetUnixTimestamp().SafeString() )
                .Add( "nonceStr", Id.Guid() )
                .Add( "signType", config.SignType.Description() )
                .SignParamName( "paySign" )
                .ToJson();
        }

        /// <summary>
        /// 写日志
        /// </summary>
        protected void WriteLog( WechatpayConfig config, WechatpayRefundParameterBuilder builder, WechatpayResult result ) {
            var log = GetLog();
            if( log.IsTraceEnabled == false )
                return;
            log.Class( GetType().FullName )
                .Caption( "微信退款" )
                .Content( $"退款Api地址 : {config.GetRefundUrl()}" )
                .Content( "请求参数:" )
                .Content( builder.ToXml() )
                .Content()
                .Content( "返回结果:" )
                .Content( result.GetParams() )
                .Content()
                .Content( "原始响应: " )
                .Content( result.Raw )
                .Trace();
        }

        /// <summary>
        /// 获取日志操作
        /// </summary>
        private ILog GetLog() {
            try {
                return Log.GetLog( WechatpayConst.TraceLogName );
            }
            catch {
                return Log.Null;
            }
        }
    }
}
