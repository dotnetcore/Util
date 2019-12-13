using Util.Biz.Payments.Alipay.Configs;
using Util.Biz.Payments.Alipay.Enums;

namespace Util.Biz.Payments.Alipay.Results {
    /// <summary>
    /// 支付宝交易撤消结果
    /// </summary>
    public class AlipayCancelResult {
        /// <summary>
        /// 初始化支付撤消结果
        /// </summary>
        /// <param name="result">支付宝结果</param>
        public AlipayCancelResult( AlipayResult result ) {
            Success = result.Success;
            TradeId = result.GetTradeNo();
            OrderId = result.GetOutTradeNo();
            Retry = result.GetValue( AlipayConst.RetryFlag ) != "N";
            Action = CreateAction( result.GetValue( AlipayConst.Action ) );
            Raw = result.Raw;
            Message = result.GetMessage();
            Parameter = result.Builder.ToString();
        }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; }

        /// <summary>
        /// 交易编号，支付宝交易流水号
        /// </summary>
        public string TradeId { get; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 是否需要重试
        /// </summary>
        public bool Retry { get; set; }

        /// <summary>
        /// 支付宝交易撤消触发的操作
        /// </summary>
        public CancelAction Action { get; set; }

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
        /// 创建撤消操作
        /// </summary>
        private CancelAction CreateAction( string action ) {
            switch ( action ) {
                case "close":
                    return CancelAction.Close;
                case "refund":
                    return CancelAction.Refund;
                default:
                    return CancelAction.Other;
            }
        }
    }
}
