using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Util.Dependency;
using Util.Domains.Sessions;
using Util.Samples.Webs.Datas.Repositories.Systems;
using Util.Samples.Webs.Domains.Models;
using Util.Security.Identity.Describers;

namespace Util.Samples.Webs.Configs {
    /// <summary>
    /// 服务注册
    /// </summary>
    public class ServiceRegister : IDependencyRegistrar {
        /// <summary>
        /// 注册依赖
        /// </summary>
        public void Regist( IServiceCollection services ) {
            services.AddSingleton<ISession, NullSession>();
            services.AddIdentity<IdentityUser, Role>()
                .AddRoleStore<RoleRepository>();
            services.AddScoped<IdentityErrorDescriber, IdentityErrorChineseDescriber>();
        }
    }
}
