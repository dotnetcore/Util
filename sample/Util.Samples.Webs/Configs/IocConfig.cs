using Autofac;
using Util.Contexts;
using Util.DependencyInjection;
using Util.Domains.Sessions;
using Util.Logs;
using Util.Logs.Abstractions;
using Util.Logs.Core;
using Util.Logs.NLog;

namespace Util.Samples.Webs.Configs {
    /// <summary>
    /// Ioc配置
    /// </summary>
    public class IocConfig : ConfigBase {
        /// <summary>
        /// 加载配置
        /// </summary>
        protected override void Load( ContainerBuilder builder ) {
            LoadInfrastructure( builder );
            LoadLog( builder );
        }
        
        /// <summary>
        /// 加载基础设施
        /// </summary>
        private void LoadInfrastructure( ContainerBuilder builder ) {
            builder.RegisterType<WebContext>().As<IContext>().SingleInstance();
            builder.RegisterType<NullSession>().As<ISession>().InstancePerLifetimeScope();
        }

        /// <summary>
        /// 加载日志
        /// </summary>
        private void LoadLog( ContainerBuilder builder ) {
            builder.RegisterType<LogContext>().As<ILogContext>().InstancePerLifetimeScope();
            builder.RegisterType<LogManager>().As<ILogManager>().InstancePerLifetimeScope();
        }
    }
}
