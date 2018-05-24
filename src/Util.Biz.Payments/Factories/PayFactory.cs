using System;
using Util.Biz.Payments.Alipay.Abstractions;
using Util.Biz.Payments.Alipay.Configs;
using Util.Biz.Payments.Alipay.Services;
using Util.Biz.Payments.Core;

namespace Util.Biz.Payments.Factories {
    /// <summary>
    /// 支付工厂
    /// </summary>
    public class PayFactory : IPayFactory {
        /// <summary>
        /// 支付宝配置提供器
        /// </summary>
        private readonly IAlipayConfigProvider _alipayConfigProvider;

        /// <summary>
        /// 初始化支付工厂
        /// </summary>
        /// <param name="alipayConfigProvider">支付宝配置提供器</param>
        public PayFactory( IAlipayConfigProvider alipayConfigProvider ) {
            alipayConfigProvider.CheckNull( nameof( alipayConfigProvider ) );
            _alipayConfigProvider = alipayConfigProvider;
        }

        /// <summary>
        /// 创建支付服务
        /// </summary>
        /// <param name="way">支付方式</param>
        public IPayService CreatePayService( PayWay way ) {
            switch( way ) {
                case PayWay.AlipayBarcodePay:
                    return new AlipayBarcodePayService( _alipayConfigProvider );
                case PayWay.AlipayPagePay:
                    return new AlipayPagePayService( _alipayConfigProvider );
                case PayWay.AlipayWapPay:
                    return new AlipayWapPayService( _alipayConfigProvider );
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// 创建支付宝回调通知服务
        /// </summary>
        public IAlipayNotifyService CreateAlipayNotifyService() {
            return new AlipayNotifyService( _alipayConfigProvider );
        }

        /// <summary>
        /// 创建支付宝返回服务
        /// </summary>
        public IAlipayReturnService CreateAlipayReturnService() {
            return new AlipayReturnService( _alipayConfigProvider );
        }

        /// <summary>
        /// 创建支付宝条码支付服务
        /// </summary>
        public IAlipayBarcodePayService CreateAlipayBarcodePayService() {
            return new AlipayBarcodePayService( _alipayConfigProvider );
        }

        /// <summary>
        /// 创建支付宝电脑网站支付服务
        /// </summary>
        public IAlipayPagePayService CreateAlipayPagePayService() {
            return new AlipayPagePayService( _alipayConfigProvider );
        }

        /// <summary>
        /// 创建支付宝手机网站支付服务
        /// </summary>
        public IAlipayWapPayService CreateAlipayWapPayService() {
            return new AlipayWapPayService( _alipayConfigProvider );
        }
    }
}

