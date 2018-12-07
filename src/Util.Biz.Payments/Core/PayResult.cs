namespace Util.Biz.Payments.Core {
    /// <summary>
    /// 支付结果
    /// </summary>
    public class PayResult {
        /// <summary>
        /// 初始化支付结果
        /// </summary>
        public PayResult() {
        }

        /// <summary>
        /// 初始化支付结果
        /// </summary>
        /// <param name="success">是否成功</param>
        /// <param name="tradeId">交易编号</param>
        /// <param name="raw">支付接口返回的原始消息</param>
        public PayResult( bool success,string tradeId, string raw ) {
            Success = success;
            TradeId = tradeId;
            Raw = raw;
        }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; }

        /// <summary>
        /// 交易编号，外部支付系统的交易流水号
        /// </summary>
        public string TradeId { get; }

        /// <summary>
        /// 支付接口返回的原始消息
        /// </summary>
        public string Raw { get; }

        /// <summary>
        /// 结果
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 请求参数
        /// </summary>
        public string Parameter { get; set; }
    }
}
