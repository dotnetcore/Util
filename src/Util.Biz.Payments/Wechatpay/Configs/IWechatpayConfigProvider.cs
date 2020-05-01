using System.Threading.Tasks;

namespace Util.Biz.Payments.Wechatpay.Configs {
    /// <summary>
    /// 微信支付配置提供器
    /// </summary>
    public interface IWechatpayConfigProvider {
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="parameter">参数</param>
        Task<WechatpayConfig> GetConfigAsync( object parameter = null );
    }
}
