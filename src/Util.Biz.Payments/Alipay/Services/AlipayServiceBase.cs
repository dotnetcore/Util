using System.Threading.Tasks;
using Util.Biz.Payments.Alipay.Configs;
using Util.Biz.Payments.Alipay.Parameters;
using Util.Biz.Payments.Alipay.Results;
using Util.Biz.Payments.Core;
using Util.Helpers;
using Util.Logs;
using Util.Logs.Extensions;

namespace Util.Biz.Payments.Alipay.Services {
    /// <summary>
    /// 支付宝支付服务
    /// </summary>
    public abstract class AlipayServiceBase : IPayService {
        /// <summary>
        /// 支付宝跟踪日志名
        /// </summary>
        public const string TraceLogName = "AlipayTraceLog";
        /// <summary>
        /// 支付宝配置
        /// </summary>
        private readonly AlipayConfig _config;
        /// <summary>
        /// 支付宝参数生成器
        /// </summary>
        private readonly AlipayParameterBuilder _builder;
        /// <summary>
        /// 支付参数
        /// </summary>
        private PayParam _payParam;

        /// <summary>
        /// 初始化支付宝支付服务
        /// </summary>
        /// <param name="provider">支付宝配置提供器</param>
        protected AlipayServiceBase( IAlipayConfigProvider provider ) {
            provider.CheckNull( nameof( provider ) );
            _config = provider.GetConfig();
            _builder = new AlipayParameterBuilder( _config );
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="param">支付参数</param>
        public PayResult Pay( PayParam param ) {
            return Async.Run( async () => await PayAsync( param ) );
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="param">支付参数</param>
        public async Task<PayResult> PayAsync( PayParam param ) {
            Validate( param );
            _payParam = param;
            Config();
            var result = new AlipayResult( await RequestAsync() );
            WriteLog( result );
            return CreateResult( result );
        }

        /// <summary>
        /// 验证
        /// </summary>
        private void Validate( PayParam param ) {
            param.CheckNull( nameof( param ) );
            param.Validate();
            ValidateParam( param );
            _config.Validate();
        }

        /// <summary>
        /// 验证参数
        /// </summary>
        /// <param name="param">支付参数</param>
        protected virtual void ValidateParam( PayParam param ) {
        }

        /// <summary>
        /// 参数配置
        /// </summary>
        private void Config() {
            var contentBuilder = GetContentBuilder( _payParam ).Scene( GetScene() );
            _builder.Content( contentBuilder ).Method( GetMethod() );
        }

        /// <summary>
        /// 获取内容参数生成器
        /// </summary>
        /// <param name="param">支付参数</param>
        protected virtual AlipayContentBuilder GetContentBuilder( PayParam param ) {
            var builder = new AlipayContentBuilder();
            builder.Load( param );
            return builder;
        }

        /// <summary>
        /// 获取场景
        /// </summary>
        protected virtual string GetScene() {
            return string.Empty;
        }

        /// <summary>
        /// 获取请求方法
        /// </summary>
        protected abstract string GetMethod();

        /// <summary>
        /// 发送请求
        /// </summary>
        private async Task<string> RequestAsync() {
            if ( IsSendRequest == false )
                return string.Empty;
            return await Web.Client()
                .Post( GetGatewayUrl() )
                .Data( _builder.GetDictionary() )
                .ResultAsync();
        }

        /// <summary>
        /// 是否发送请求
        /// </summary>
        public bool IsSendRequest { get; set; } = true;

        /// <summary>
        /// 获取支付宝网关Url
        /// </summary>
        private string GetGatewayUrl() {
            return _config.GatewayUrl;
        }

        /// <summary>
        /// 写日志
        /// </summary>
        private void WriteLog( AlipayResult result ) {
            var log = GetLog();
            if( log.IsTraceEnabled == false )
                return;
            log.Class( GetType().FullName )
                .Caption( "请求支付宝支付" )
                .Content( $"支付方式 : {GetPayWay().Description()}" )
                .Content( $"支付网关 : {GetGatewayUrl()}" )
                .Content()
                .Content( "请求参数:" )
                .Content( _builder.GetDictionary() )
                .Content()
                .Content( "返回结果:" )
                .Content( result.GetDictionary() )
                .Content()
                .Content( "原始请求:" )
                .Content( _builder.ToString() )
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
                return Log.GetLog( TraceLogName );
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
        /// 创建结果
        /// </summary>
        private PayResult CreateResult( AlipayResult result ) {
            return new PayResult( result.Success,result.GetTradeNo(), result.Raw ) {
                Message = result.GetMessage()
            };
        }

        /// <summary>
        /// 输出请求参数
        /// </summary>
        public override string ToString() {
            return _builder.ToString();
        }
    }
}
