using Autofac;
using Util.Datas.Tests.SqlServer.UnitOfWorks;
using Util.DependencyInjection;

namespace Util.Datas.Tests.DependencyInjection {
    /// <summary>
    /// 依赖注入配置
    /// </summary>
    public class IocConfig : ConfigBase {
        /// <summary>
        /// 加载配置
        /// </summary>
        protected override void Load( ContainerBuilder builder ) {
            LoadInfrastructure( builder );
            LoadDomainServices( builder );
            LoadRepositories( builder );
        }

        /// <summary>
        /// 加载基础设施
        /// </summary>
        private void LoadInfrastructure( ContainerBuilder builder ) {
            builder.RegisterType<SqlServerUnitOfWork>().As<ISqlServerUnitOfWork>().InstancePerLifetimeScope();
        }

        /// <summary>
        /// 加载领域服务
        /// </summary>
        private void LoadDomainServices( ContainerBuilder builder ) {
        }

        /// <summary>
        /// 加载仓储
        /// </summary>
        private void LoadRepositories( ContainerBuilder builder ) {
        }
    }
}