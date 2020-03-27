using System.Threading.Tasks;
using Util.Biz.Payments.Alipay.Parameters.Requests;
using Util.Biz.Payments.Alipay.Results;

namespace Util.Biz.Payments.Alipay.Abstractions {
    /// <summary>
    /// 支付宝下载对账单服务
    /// </summary>
    public interface IAlipayDownloadBillService {
        /// <summary>
        /// 下载对账单
        /// </summary>
        /// <param name="request">下载对账单参数</param>
        Task<AlipayDownloadBillResult> DownloadAsync( AlipayDownloadBillRequest request );
    }
}
