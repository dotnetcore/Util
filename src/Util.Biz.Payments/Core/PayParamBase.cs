using System.ComponentModel.DataAnnotations;
using System.Linq;
using Util.Exceptions;
using Util.Maps;
using Util.Validations;

namespace Util.Biz.Payments.Core {
    /// <summary>
    /// 支付参数
    /// </summary>
    public class PayParamBase : IValidation {
        /// <summary>
        /// 商户订单号
        /// </summary>
        [Required( ErrorMessageResourceType = typeof( PayResource ), ErrorMessageResourceName = "OrderIdIsEmpty" )]
        public string OrderId { get; set; }
        /// <summary>
        /// 支付金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 订单标题
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 支付订单付款超时时间，单位：分钟，默认为90分钟
        /// </summary>
        public int Timeout { get; set; } = 90;
        /// <summary>
        /// 返回地址
        /// </summary>
        public string ReturnUrl { get; set; }
        /// <summary>
        /// 回调通知地址
        /// </summary>
        public string NotifyUrl { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Init() {
            InitSubject();
        }

        /// <summary>
        /// 初始化订单标题
        /// </summary>
        private void InitSubject() {
            if( Subject.IsEmpty() )
                Subject = OrderId;
        }

        /// <summary>
        /// 验证
        /// </summary>
        public virtual ValidationResultCollection Validate() {
            ValidateMoney();
            var result = DataAnnotationValidation.Validate( this );
            if( result.IsValid )
                return ValidationResultCollection.Success;
            throw new Warning( result.First().ErrorMessage );
        }

        /// <summary>
        /// 验证金额
        /// </summary>
        private void ValidateMoney() {
            if( Money <= 0 )
                throw new Warning( PayResource.InvalidMoney );
        }

        /// <summary>
        /// 转换为支付参数
        /// </summary>
        public virtual PayParam ToParam() {
            return this.MapTo<PayParam>();
        }
    }
}
