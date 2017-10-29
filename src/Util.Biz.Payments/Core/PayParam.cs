using System.ComponentModel.DataAnnotations;
using System.Linq;
using Util.Exceptions;
using Util.Validations;

namespace Util.Biz.Payments.Core {
    /// <summary>
    /// 支付参数
    /// </summary>
    public class PayParam {
        /// <summary>
        /// 商户订单号
        /// </summary>
        [Required(ErrorMessage = "商户订单号不能为空" )]
        public string OrderId { get; set; }
        /// <summary>
        /// 支付金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 用户付款授权码
        /// </summary>
        public string AuthCode { get; set; }
        /// <summary>
        /// 订单标题
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 支付订单付款超时时间，单位：分钟，默认为90分钟
        /// </summary>
        public int Timeout { get; set; } = 90;

        /// <summary>
        /// 验证
        /// </summary>
        public void Validate() {
            ValidateDataAnnotation();
            CustomValidate();
        }

        /// <summary>
        /// 验证数据注解
        /// </summary>
        private void ValidateDataAnnotation() {
            var result = DataAnnotationValidation.Validate( this );
            if( result.IsValid == false )
                throw new Warning( result.First().ErrorMessage );
        }

        /// <summary>
        /// 自定义验证
        /// </summary>
        private void CustomValidate() {
            if( Money <= 0 )
                throw new Warning( "支付金额必须大于0" );
        }
    }
}
