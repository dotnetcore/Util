using System;
using Util.Biz.Payments.Alipay;
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
            _alipayConfigProvider = alipayConfigProvider;
        }

        /// <summary>
        /// 创建支付服务
        /// </summary>
        /// <param name="way">支付方式</param>
        public IPayService CreatePayService( PayWay way ) {
            switch( way ) {
                case PayWay.AlipayF2FPay:
                    return new AlipayF2FPayService( _alipayConfigProvider );
            }
            throw new NotImplementedException();
        }
    }
}

