using Microsoft.Extensions.DependencyInjection;
using Util.Dependency;
using Util.Samples.Schedulers.Services;

namespace Util.Samples.Schedulers.Configs {
    /// <summary>
    /// 服务注册
    /// </summary>
    public class ServiceRegister : IDependencyRegistrar {
        /// <summary>
        /// 注册依赖
        /// </summary>
        public void Register( IServiceCollection services ) {
            services.AddScoped<ITestService2, TestService2>();
        }
    }
}
