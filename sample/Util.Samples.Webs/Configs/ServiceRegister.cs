using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Util.Dependency;
using Util.Files;
using Util.Files.Paths;
using Util.Randoms;
using Util.Samples.Webs.Datas.Repositories.Systems;
using Util.Samples.Webs.Domains.Models;
using Util.Security.Identity.Describers;
using Util.Sessions;

namespace Util.Samples.Webs.Configs {
    /// <summary>
    /// 服务注册
    /// </summary>
    public class ServiceRegister : IDependencyRegistrar {
        /// <summary>
        /// 注册依赖
        /// </summary>
        public void Regist( IServiceCollection services ) {
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
