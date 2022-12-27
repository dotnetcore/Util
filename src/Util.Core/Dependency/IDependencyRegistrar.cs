using Microsoft.Extensions.DependencyInjection;

namespace Util.Dependency {
    /// <summary>
    /// 依赖注册器
    /// </summary>
    public interface IDependencyRegistrar {
        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="services">服务集合</param>
        void Register( IServiceCollection services );
        /// <summary>
        /// 注册序号
        /// </summary>
        int Order { get; }
    }
}
