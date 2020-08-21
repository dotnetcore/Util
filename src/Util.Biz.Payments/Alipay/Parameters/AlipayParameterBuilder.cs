using System.Collections.Generic;
using Util.Biz.Payments.Alipay.Configs;
using Util.Biz.Payments.Core;
using Util.Helpers;
using Util.Parameters;
using Util.Signatures;

namespace Util.Biz.Payments.Alipay.Parameters {
    /// <summary>
    /// 支付宝参数生成器
    /// </summary>
    public class AlipayParameterBuilder {
        /// <summary>
        /// 参数生成器
        /// </summary>
        private readonly UrlParameterBuilder _builder;

        /// <summary>
        /// 配置
        /// </summary>
        public AlipayConfig Config { get; }

        /// <summary>
        /// 内容
        /// </summary>
        public AlipayContentBuilder Content { get; }

        /// <summary>z
        /// 初始化支付宝参数生成器
        /// </summary>
        /// <param name="config">配置</param>
        public AlipayParameterBuilder( AlipayConfig config ) {
            config.CheckNull( nameof( config ) );
            Config = config;
            _builder = new UrlParameterBuilder();
            Content = new AlipayContentBuilder();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init() {
            AppId( Config.AppId ).Format( "json" ).Charset( Config.Charset ).SignType( "RSA2" ).Timestamp().Version( "1.0" );
        }

        /// <summary>
        /// 初始化支付参数
        /// </summary>
        public void Init( PayParam param ) {
            param.Init();
            Content.Init( param );
            ReturnUrl( param.ReturnUrl ).NotifyUrl( param.NotifyUrl );
        }

        /// <summary>
        /// 设置格式
        /// </summary>
        /// <param name="format">格式</param>
        private AlipayParameterBuilder Format( string format ) {
            _builder.Add( AlipayConst.Format, format );
            return this;
        }

        /// <summary>
        /// 设置编码
        /// </summary>
        /// <param name="charset">字符集</param>
        private AlipayParameterBuilder Charset( string charset ) {
            _builder.Add( AlipayConst.Charset, charset );
            return this;
        }

        /// <summary>
        /// 设置签名类型
        /// </summary>
        /// <param name="type">签名类型</param>
        private AlipayParameterBuilder SignType( string type ) {
            _builder.Add( AlipayConst.SignType, type );
            return this;
        }

        /// <summary>
        /// 设置时间戳
        /// </summary>
        private AlipayParameterBuilder Timestamp() {
            _builder.Add( AlipayConst.Timestamp, Time.GetDateTime() );
            return this;
        }

        /// <summary>
        /// 设置版本
        /// </summary>
        /// <param name="version">版本</param>
        private AlipayParameterBuilder Version( string version ) {
            _builder.Add( AlipayConst.Version, version );
            return this;
        }

        /// <summary>
        /// 设置应用标识
        /// </summary>
        /// <param name="appId">应用标识</param>
        public AlipayParameterBuilder AppId( string appId ) {
            _builder.Add( AlipayConst.AppId, appId );
            return this;
        }

        /// <summary>
        /// 设置返回地址
        /// </summary>
        /// <param name="returnUrl">返回地址</param>
        public AlipayParameterBuilder ReturnUrl( string returnUrl ) {
            _builder.Add( AlipayConst.ReturnUrl, returnUrl );
            return this;
        }

        /// <summary>
        /// 设置回调通知地址
        /// </summary>
        /// <param name="notifyUrl">回调通知地址</param>
        public AlipayParameterBuilder NotifyUrl( string notifyUrl ) {
            _builder.Add( AlipayConst.NotifyUrl, GetNotifyUrl( notifyUrl ) );
            return this;
        }

        /// <summary>
        /// 获取回调通知地址
        /// </summary>
        private string GetNotifyUrl( string notifyUrl ) {
            if ( notifyUrl.IsEmpty() )
                return Config.NotifyUrl;
            return notifyUrl;
        }

        /// <summary>
        /// 设置请求方法
        /// </summary>
        /// <param name="method">请求方法</param>
        public AlipayParameterBuilder Method( string method ) {
            _builder.Add( AlipayConst.Method, method );
            return this;
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="name">参数名</param>
        public object GetValue( string name ) {
            return _builder.GetValue( name );
        }

        /// <summary>
        /// 获取参数字典
        /// </summary>
        /// <param name="isConvertToSingleQuotes">是否将双引号转成单引号</param>
        /// <param name="isUrlEncode">是否Url编码</param>
        public IDictionary<string, object> GetDictionary( bool isConvertToSingleQuotes = false, bool isUrlEncode = false ) {
            return GetSignBuilder( isConvertToSingleQuotes ).GetDictionary( true, isUrlEncode, Config.Charset );
        }

        /// <summary>
        /// 获取签名的参数生成器
        /// </summary>
        private UrlParameterBuilder GetSignBuilder( bool isConvertToSingleQuotes = false ) {
            var builder = new UrlParameterBuilder( _builder );
            if ( Content.IsEmpty == false )
                builder.Add( AlipayConst.BizContent, Content.ToJson( isConvertToSingleQuotes ) );
            builder.Add( AlipayConst.Sign, GetSign( builder ) );
            return builder;
        }

        /// <summary>
        /// 获取签名
        /// </summary>
        private string GetSign( UrlParameterBuilder builder ) {
            var signManager = new SignManager( new SignKey( Config.PrivateKey ), builder );
            return signManager.Sign();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        /// <param name="isUrlEncode">是否Url编码</param>
        public string Result( bool isUrlEncode = false ) {
            return GetSignBuilder().Result( true, isUrlEncode, Config.Charset );
        }

        /// <summary>
        /// 输出结果
        /// </summary>
        public override string ToString() {
            return GetSignBuilder().Result( true );
        }
    }
}