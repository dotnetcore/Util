using System;
using Util.Biz.Payments.Wechatpay.Enums;
using Util.Exceptions;
using Util.Validations;

namespace Util.Biz.Payments.Wechatpay.Parameters.Requests {
    /// <summary>
    /// 微信支付下载对账单接口参数
    /// </summary>
    public class WechatpayDownloadBillRequest : IValidation {
        /// <summary>
        /// 账单日期
        /// </summary>
        public DateTime? BillDate { get; set; }
        /// <summary>
        /// 账单类型
        /// </summary>
        public WechatpayBillType BillType { get; set; }

        /// <summary>
        /// 验证
        /// </summary>
        public ValidationResultCollection Validate() {
            if( BillDate == null )
                throw new Warning( "必须设置账单日期" );
            return ValidationResultCollection.Success;
        }

        /// <summary>
        /// 获取账单日期
        /// </summary>
        public string GetBillDate() {
            return BillDate.SafeValue().ToString( "yyyyMMdd" );
        }
    }
}
