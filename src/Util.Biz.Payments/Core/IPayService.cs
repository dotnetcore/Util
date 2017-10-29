namespace Util.Biz.Payments.Core {
    /// <summary>
    /// 支付服务
    /// </summary>
    public interface IPayService {
        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="parameter">支付参数</param>
        PayResult Pay( PayParam parameter );
    }
}
