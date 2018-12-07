using System.ComponentModel.DataAnnotations;
using System.Linq;
using Util.Exceptions;
using Util.Validations;

namespace Util.Biz.Payments.Alipay.Configs {
    /// <summary>
    /// 支付宝配置
    /// </summary>
    public class AlipayConfig {
        /// <summary>
        /// 支付网关地址,默认为正式地址： https://openapi.alipay.com/gateway.do ,如果进行测试，则设置为 https://openapi.alipaydev.com/gateway.do
        /// </summary>
        [Required(ErrorMessage = "支付网关地址[GatewayUrl]不能为空" )]
        public string GatewayUrl { get; set; } = "https://openapi.alipay.com/gateway.do";

        /// <summary>
        /// 应用标识
        /// </summary>
        [Required(ErrorMessage = "应用标识[AppId]不能为空" )]
        public string AppId { get; set; }

        /// <summary>
        /// 商户应用私钥
        /// </summary>
        [Required( ErrorMessage = "商户应用私钥[PrivateKey]不能为空" )]
        public string PrivateKey { get; set; }

        /// <summary>
        /// 支付宝公钥
        /// </summary>
        [Required( ErrorMessage = "支付宝公钥[PublicKey]不能为空" )]
        public string PublicKey { get; set; }

        /// <summary>
        /// 回调通知地址
        /// </summary>
        public string NotifyUrl { get; set; }

        /// <summary>
        /// 字符编码，默认值：utf-8
        /// </summary>
        public string Charset { get; set; } = "utf-8";

        /// <summary>
        /// 获取支付网关地址
        /// </summary>
        public string GetGatewayUrl() {
            return $"{GatewayUrl}?charset={Charset}";
        }

        /// <summary>
        /// 验证
        /// </summary>
        public void Validate() {
            var result = DataAnnotationValidation.Validate( this );
            if( result.IsValid == false )
                throw new Warning( result.First().ErrorMessage );
        }
    }
}
