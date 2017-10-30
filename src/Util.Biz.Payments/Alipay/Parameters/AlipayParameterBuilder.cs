using System.Collections.Generic;
using Util.Biz.Payments.Alipay.Configs;
using Util.Helpers;
using Util.Parameters;
using Util.Signatures;

namespace Util.Biz.Payments.Alipay.Parameters {
    /// <summary>
    /// 支付宝参数生成器
    /// </summary>
    public class AlipayParameterBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly AlipayConfig _config;
        /// <summary>
        /// 参数生成器
        /// </summary>
        private readonly UrlParameterBuilder _builder;

        /// <summary>
        /// 初始化支付宝参数生成器
        /// </summary>
        /// <param name="config">配置</param>
        public AlipayParameterBuilder( AlipayConfig config ) {
            config.CheckNull( nameof( config ) );
            _config = config;
            _builder = new UrlParameterBuilder();
            Config();
        }

        /// <summary>
        /// 设置配置
        /// </summary>
        private void Config() {
            Format( "json" ).Charset( "utf-8" ).SignType( "RSA2" ).Timestamp().Version( "1.0" ).AppId( _config.AppId );
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
        /// 设置应用Id
        /// </summary>
        /// <param name="appId">应用Id</param>
        public AlipayParameterBuilder AppId( string appId ) {
            _builder.Add( AlipayConst.AppId, appId );
            return this;
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
        /// 设置内容
        /// </summary>
        /// <param name="content">内容</param>
        public AlipayParameterBuilder Content( string content ) {
            _builder.Add( AlipayConst.BizContent, content );
            return this;
        }

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="builder">内容参数生成器</param>
        public AlipayParameterBuilder Content( AlipayContentBuilder builder ) {
            return Content( builder.ToJson() );
        }

        /// <summary>
        /// 获取参数字典
        /// </summary>
        public IDictionary<string, string> GetDictionary() {
            return GetSignBuilder().GetDictionary();
        }

        /// <summary>
        /// 获取签名的参数生成器
        /// </summary>
        private UrlParameterBuilder GetSignBuilder() {
            var builder = new UrlParameterBuilder( _builder );
            builder.Add( AlipayConst.Sign, GetSign() );
            return builder;
        }

        /// <summary>
        /// 获取签名
        /// </summary>
        private string GetSign() {
            var signManager = new SignManager( new SignKey( _config.AppPrivateKey ), _builder );
            return signManager.Sign();
        }

        /// <summary>
        /// 输出结果
        /// </summary>
        public string Result() {
            return GetSignBuilder().Result( true );
        }

        /// <summary>
        /// 输出结果
        /// </summary>
        public override string ToString() {
            return Result();
        }
    }
}
