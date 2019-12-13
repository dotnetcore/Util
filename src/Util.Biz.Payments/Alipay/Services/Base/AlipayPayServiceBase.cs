using System.Threading.Tasks;
using Util.Biz.Payments.Alipay.Configs;
using Util.Biz.Payments.Alipay.Parameters;
using Util.Biz.Payments.Alipay.Results;
using Util.Biz.Payments.Core;

namespace Util.Biz.Payments.Alipay.Services.Base {
    /// <summary>
    /// 支付宝支付服务
    /// </summary>
    public abstract class AlipayPayServiceBase : AlipayServiceBase<PayParam>, IPayService {
        /// <summary>
        /// 初始化支付宝支付服务
        /// </summary>
        /// <param name="provider">支付宝配置提供器</param>
        protected AlipayPayServiceBase( IAlipayConfigProvider provider ) : base( provider ) {
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="param">支付参数</param>
        public virtual async Task<PayResult> PayAsync( PayParam param ) {
            var result = await Request( param );
            return CreateResult( result );
        }

        /// <summary>
        /// 初始化参数生成器
        /// </summary>
        /// <param name="builder">支付宝参数生成器</param>
        /// <param name="param">支付参数</param>
        protected override void InitBuilder( AlipayParameterBuilder builder, PayParam param ) {
            builder.Init( param );
            builder.Content.Scene( GetScene() );
        }

        /// <summary>
        /// 获取场景
        /// </summary>
        protected virtual string GetScene() {
            return string.Empty;
        }

        /// <summary>
        /// 创建结果
        /// </summary>
        protected virtual PayResult CreateResult( AlipayResult result ) {
            return new PayResult( result.Success, result.GetTradeNo(), result.Raw ) {
                Parameter = result.Builder.ToString(),
                Message = result.GetMessage()
            };
        }
    }
}
