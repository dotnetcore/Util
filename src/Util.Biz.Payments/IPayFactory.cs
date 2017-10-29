using Util.Biz.Payments.Core;

namespace Util.Biz.Payments {
    /// <summary>
    /// 支付工厂
    /// </summary>
    public interface IPayFactory {
        /// <summary>
        /// 创建支付服务
        /// </summary>
        /// <param name="way">支付方式</param>
        IPayService CreatePayService( PayWay way );
    }
}
