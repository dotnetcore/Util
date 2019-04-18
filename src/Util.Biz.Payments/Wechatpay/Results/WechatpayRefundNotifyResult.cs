using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Util.Biz.Payments.Wechatpay.Configs;
using Util.Helpers;
using Util.Logs;
using Util.Logs.Extensions;
using Util.Parameters;

namespace Util.Biz.Payments.Wechatpay.Results {
    /// <summary>
    /// 微信退款通知结果
    /// </summary>
    public class WechatpayRefundNotifyResult {
        /// <summary>
        /// 私钥
        /// </summary>
        private readonly string _key;
        /// <summary>
        /// 响应结果
        /// </summary>
        private readonly ParameterBuilder _builder;
        /// <summary>
        /// 微信支付原始响应
        /// </summary>
        public string Raw { get; }

        /// <summary>
        /// 初始化微信退款通知结果
        /// </summary>
        /// <param name="key">私钥</param>
        /// <param name="response">xml响应消息</param>
        public WechatpayRefundNotifyResult( string key, string response ) {
            if( key.IsEmpty() )
                throw new ArgumentNullException( nameof( key ) );
            _key = key;
            Raw = response;
            _builder = new ParameterBuilder();
            Resolve( response );
        }

        /// <summary>
        /// 解析响应
        /// </summary>
        private void Resolve( string response ) {
            if( response.IsEmpty() )
                return;
            var elements = Xml.ToElements( response );
            elements.ForEach( node => {
                _builder.Add( node.Name.LocalName, node.Value );
            } );
            ResolveRequestInfo();
            WriteLog();
        }

        /// <summary>
        /// 解析请求信息
        /// </summary>
        private void ResolveRequestInfo() {
            var key = Encrypt.Md5By32( _key ).ToLower();
            var info = Encrypt.AesDecrypt( GetRequestInfo(), key, Encoding.UTF8, CipherMode.ECB );
            var elements = Xml.ToElements( info );
            elements.ForEach( node => {
                _builder.Add( node.Name.LocalName, node.Value );
            } );
        }

        /// <summary>
        /// 写日志
        /// </summary>
        protected void WriteLog() {
            var log = GetLog();
            if( log.IsTraceEnabled == false )
                return;
            log.Class( GetType().FullName )
                .Caption( "微信退款返回结果" )
                .Content( "参数:" )
                .Content( GetParams() )
                .Content()
                .Content( "原始响应:" )
                .Content( Raw )
                .Trace();
        }

        /// <summary>
        /// 获取日志操作
        /// </summary>
        protected ILog GetLog() {
            try {
                return Log.GetLog( WechatpayConst.TraceLogName );
            }
            catch {
                return Log.Null;
            }
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="name">xml节点名称</param>
        public string GetParam( string name ) {
            return _builder.GetValue( name ).SafeString();
        }

        /// <summary>
        /// 获取返回状态码
        /// </summary>
        public string GetReturnCode() {
            return GetParam( WechatpayConst.ReturnCode );
        }

        /// <summary>
        /// 获取返回消息
        /// </summary>
        public string GetReturnMessage() {
            return GetParam( WechatpayConst.ReturnMessage );
        }

        /// <summary>
        /// 获取应用标识
        /// </summary>
        public string GetAppId() {
            return GetParam( WechatpayConst.AppId );
        }

        /// <summary>
        /// 获取商户号
        /// </summary>
        public string GetMerchantId() {
            return GetParam( WechatpayConst.MerchantId );
        }

        /// <summary>
        /// 获取随机字符串
        /// </summary>
        public string GetNonce() {
            return GetParam( "nonce_str" );
        }

        /// <summary>
        /// 获取加密的请求信息
        /// </summary>
        public string GetRequestInfo() {
            return GetParam( "req_info" );
        }

        /// <summary>
        /// 获取微信订单号
        /// </summary>
        public string GetTransactionId() {
            return GetParam( "transaction_id" );
        }

        /// <summary>
        /// 获取商户订单号
        /// </summary>
        public string GetOrderId() {
            return GetParam( "out_trade_no" );
        }

        /// <summary>
        /// 获取微信退款单号
        /// </summary>
        public string GetRefundId() {
            return GetParam( "refund_id" );
        }

        /// <summary>
        /// 获取商户退款单号
        /// </summary>
        public string GetRefundNo() {
            return GetParam( "out_refund_no" );
        }

        /// <summary>
        /// 获取订单金额
        /// </summary>
        public string GetTotalFee() {
            return GetParam( "total_fee" );
        }

        /// <summary>
        /// 获取应结订单金额
        /// </summary>
        public string GetSettlementTotalFee() {
            return GetParam( "settlement_total_fee" );
        }

        /// <summary>
        /// 获取申请退款金额
        /// </summary>
        public string GetRefundFee() {
            return GetParam( "refund_fee" );
        }

        /// <summary>
        /// 获取退款金额
        /// </summary>
        public string GetSettlementRefundFee() {
            return GetParam( "settlement_refund_fee" );
        }

        /// <summary>
        /// 获取退款状态
        /// </summary>
        public string GetRefundStatus() {
            return GetParam( "refund_status" );
        }

        /// <summary>
        /// 获取退款成功时间
        /// </summary>
        public string GetSuccessTime() {
            return GetParam( "success_time" );
        }

        /// <summary>
        /// 获取退款入账账户
        /// </summary>
        public string GetRefundReceiveAccout() {
            return GetParam( "refund_recv_accout" );
        }

        /// <summary>
        /// 获取退款来源账户
        /// </summary>
        public string GetRefundAccount() {
            return GetParam( "refund_account" );
        }

        /// <summary>
        /// 获取退款发起来源
        /// </summary>
        public string GetRefundRequestSource() {
            return GetParam( "refund_request_source" );
        }

        /// <summary>
        /// 获取参数列表
        /// </summary>
        public IDictionary<string, string> GetParams() {
            var builder = new ParameterBuilder( _builder );
            return builder.GetDictionary().ToDictionary( t => t.Key, t => t.Value.SafeString() );
        }
    }
}