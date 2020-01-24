using Util.Biz.Payments.Properties;
using Util.Exceptions;
using Util.Validations;

namespace Util.Biz.Payments.Wechatpay.Parameters.Requests {
    /// <summary>
    /// 微信支付关闭订单接口参数
    /// </summary>
    public class WechatpayCloseOrderRequest : IValidation {
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 验证
        /// </summary>
        public ValidationResultCollection Validate() {
            if( OrderId.IsEmpty() )
                throw new Warning( PayResource.OrderIdIsEmpty );
            return ValidationResultCollection.Success;
        }
    }
}
