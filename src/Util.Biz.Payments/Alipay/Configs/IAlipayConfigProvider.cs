using System.Threading.Tasks;

namespace Util.Biz.Payments.Alipay.Configs {
    /// <summary>
    /// 支付宝配置提供器
    /// </summary>
    public interface IAlipayConfigProvider {
        /// <summary>
        /// 获取配置
        /// </summary>
        Task<AlipayConfig> GetConfigAsync();
    }
}