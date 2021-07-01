using Microsoft.Extensions.DependencyInjection;

namespace Util.Configs {
    /// <summary>
    /// 配置项扩展
    /// </summary>
    public interface IOptionsExtension {
        /// <summary>
        /// 添加服务集合
        /// </summary>
        /// <param name="services">服务集合</param>
        void AddServices( IServiceCollection services );
    }
}
