using System.Collections.Generic;

namespace Util.Biz.Payments.Alipay.Results {
    /// <summary>
    /// 支付宝下载对账单结果
    /// </summary>
    public class AlipayDownloadBillResult {
        /// <summary>
        /// 初始化支付宝下载对账单结果
        /// </summary>
        /// <param name="result">支付宝结果</param>
        /// <param name="url">账单下载地址</param>
        /// <param name="bills">对账单信息列表</param>
        public AlipayDownloadBillResult( AlipayResult result,string url, List<AlipayBillInfo> bills ) {
            Success = result.Success;
            Raw = result.Raw;
            Message = result.GetMessage();
            Parameter = result.Builder.ToString();
            DownloadUrl = url;
            Bills = bills ?? new List<AlipayBillInfo>();
        }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; }

        /// <summary>
        /// 支付接口返回的原始消息
        /// </summary>
        public string Raw { get; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// 请求参数
        /// </summary>
        public string Parameter { get; }

        /// <summary>
        /// 账单下载地址
        /// </summary>
        public string DownloadUrl { get; }

        /// <summary>
        /// 对账单信息列表
        /// </summary>
        public List<AlipayBillInfo> Bills { get; }
    }
}
