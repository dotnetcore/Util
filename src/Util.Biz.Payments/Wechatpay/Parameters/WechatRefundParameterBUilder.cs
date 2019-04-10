using Util.Biz.Payments.Core;
using Util.Biz.Payments.Wechatpay.Configs;
using Util.Helpers;

namespace Util.Biz.Payments.Wechatpay.Parameters
{
    /// <summary>
    /// 微信退款参数生成器
    /// </summary>
    public class WechatRefundParameterBuilder: WechatpayParameterBuilder
    {
        /// <summary>
        /// 初始化微信退款参数生成器
        /// </summary>
        /// <param name="config"></param>
        public WechatRefundParameterBuilder(WechatpayConfig config)
            : base(config)
        {
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init(RefundParam param)
        {
            param.CheckNull(nameof(param));
            //param.Init();
            RefundFee(param.RefundFee)
                .RefundDesc(param.RefundDesc)
                .RefundNo(param.RefundNo)
                .TransactionId(param.TransactionId).AppId(Config.AppId)
                .MerchantId(Config.MerchantId)
                .Add("nonce_str", Id.Guid())
                .OutTradeNo(param.OrderId)
                .TotalFee(param.Money);
            //.NotifyUrl(param.NotifyUrl).Attach(param.Attach);
            //base.Init(param);
        }

        /// <summary>
        /// 设置退款金额
        /// </summary>
        /// <param name="refundFee">退款金额, 单位: 元</param>
        public WechatRefundParameterBuilder RefundFee(decimal refundFee)
        {
            Add("refund_fee", Convert.ToInt(refundFee * 100));
            return this;
        }
        /// <summary>
        /// 设置微信订单号
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public WechatRefundParameterBuilder TransactionId(string transactionId)
        {
            base.Add("transaction_id", transactionId);
            return this;
        }
        /// <summary>
        /// 设置商户退款单号
        /// </summary>
        /// <param name="refundNo"></param>
        /// <returns></returns>
        public WechatRefundParameterBuilder RefundNo(string refundNo)
        {
            base.Add("out_refund_no", refundNo);
            return this;
        }

        /// <summary>
        /// 设置商户退款单号
        /// </summary>
        /// <param name="refundDesc"></param>
        /// <returns></returns>
        public WechatRefundParameterBuilder RefundDesc(string refundDesc)
        {
            base.Add("refund_desc", refundDesc);
            return this;
        }
    }
}
