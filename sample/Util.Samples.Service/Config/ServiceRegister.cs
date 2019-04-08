using Microsoft.Extensions.DependencyInjection;
using Util.Dependency;
using Util.Files;
using Util.Files.Paths;
using Util.Randoms;

namespace Util.Samples.Service.Config {
    /// <summary>
    /// 服务注册
    /// </summary>
    public class ServiceRegister : IDependencyRegistrar {
        /// <summary>
        /// 注册依赖
        /// </summary>
        public void Register( IServiceCollection services ) {
            services.AddSingleton<IFileStore, DefaultFileStore>();
            services.AddSingleton<IPathGenerator, DefaultPathGenerator>();
            services.AddSingleton<IRandomGenerator, GuidRandomGenerator>();
            services.AddSingleton<IBasePath>(t => new DefaultBasePath( "upload" ) );
        }
    }
}
