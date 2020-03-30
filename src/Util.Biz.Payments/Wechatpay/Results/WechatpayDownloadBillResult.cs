using System.Collections.Generic;

namespace Util.Biz.Payments.Wechatpay.Results {
    /// <summary>
    /// 微信支付下载对账单结果
    /// </summary>
    public class WechatpayDownloadBillResult {
        /// <summary>
        /// 初始化微信支付下载对账单结果
        /// </summary>
        /// <param name="success">是否成功</param>
        /// <param name="result">请求结果</param>
        public WechatpayDownloadBillResult( bool success, WechatpayResult result ) {
            Success = success;
            ErrorCode = result.GetErrorCode();
            ErrorMessage = result.GetErrorCodeDescription();
            Raw = result.Raw;
            Parameter = result.Builder.ToString();
            Bills = new List<WechatpayBillInfo>();
        }

        /// <summary>
        /// 初始化微信支付下载对账单结果
        /// </summary>
        /// <param name="success">是否成功</param>
        /// <param name="parameter">请求参数</param>
        /// <param name="bills">对账单信息列表</param>
        public WechatpayDownloadBillResult( bool success, string parameter, List<WechatpayBillInfo> bills ) {
            Success = success;
            Parameter = parameter;
            Bills = bills ?? new List<WechatpayBillInfo>();
        }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; }

        /// <summary>
        /// 错误码
        /// </summary>
        public string ErrorCode { get; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrorMessage { get; }

        /// <summary>
        /// 支付接口返回的原始消息
        /// </summary>
        public string Raw { get; }

        /// <summary>
        /// 请求参数
        /// </summary>
        public string Parameter { get; set; }

        /// <summary>
        /// 对账单信息列表
        /// </summary>
        public List<WechatpayBillInfo> Bills { get; set; }
    }
}
