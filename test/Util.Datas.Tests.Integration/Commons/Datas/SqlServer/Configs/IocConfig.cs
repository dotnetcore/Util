using Autofac;
using Util.Datas.Dapper;
using Util.Datas.Dapper.SqlServer;
using Util.Datas.Sql;
using Util.Datas.Sql.Matedatas;
using Util.Datas.Sql.Queries;
using Util.Datas.Tests.Commons.Domains.Repositories;
using Util.Datas.Tests.Ef.SqlServer.Repositories;
using Util.Datas.Tests.Ef.SqlServer.Stores;
using Util.Datas.Tests.Ef.SqlServer.UnitOfWorks;
using Util.Datas.Transactions;
using Util.Datas.UnitOfWorks;
using Util.Dependency;
using Util.Sessions;

namespace Util.Datas.Tests.Commons.Datas.SqlServer.Configs {
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
            builder.AddSingleton<ISession>( new Session( AppConfig.UserId ) );
            builder.AddScoped<IUnitOfWorkManager, UnitOfWorkManager>();
            builder.AddScoped<ITransactionActionManager, TransactionActionManager>();
            builder.RegisterType<SqlServerUnitOfWork>().AsSelf().InstancePerLifetimeScope().PropertiesAutowired();
            builder.Register( t => t.Resolve<SqlServerUnitOfWork>() ).As<ISqlServerUnitOfWork>().InstancePerLifetimeScope().PropertiesAutowired();
            builder.Register( t => t.Resolve<SqlServerUnitOfWork>() ).As<IDatabase>().InstancePerLifetimeScope().PropertiesAutowired();
            builder.Register( t => t.Resolve<SqlServerUnitOfWork>() ).As<IEntityMatedata>().InstancePerLifetimeScope().PropertiesAutowired();
            builder.AddScoped<ISqlQuery, SqlQuery>();
            builder.AddScoped<ISqlBuilder, SqlServerBuilder>();
            builder.AddScoped<IProductPoStore, ProductPoStore>();
        }

        /// <summary>
        /// 加载仓储
        /// </summary>
        private void LoadRepositories( ContainerBuilder builder ) {
            builder.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.AddScoped<IOrderRepository, OrderRepository>();
            builder.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}