using Util.Biz.Payments.Core;
using Util.Maps;

namespace Util.Biz.Payments.Wechatpay.Parameters.Requests
{
    /// <summary>
    /// 微信退款参数
    /// </summary>
    public class WechatRefundRequest: PayParamBase
    {
        /// <summary>
        /// 退款原因
        /// </summary>
        public string RefundDesc { get; set; }

        /// <summary>
        /// 退款金额
        /// </summary>
        public decimal RefundFee { get; set; }

        /// <summary>
        /// 商户退款单号
        /// </summary>
        public string RefundNo { get; set; }
        /// <summary>
        /// 微信订单号 与商户订单号 必须二选一
        /// </summary>
        public string TransactionId { get; set; }
        /// <summary>
        /// 证书绝对路径，如@"C:\apiclient_cert.p12"
        /// </summary>
        public string Cert { get; set; }
        /// <summary>
        /// 证书密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 转换为退款参数
        /// </summary>
        /// <returns></returns>
        public new RefundParam ToParam()
        {
            return this.MapTo<RefundParam>();
        }
    }
}
