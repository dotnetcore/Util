using Util.Biz.Payments.Wechatpay.Configs;
using Util.Biz.Payments.Wechatpay.Parameters.Requests;
using Util.Helpers;

namespace Util.Biz.Payments.Wechatpay.Parameters {
    /// <summary>
    /// 微信退款参数生成器
    /// </summary>
    public class WechatpayRefundParameterBuilder : WechatpayParameterBuilder {
        /// <summary>
        /// 初始化微信退款参数生成器
        /// </summary>
        /// <param name="config">配置</param>
        public WechatpayRefundParameterBuilder( WechatpayConfig config )
            : base( config ) {
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init( WechatRefundRequest param ) {
            param.CheckNull( nameof( param ) );
            RefundFee( param.RefundFee )
                .Description( param.RefundDescription )
                .RefundId( param.RefundId )
                .TransactionId( param.TransactionId )
                .AppId( Config.AppId )
                .MerchantId( Config.MerchantId )
                .Add( "nonce_str", Id.Guid() )
                .NotifyUrl( param.NotifyUrl )
                .OutTradeNo( param.OrderId )
                .TotalFee( param.Money );
        }

        /// <summary>
        /// 设置退款金额
        /// </summary>
        /// <param name="refundFee">退款金额, 单位: 元</param>
        public WechatpayRefundParameterBuilder RefundFee( decimal refundFee ) {
            Add( "refund_fee", Convert.ToInt( refundFee * 100 ) );
            return this;
        }

        /// <summary>
        /// 设置微信订单号
        /// </summary>
        /// <param name="transactionId">微信订单号</param>
        public WechatpayRefundParameterBuilder TransactionId( string transactionId ) {
            Add( "transaction_id", transactionId );
            return this;
        }

        /// <summary>
        /// 设置商户退款单号
        /// </summary>
        /// <param name="refundId">商户退款单号</param>
        public WechatpayRefundParameterBuilder RefundId( string refundId ) {
            Add( "out_refund_no", refundId );
            return this;
        }

        /// <summary>
        /// 设置退款原因
        /// </summary>
        /// <param name="description">退款原因</param>
        public WechatpayRefundParameterBuilder Description( string description ) {
            Add( "refund_desc", description );
            return this;
        }
    }
}
