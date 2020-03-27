using System;
using Util.Biz.Payments.Alipay.Enums;
using Util.Exceptions;
using Util.Validations;

namespace Util.Biz.Payments.Alipay.Parameters.Requests {
    /// <summary>
    /// 支付宝下载对账单接口参数
    /// </summary>
    public class AlipayDownloadBillRequest : IValidation {
        /// <summary>
        /// 账单日期
        /// </summary>
        public DateTime? BillDate { get; set; }
        /// <summary>
        /// 是否按月下载
        /// </summary>
        public bool IsMonth { get; set; }
        /// <summary>
        /// 账单类型
        /// </summary>
        public BillType BillType { get; set; }

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
            if( IsMonth )
                return BillDate.SafeValue().ToString( "yyyy-MM" );
            return BillDate.SafeValue().ToString( "yyyy-MM-dd" );
        }
    }
}
