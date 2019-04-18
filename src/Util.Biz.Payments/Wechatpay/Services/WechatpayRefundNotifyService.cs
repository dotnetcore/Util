using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Biz.Payments.Wechatpay.Abstractions;
using Util.Biz.Payments.Wechatpay.Configs;
using Util.Biz.Payments.Wechatpay.Results;
using Util.Helpers;

namespace Util.Biz.Payments.Wechatpay.Services {
    /// <summary>
    /// 微信退款回调服务
    /// </summary>
    public class WechatpayRefundNotifyService : IWechatpayRefundNotifyService {
        /// <summary>
        /// 配置提供器
        /// </summary>
        private readonly IWechatpayConfigProvider _configProvider;
        /// <summary>
        /// 微信退款通知结果
        /// </summary>
        private WechatpayRefundNotifyResult _result;
        /// <summary>
        /// 是否已加载
        /// </summary>
        private bool _isLoad;

        /// <summary>
        /// 初始化微信退款回调服务
        /// </summary>
        /// <param name="configProvider">配置提供器</param>
        public WechatpayRefundNotifyService( IWechatpayConfigProvider configProvider ) {
            configProvider.CheckNull( nameof( configProvider ) );
            _configProvider = configProvider;
            _isLoad = false;
        }

        /// <summary>
        /// 退款是否成功
        /// </summary>
        public async Task<bool> IsSuccessAsync() {
            var status = await GetRefundStatusAsync();
            return status == "SUCCESS";
        }

        /// <summary>
        /// 获取参数集合
        /// </summary>
        public async Task<IDictionary<string, string>> GetParamsAsync() {
            await Init();
            return _result.GetParams();
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="name">参数名</param>
        public async Task<T> GetParamAsync<T>( string name ) {
            return Util.Helpers.Convert.To<T>( await GetParamAsync( name ) );
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="name">参数名</param>
        public async Task<string> GetParamAsync( string name ) {
            await Init();
            return _result.GetParam( name );
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private async Task Init() {
            if( _isLoad )
                return;
            var config = await _configProvider.GetConfigAsync();
            _result = new WechatpayRefundNotifyResult( config.PrivateKey, Web.Body );
            _isLoad = true;
        }

        /// <summary>
        /// 返回成功消息
        /// </summary>
        public string Success() {
            return Return( WechatpayConst.Success, WechatpayConst.Ok );
        }

        /// <summary>
        /// 返回消息
        /// </summary>
        private string Return( string code, string message ) {
            var xml = new Xml();
            xml.AddCDataNode( code, WechatpayConst.ReturnCode );
            xml.AddCDataNode( message, WechatpayConst.ReturnMessage );
            return xml.ToString();
        }

        /// <summary>
        /// 返回失败消息
        /// </summary>
        public string Fail() {
            return Return( WechatpayConst.Fail, WechatpayConst.Fail );
        }

        /// <summary>
        /// 获取返回状态码
        /// </summary>
        public async Task<string> GetReturnCodeAsync() {
            await Init();
            return _result.GetReturnCode();
        }

        /// <summary>
        /// 获取返回消息
        /// </summary>
        public async Task<string> GetReturnMessageAsync() {
            await Init();
            return _result.GetReturnMessage();
        }

        /// <summary>
        /// 获取应用标识
        /// </summary>
        public async Task<string> GetAppIdAsync() {
            await Init();
            return _result.GetAppId();
        }

        /// <summary>
        /// 获取商户号
        /// </summary>
        public async Task<string> GetMerchantIdAsync() {
            await Init();
            return _result.GetMerchantId();
        }

        /// <summary>
        /// 获取随机字符串
        /// </summary>
        public async Task<string> GetNonceAsync() {
            await Init();
            return _result.GetNonce();
        }

        /// <summary>
        /// 获取微信订单号
        /// </summary>
        public async Task<string> GetTransactionIdAsync() {
            await Init();
            return _result.GetTransactionId();
        }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public async Task<string> GetOrderIdAsync() {
            await Init();
            return _result.GetOrderId();
        }

        /// <summary>
        /// 获取微信退款单号
        /// </summary>
        public async Task<string> GetRefundIdAsync() {
            await Init();
            return _result.GetRefundId();
        }

        /// <summary>
        /// 获取商户退款单号
        /// </summary>
        public async Task<string> GetRefundNo() {
            await Init();
            return _result.GetRefundNo();
        }

        /// <summary>
        /// 获取订单金额
        /// </summary>
        public async Task<decimal> GetTotalFeeAsync() {
            await Init();
            return _result.GetTotalFee().ToDecimal() / 100M;
        }

        /// <summary>
        /// 获取应结订单金额
        /// </summary>
        public async Task<decimal> GetSettlementTotalFeeAsync() {
            await Init();
            return _result.GetSettlementTotalFee().ToDecimal() / 100M;
        }

        /// <summary>
        /// 获取申请退款金额
        /// </summary>
        public async Task<decimal> GetRefundFeeAsync() {
            await Init();
            return _result.GetRefundFee().ToDecimal() / 100M;
        }

        /// <summary>
        /// 获取退款金额
        /// </summary>
        public async Task<decimal> GetSettlementRefundFeeAsync() {
            await Init();
            return _result.GetSettlementRefundFee().ToDecimal() / 100M;
        }

        /// <summary>
        /// 获取退款状态
        /// </summary>
        public async Task<string> GetRefundStatusAsync() {
            await Init();
            return _result.GetRefundStatus();
        }

        /// <summary>
        /// 获取退款成功时间
        /// </summary>
        public async Task<DateTime> GetSuccessTimeAsync() {
            await Init();
            return _result.GetSuccessTime().ToDate();
        }

        /// <summary>
        /// 获取退款入账账户
        /// </summary>
        public async Task<string> GetRefundReceiveAccoutAsync() {
            await Init();
            return _result.GetRefundReceiveAccout();
        }

        /// <summary>
        /// 获取退款来源账户
        /// </summary>
        public async Task<string> GetRefundAccountAsync() {
            await Init();
            return _result.GetRefundAccount();
        }

        /// <summary>
        /// 获取退款发起来源
        /// </summary>
        public async Task<string> GetRefundRequestSourceAsync() {
            await Init();
            return _result.GetRefundRequestSource();
        }
    }
}