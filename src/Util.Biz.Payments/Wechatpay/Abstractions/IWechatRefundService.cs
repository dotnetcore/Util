using System.Threading.Tasks;
using Util.Biz.Payments.Core;
using Util.Biz.Payments.Wechatpay.Parameters.Requests;

namespace Util.Biz.Payments.Wechatpay.Abstractions
{
    /// <summary>
    /// 微信退款
    /// </summary>
    public interface IWechatRefundService
    {
        /// <summary>
        /// 退款
        /// </summary>
        /// <param name="request">退款参数</param>
        /// <returns></returns>
        Task<RefundResult> RefundAsync(WechatRefundRequest request);
    }
}
