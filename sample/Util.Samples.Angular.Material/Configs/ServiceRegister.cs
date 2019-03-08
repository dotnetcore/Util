using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Util.Dependency;
using Util.Files;
using Util.Files.Paths;
using Util.Randoms;
using Util.Samples.Data.Repositories.Systems;
using Util.Samples.Domains.Models;
using Util.Security.Identity.Describers;

namespace Util.Samples.Configs {
    /// <summary>
    /// 服务注册
    /// </summary>
    public class ServiceRegister : IDependencyRegistrar {
        /// <summary>
        /// 注册依赖
        /// </summary>
        public void Register( IServiceCollection services ) {
            services.AddIdentity<IdentityUser, Role>()
                .AddRoleStore<RoleRepository>();
            services.AddScoped<IdentityErrorDescriber, IdentityErrorChineseDescriber>();
            services.AddScoped<IFileStore, DefaultFileStore>();
            services.AddScoped<IPathGenerator, DefaultPathGenerator>();
            services.AddSingleton<IBasePath>(new DefaultBasePath( "/upload" ));
            services.AddScoped<IRandomGenerator, GuidRandomGenerator>();
        }
    }
}
