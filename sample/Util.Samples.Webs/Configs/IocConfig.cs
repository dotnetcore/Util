using Autofac;
using Util.Contexts;
using Util.DependencyInjection;
using Util.Domains.Sessions;
using Util.Samples.Webs.Controllers;

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

            builder.RegisterType<A>().Named<IGet>( "a" ).InstancePerLifetimeScope();
            builder.RegisterType<B>().Named<IGet>( "b" ).InstancePerLifetimeScope();

        }
        
        /// <summary>
        /// 加载基础设施
        /// </summary>
        private void LoadInfrastructure( ContainerBuilder builder ) {
            builder.AddSingleton<IContext, WebContext>();
            builder.AddScoped<ISession, NullSession>();
        }
    }
}
