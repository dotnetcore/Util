using System.Collections.Generic;
using System.Linq;
using Util.Biz.Payments.Wechatpay.Configs;
using Util.Biz.Payments.Wechatpay.Signatures;
using Util.Helpers;
using Util.Parameters;

namespace Util.Biz.Payments.Wechatpay.Results {
    /// <summary>
    /// 微信支付结果
    /// </summary>
    public class WechatpayResult {
        /// <summary>
        /// 微信支付配置
        /// </summary>
        private readonly WechatpayConfig _config;
        /// <summary>
        /// 响应结果
        /// </summary>
        private readonly ParameterBuilder _builder;
        /// <summary>
        /// 签名
        /// </summary>
        private string _sign;

        /// <summary>
        /// 初始化微信支付结果
        /// </summary>
        /// <param name="config">微信支付配置</param>
        /// <param name="response">xml响应消息</param>
        public WechatpayResult( WechatpayConfig config, string response ) {
            _config = config;
            Raw = response;
            _builder = new ParameterBuilder();
            Resolve( response );
        }

        /// <summary>
        /// 解析响应
        /// </summary>
        private void Resolve( string response ) {
            if ( response.IsEmpty() )
                return;
            var elements = Xml.ToElements( response );
            elements.ForEach( node => {
                if( node.Name == WechatpayConst.Sign ) {
                    _sign = node.Value;
                    return;
                }
                _builder.Add( node.Name.LocalName, node.Value );
            } );
        }

        /// <summary>
        /// 微信支付原始响应
        /// </summary>
        public string Raw { get; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success => GetReturnCode() == WechatpayConst.Success && GetResultCode() == WechatpayConst.Success && VerifySign();

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="name">xml节点名称</param>
        public string GetValue( string name ) {
            return _builder.GetValue( name ).SafeString();
        }

        /// <summary>
        /// 获取返回状态码
        /// </summary>
        public string GetReturnCode() {
            return GetValue( WechatpayConst.ReturnCode );
        }

        /// <summary>
        /// 获取业务结果代码
        /// </summary>
        public string GetResultCode() {
            return GetValue( WechatpayConst.ResultCode );
        }

        /// <summary>
        /// 获取返回消息
        /// </summary>
        public string GetReturnMessage() {
            return GetValue( WechatpayConst.ReturnMessage );
        }

        /// <summary>
        /// 获取应用标识
        /// </summary>
        public string GetAppId() {
            return GetValue( WechatpayConst.AppId );
        }

        /// <summary>
        /// 获取商户号
        /// </summary>
        public string GetMerchantId() {
            return GetValue( WechatpayConst.MerchantId );
        }

        /// <summary>
        /// 获取随机字符串
        /// </summary>
        public string GetNonce() {
            return GetValue( "nonce_str" );
        }

        /// <summary>
        /// 获取预支付标识
        /// </summary>
        public string GetPrepayId() {
            return GetValue( "prepay_id" );
        }

        /// <summary>
        /// 获取交易类型
        /// </summary>
        public string GetTradeType() {
            return GetValue( WechatpayConst.TradeType );
        }

        /// <summary>
        /// 获取错误码
        /// </summary>
        public string GetErrorCode() {
            return GetValue( WechatpayConst.ErrorCode );
        }

        /// <summary>
        /// 获取错误码和描述
        /// </summary>
        public string GetErrorCodeDescription() {
            return GetValue( WechatpayConst.ErrorCodeDescription );
        }

        /// <summary>
        /// 获取签名
        /// </summary>
        public string GetSign() {
            return _sign;
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        public bool VerifySign() {
            return SignManagerFactory.Create( _config, _builder ).Verify( GetSign() );
        }

        /// <summary>
        /// 获取字典
        /// </summary>
        public IDictionary<string, string> GetDictionary() {
            var builder = new ParameterBuilder(_builder);
            builder.Add( WechatpayConst.Sign, _sign );
            return builder.GetDictionary().ToDictionary( t => t.Key, t => t.Value.SafeString() );
        }
    }
}
