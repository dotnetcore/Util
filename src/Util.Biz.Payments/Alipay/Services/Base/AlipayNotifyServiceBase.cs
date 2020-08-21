using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Biz.Payments.Alipay.Configs;
using Util.Logs;
using Util.Logs.Extensions;
using Util.Parameters;
using Util.Signatures;
using Util.Validations;

namespace Util.Biz.Payments.Alipay.Services.Base {
    /// <summary>
    /// 支付宝通知服务
    /// </summary>
    public abstract class AlipayNotifyServiceBase {
        /// <summary>
        /// 参数生成器
        /// </summary>
        private readonly UrlParameterBuilder _builder;
        /// <summary>
        /// 配置提供器
        /// </summary>
        private readonly IAlipayConfigProvider _configProvider;
        /// <summary>
        /// 是否已加载
        /// </summary>
        private bool _isLoad;

        /// <summary>
        /// 初始化支付宝通知服务
        /// </summary>
        /// <param name="configProvider">配置提供器</param>
        protected AlipayNotifyServiceBase( IAlipayConfigProvider configProvider ) {
            configProvider.CheckNull( nameof( configProvider ) );
            _configProvider = configProvider;
            _builder = new UrlParameterBuilder();
            _isLoad = false;
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="name">参数名</param>
        public T GetParam<T>( string name ) {
            return Util.Helpers.Convert.To<T>( GetParam( name ) );
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="name">参数名</param>
        public string GetParam( string name ) {
            Init();
            return _builder.GetValue( name ).SafeString();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init() {
            if( _isLoad )
                return;
            Load( _builder );
            _isLoad = true;
            WriteLog();
        }

        /// <summary>
        /// 加载参数
        /// </summary>
        /// <param name="builder">参数生成器</param>
        protected abstract void Load( UrlParameterBuilder builder );

        /// <summary>
        /// 写日志
        /// </summary>
        protected void WriteLog() {
            var log = GetLog();
            if( log.IsTraceEnabled == false )
                return;
            log.Class( GetType().FullName )
                .Caption( GetCaption() )
                .Content( "原始参数:" )
                .Content( GetParams() )
                .Trace();
        }

        /// <summary>
        /// 获取日志操作
        /// </summary>
        private ILog GetLog() {
            try {
                return Log.GetLog( AlipayConst.TraceLogName );
            }
            catch {
                return Log.Null;
            }
        }

        /// <summary>
        /// 获取日志标题
        /// </summary>
        protected virtual string GetCaption() {
            return string.Empty;
        }

        /// <summary>
        /// 获取参数集合
        /// </summary>
        public IDictionary<string, string> GetParams() {
            Init();
            return _builder.GetDictionary().ToDictionary( t => t.Key, t => t.Value.SafeString() );
        }

        /// <summary>
        /// 验证
        /// </summary>
        public async Task<ValidationResultCollection> ValidateAsync() {
            Init();
            var isValid = await VerifySign();
            if( isValid == false )
                return new ValidationResultCollection( "签名失败" );
            return Validate();
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        private async Task<bool> VerifySign() {
            var config = await _configProvider.GetConfigAsync( _builder );
            var signManager = new SignManager( new SignKey( config.PrivateKey, config.PublicKey ), CreateVerifyBuilder() );
            return signManager.Verify( Sign );
        }

        /// <summary>
        /// 创建验签生成器
        /// </summary>
        private UrlParameterBuilder CreateVerifyBuilder() {
            var builder = new UrlParameterBuilder( _builder );
            builder.Remove( AlipayConst.Sign );
            builder.Remove( AlipayConst.SignType );
            return builder;
        }

        /// <summary>
        /// 验证
        /// </summary>
        protected virtual ValidationResultCollection Validate() {
            return ValidationResultCollection.Success;
        }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OrderId => GetParam( AlipayConst.OutTradeNo );

        /// <summary>
        /// 支付订单号
        /// </summary>
        public string TradeNo => GetParam( AlipayConst.TradeNo );

        /// <summary>
        /// 支付金额
        /// </summary>
        public decimal Money => GetParam( AlipayConst.TotalAmount ).ToDecimal();

        /// <summary>
        /// 买家支付宝用户号
        /// </summary>
        public string BuyerId => GetParam( AlipayConst.BuyerId );

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign => GetParam( AlipayConst.Sign );
    }
}
