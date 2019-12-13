using System.Threading.Tasks;
using Util.Biz.Payments.Alipay.Parameters.Requests;
using Util.Biz.Payments.Alipay.Results;

namespace Util.Biz.Payments.Alipay.Abstractions {
    /// <summary>
    /// 支付宝交易撤消服务
    /// </summary>
    public interface IAlipayCancelService {
        /// <summary>
        /// 撤消支付
        /// </summary>
        /// <param name="request">撤消参数</param>
        Task<AlipayCancelResult> CancelAsync( AlipayCancelRequest request );
    }
}
