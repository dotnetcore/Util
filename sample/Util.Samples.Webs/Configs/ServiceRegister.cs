using Microsoft.Extensions.DependencyInjection;
using Util.Dependency;
using Util.Domains.Sessions;

namespace Util.Samples.Webs.Configs {
    /// <summary>
    /// 服务注册
    /// </summary>
    public class ServiceRegister : IDependencyRegistrar  {
        /// <summary>
        /// 注册依赖
        /// </summary>
        public void Regist( IServiceCollection services ) {
            services.AddSingleton<ISession, NullSession>();
        }
    }
}
