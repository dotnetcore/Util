using System.Threading.Tasks;
using Util.Biz.Payments.Alipay.Parameters.Requests;

namespace Util.Biz.Payments.Alipay.Abstractions {
    /// <summary>
    /// 支付宝手机网站支付服务
    /// </summary>
    public interface IAlipayWapPayService {
        /// <summary>
        /// 支付,返回表单html
        /// </summary>
        /// <param name="request">手机网站支付参数</param>
        Task<string> PayAsync( AlipayWapPayRequest request );
        /// <summary>
        /// 跳转到支付宝收银台
        /// </summary>
        /// <param name="request">手机网站支付参数</param>
        Task RedirectAsync( AlipayWapPayRequest request );
    }
}