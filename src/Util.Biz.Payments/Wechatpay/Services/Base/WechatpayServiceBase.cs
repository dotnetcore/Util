using System.Threading.Tasks;
using Util.Biz.Payments.Core;
using Util.Biz.Payments.Wechatpay.Configs;
using Util.Biz.Payments.Wechatpay.Parameters;
using Util.Biz.Payments.Wechatpay.Results;
using Util.Helpers;
using Util.Logs;
using Util.Logs.Extensions;

namespace Util.Biz.Payments.Wechatpay.Services.Base {
    /// <summary>
    /// 微信支付服务
    /// </summary>
    public abstract class WechatpayServiceBase : IPayService {
        /// <summary>
        /// 配置提供器
        /// </summary>
        protected readonly IWechatpayConfigProvider ConfigProvider;

        /// <summary>
        /// 初始化微信支付服务
        /// </summary>
        /// <param name="configProvider">微信支付配置提供器</param>
        protected WechatpayServiceBase( IWechatpayConfigProvider configProvider ) {
            configProvider.CheckNull( nameof( configProvider ) );
            ConfigProvider = configProvider;
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="param">支付参数</param>
        public virtual async Task<PayResult> PayAsync( PayParam param ) {
            var config = await ConfigProvider.GetConfigAsync();
            Validate( config, param );
            var builder = new WechatpayParameterBuilder( config );
            Config( builder, param );
            return await RequstResult( config, builder );
        }

        /// <summary>
        /// 验证
        /// </summary>
        protected void Validate( WechatpayConfig config, PayParam param ) {
            config.CheckNull( nameof( config ) );
            param.CheckNull( nameof( param ) );
            config.Validate();
            param.Validate();
            ValidateParam( param );
        }

        /// <summary>
        /// 验证参数
        /// </summary>
        /// <param name="param">支付参数</param>
        protected virtual void ValidateParam( PayParam param ) {
        }

        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="builder">参数生成器</param>
        /// <param name="param">支付参数</param>
        protected void Config( WechatpayParameterBuilder builder, PayParam param ) {
            builder.Init( param );
            builder.TradeType( GetTradeType() );
            InitBuilder( builder, param );
        }

        /// <summary>
        /// 获取交易类型
        /// </summary>
        protected abstract string GetTradeType();

        /// <summary>
        /// 初始化参数生成器
        /// </summary>
        /// <param name="builder">参数生成器</param>
        /// <param name="param">支付参数</param>
        protected virtual void InitBuilder( WechatpayParameterBuilder builder, PayParam param ) {
        }

        /// <summary>
        /// 请求结果
        /// </summary>
        protected virtual async Task<PayResult> RequstResult( WechatpayConfig config, WechatpayParameterBuilder builder ) {
            var result = new WechatpayResult( ConfigProvider, await Request( config, builder ) );
            WriteLog( config, builder, result );
            return await CreateResult( config, builder, result );
        }

        /// <summary>
        /// 发送请求
        /// </summary>
        protected virtual async Task<string> Request( WechatpayConfig config, WechatpayParameterBuilder builder ) {
            if( IsSend == false )
                return string.Empty;
            return await Web.Client()
                .Post( config.GetOrderUrl() )
                .XmlData( builder.ToXml() )
                .ResultAsync();
        }

        /// <summary>
        /// 是否发送请求
        /// </summary>
        public bool IsSend { get; set; } = true;

        /// <summary>
        /// 写日志
        /// </summary>
        protected void WriteLog( WechatpayConfig config, WechatpayParameterBuilder builder, WechatpayResult result ) {
            var log = GetLog();
            if( log.IsTraceEnabled == false )
                return;
            log.Class( GetType().FullName )
                .Caption( "微信支付" )
                .Content( $"支付方式 : {GetPayWay().Description()}" )
                .Content( $"支付网关 : {config.GetOrderUrl()}" )
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

        /// <summary>
        /// 获取支付方式
        /// </summary>
        protected abstract PayWay GetPayWay();

        /// <summary>
        /// 创建支付结果
        /// </summary>
        /// <param name="config">支付配置</param>
        /// <param name="builder">参数生成器</param>
        /// <param name="result">支付结果</param>
        protected virtual async Task<PayResult> CreateResult( WechatpayConfig config, WechatpayParameterBuilder builder, WechatpayResult result ) {
            var success = ( await result.ValidateAsync() ).IsValid;
            return new PayResult( success, result.GetPrepayId(), result.Raw ) {
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
        protected virtual string GetResult( WechatpayConfig config, WechatpayParameterBuilder builder, WechatpayResult result ) {
            return result.GetPrepayId();
        }
    }
}
