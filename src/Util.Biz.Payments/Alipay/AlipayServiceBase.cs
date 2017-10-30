using Util.Biz.Payments.Alipay.Configs;
using Util.Biz.Payments.Alipay.Parameters;
using Util.Biz.Payments.Core;
using Util.Helpers;
using Util.Logs;
using Util.Logs.Extensions;

namespace Util.Biz.Payments.Alipay {
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
        /// <param name="parameter">支付参数</param>
        public PayResult Pay( PayParam parameter ) {
            Validate( parameter );
            Config( parameter );
            var result = Request();
            WriteLog( result );
            return CreateResult( result );
        }

        /// <summary>
        /// 验证
        /// </summary>
        private void Validate( PayParam parameter ) {
            parameter.CheckNull( nameof( parameter ) );
            parameter.Validate();
            _config.Validate();
        }

        /// <summary>
        /// 参数配置
        /// </summary>
        private void Config( PayParam parameter ) {
            var contentBuilder = GetContentBuilder( parameter );
            contentBuilder.Scene( GetScene() );
            _builder.Content( contentBuilder );
            _builder.Method( GetMethod() );
        }

        /// <summary>
        /// 获取内容参数生成器
        /// </summary>
        /// <param name="parameter">支付参数</param>
        protected virtual AlipayContentBuilder GetContentBuilder( PayParam parameter ) {
            var builder = new AlipayContentBuilder();
            builder.Load( parameter );
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
        private string Request() {
            return Web.Client()
                .Post( GetGatewayUrl() )
                .Data( _builder.GetDictionary() )
                .Result();
        }

        /// <summary>
        /// 获取支付宝网关Url
        /// </summary>
        private string GetGatewayUrl() {
            return _config.GatewayUrl;
        }

        /// <summary>
        /// 写日志
        /// </summary>
        private void WriteLog( string result ) {
            var log = GetLog();
            if( log.IsTraceEnabled == false )
                return;
            log.Class( GetType().FullName )
                .Caption( "支付宝支付请求" )
                .Content( "支付方式 : {0}", GetPayWay().Description() )
                .Content( "支付网关 : {0}", GetGatewayUrl() )
                .Content( "请求参数:" )
                .Content( _builder.Result() )
                .Content( "返回结果: " )
                .Content( result )
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
        private PayResult CreateResult( string result ) {
            return new PayResult( true, result );
        }
    }
}
