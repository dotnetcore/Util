using Autofac;
using Util.Datas.Tests.Samples.Datas.PgSql.Repositories;
using Util.Datas.Tests.Samples.Datas.PgSql.UnitOfWorks;
using Util.Datas.Tests.Samples.Domains.Repositories;
using Util.Datas.UnitOfWorks;
using Util.Dependency;
using Util.Domains.Sessions;

namespace Util.Datas.Tests.PgSql.Configs {
    /// <summary>
    /// 依赖注入配置
    /// </summary>
    public class IocConfig : ConfigBase {
        /// <summary>
        /// 加载配置
        /// </summary>
        protected override void Load( ContainerBuilder builder ) {
            LoadInfrastructure( builder );
            LoadRepositories( builder );
        }

        /// <summary>
        /// 加载基础设施
        /// </summary>
        private void LoadInfrastructure( ContainerBuilder builder ) {
            builder.AddScoped<IUnitOfWorkManager, UnitOfWorkManager>();
            builder.AddScoped<IPgSqlUnitOfWork, PgSqlUnitOfWork>().PropertiesAutowired();
            builder.AddSingleton<ISession>( new Session( AppConfig.UserId ) );
        }

        /// <summary>
        /// 加载仓储
        /// </summary>
        private void LoadRepositories( ContainerBuilder builder ) {
            builder.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}