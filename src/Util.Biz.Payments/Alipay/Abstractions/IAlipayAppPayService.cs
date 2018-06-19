using System.Threading.Tasks;
using Util.Biz.Payments.Alipay.Parameters.Requests;

namespace Util.Biz.Payments.Alipay.Abstractions {
    /// <summary>
    /// 支付宝App支付服务
    /// </summary>
    public interface IAlipayAppPayService {
        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="request">支付参数</param>
        Task<string> PayAsync( AlipayAppPayRequest request );
    }
}