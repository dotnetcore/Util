using System.Threading.Tasks;
using Util.Biz.Payments.Wechatpay.Configs;
using Util.Biz.Payments.Wechatpay.Parameters;
using Util.Biz.Payments.Wechatpay.Results;
using Util.Helpers;
using Util.Logs;
using Util.Logs.Extensions;
using Util.Validations;

namespace Util.Biz.Payments.Wechatpay.Services.Base {
    /// <summary>
    /// 微信支付服务
    /// </summary>
    /// <typeparam name="TRequest">请求参数类型</typeparam>
    public abstract class WechatpayServiceBase<TRequest> where TRequest : IValidation {
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
        /// 请求
        /// </summary>
        /// <param name="param">请求参数</param>
        protected virtual async Task<WechatpayResult> Request( TRequest param ) {
            var config = await ConfigProvider.GetConfigAsync( param );
            Validate( config, param );
            var builder = new WechatpayParameterBuilder( config );
            ConfigBuilder( builder, param );
            return await RequstResult( config, builder );
        }

        /// <summary>
        /// 验证
        /// </summary>
        protected void Validate( WechatpayConfig config, TRequest param ) {
            config.CheckNull( nameof( config ) );
            param.CheckNull( nameof( param ) );
            config.Validate();
            param.Validate();
            ValidateParam( param );
        }

        /// <summary>
        /// 验证参数
        /// </summary>
        /// <param name="param">请求参数</param>
        protected virtual void ValidateParam( TRequest param ) {
        }

        /// <summary>
        /// 配置参数生成器
        /// </summary>
        /// <param name="builder">参数生成器</param>
        /// <param name="param">请求参数</param>
        protected abstract void ConfigBuilder( WechatpayParameterBuilder builder, TRequest param );

        /// <summary>
        /// 请求结果
        /// </summary>
        protected virtual async Task<WechatpayResult> RequstResult( WechatpayConfig config, WechatpayParameterBuilder builder ) {
            var response = await SendRequest( config, builder );
            var result = new WechatpayResult( ConfigProvider, response, config, builder );
            WriteLog( config, builder, result );
            return result;
        }

        /// <summary>
        /// 发送请求
        /// </summary>
        protected virtual async Task<string> SendRequest( WechatpayConfig config, WechatpayParameterBuilder builder ) {
            if( IsSend == false )
                return string.Empty;
            return await Web.Client()
                .Post( GetUrl( config ) )
                .XmlData( builder.ToXml() )
                .ResultAsync();
        }

        /// <summary>
        /// 是否发送请求
        /// </summary>
        public bool IsSend { get; set; } = true;

        /// <summary>
        /// 获取接口地址
        /// </summary>
        /// <param name="config">支付配置</param>
        protected abstract string GetUrl( WechatpayConfig config );

        /// <summary>
        /// 写日志
        /// </summary>
        protected void WriteLog( WechatpayConfig config, WechatpayParameterBuilder builder, WechatpayResult result ) {
            var log = GetLog();
            if( log.IsTraceEnabled == false )
                return;
            log.Class( GetType().FullName )
                .Caption( "微信支付" )
                .Content( $"支付网关 : {GetUrl( config )}" )
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
