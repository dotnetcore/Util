using Util.Biz.Payments.Alipay.Abstractions;
using Util.Biz.Payments.Core;
using Util.Dependency;

namespace Util.Biz.Payments {
    /// <summary>
    /// 支付工厂
    /// </summary>
    public interface IPayFactory : IScopeDependency{
        /// <summary>
        /// 创建支付服务
        /// </summary>
        /// <param name="way">支付方式</param>
        IPayService CreatePayService( PayWay way );
        /// <summary>
        /// 创建支付宝条码支付服务
        /// </summary>
        IAlipayBarcodePayService CreateAlipayBarcodePayService();
    }
}
