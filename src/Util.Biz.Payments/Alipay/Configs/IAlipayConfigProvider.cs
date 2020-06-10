using System.Threading.Tasks;

namespace Util.Biz.Payments.Alipay.Configs {
    /// <summary>
    /// 支付宝配置提供器
    /// </summary>
    public interface IAlipayConfigProvider {
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="parameter">参数</param>
        Task<AlipayConfig> GetConfigAsync( object parameter = null );
    }
}