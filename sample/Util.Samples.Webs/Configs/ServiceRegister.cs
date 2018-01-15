using Microsoft.Extensions.DependencyInjection;
using Util.Datas.Tests.Samples.Datas.SqlServer.Repositories;
using Util.Datas.Tests.Samples.Domains.Repositories;
using Util.Dependency;
using Util.Domains.Sessions;
using Util.Files;
using Util.Files.Paths;
using Util.Randoms;

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
            services.AddScoped<ICustomerRepository,CustomerRepository>();
            services.AddScoped<IFileStore, DefaultFileStore>();
            services.AddScoped<IPathGenerator, DefaultPathGenerator>();
            services.AddScoped<IRandomGenerator, GuidRandomGenerator>();
            services.AddScoped<IBasePath, UploadBasePath>();
        }
    }
}
