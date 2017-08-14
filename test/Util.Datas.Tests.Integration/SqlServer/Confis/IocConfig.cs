using Autofac;
using Util.Datas.Tests.Samples.Datas.SqlServer.Repositories;
using Util.Datas.Tests.Samples.Datas.SqlServer.Stores;
using Util.Datas.Tests.Samples.Datas.SqlServer.UnitOfWorks;
using Util.Datas.Tests.Samples.Domains.Repositories;
using Util.DependencyInjection;

namespace Util.Datas.Tests.SqlServer.Confis {
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
            builder.RegisterType<SqlServerUnitOfWork>().As<ISqlServerUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<ProductPoStore>().As<IProductPoStore>().InstancePerLifetimeScope();
        }

        /// <summary>
        /// 加载仓储
        /// </summary>
        private void LoadRepositories( ContainerBuilder builder ) {
            builder.RegisterType<OrderRepository>().As<IOrderRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerLifetimeScope();
        }
    }
}