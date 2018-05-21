using System.Threading.Tasks;

namespace Util.Biz.Payments.Core {
    /// <summary>
    /// 支付服务
    /// </summary>
    public interface IPayService {
        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="param">支付参数</param>
        Task<PayResult> PayAsync( PayParam param );
    }
}