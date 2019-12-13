namespace Util.Biz.Payments.Wechatpay.Results {
    /// <summary>
    /// 微信支付关闭订单结果
    /// </summary>
    public class WechatpayCloseOrderResult {
        /// <summary>
        /// 初始化微信支付关闭订单结果
        /// </summary>
        /// <param name="success">是否成功</param>
        /// <param name="result">请求结果</param>
        public WechatpayCloseOrderResult( bool success,WechatpayResult result ) {
            Success = success;
            ErrorCode = result.GetErrorCode();
            Raw = result.Raw;
            Parameter = result.Builder.ToString();
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
        /// 支付接口返回的原始消息
        /// </summary>
        public string Raw { get; }

        /// <summary>
        /// 请求参数
        /// </summary>
        public string Parameter { get; }
    }
}
