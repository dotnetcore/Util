using System.Threading.Tasks;

namespace Util.Biz.Payments.Alipay.Configs {
    /// <summary>
    /// 支付宝配置提供器
    /// </summary>
    public class AlipayConfigProvider : IAlipayConfigProvider {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly AlipayConfig _config;

        /// <summary>
        /// 初始化支付宝配置提供器
        /// </summary>
        /// <param name="config">支付宝配置</param>
        public AlipayConfigProvider( AlipayConfig config ) {
            _config = config;
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="parameter">参数</param>
        public Task<AlipayConfig> GetConfigAsync( object parameter = null ) {
            return Task.FromResult( _config );
        }
    }
}
