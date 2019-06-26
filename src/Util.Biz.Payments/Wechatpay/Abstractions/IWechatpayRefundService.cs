using System.Threading.Tasks;
using Util.Biz.Payments.Core;
using Util.Biz.Payments.Wechatpay.Parameters.Requests;

namespace Util.Biz.Payments.Wechatpay.Abstractions {
    /// <summary>
    /// 微信退款
    /// </summary>
    public interface IWechatpayRefundService {
        /// <summary>
        /// 退款
        /// </summary>
        /// <param name="request">退款参数</param>
        Task<RefundResult> RefundAsync( WechatRefundRequest request );
    }
}
