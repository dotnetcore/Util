using System.Threading.Tasks;
using Util.Parameters;

namespace Util.Biz.Payments.Wechatpay.Configs {
    /// <summary>
    /// 微信支付配置提供器
    /// </summary>
    public interface IWechatpayConfigProvider {
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="parameters">参数服务</param>
        Task<WechatpayConfig> GetConfigAsync( IParameterManager parameters = null );
    }
}
