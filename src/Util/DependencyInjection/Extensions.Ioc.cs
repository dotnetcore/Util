using Autofac;
using Autofac.Builder;

namespace Util.DependencyInjection {
	/// <summary>
    /// Autofac扩展
    /// </summary>
    public static partial class Extensions {
	    /// <summary>
	    /// 注册服务，生命周期为 InstancePerLifetimeScope(每个请求一个实例)
	    /// </summary>
	    /// <typeparam name="TService">接口类型</typeparam>
	    /// <typeparam name="TImplementation">实现类型</typeparam>
	    /// <param name="builder">容器生成器</param>
	    public static IRegistrationBuilder<TImplementation, ConcreteReflectionActivatorData, SingleRegistrationStyle> AddScoped<TService, TImplementation>( this ContainerBuilder builder ) where TService : class where TImplementation : class, TService {
	        return builder.RegisterType<TImplementation>().As<TService>().InstancePerLifetimeScope();
	    }

        /// <summary>
        /// 注册服务，生命周期为 SingleInstance（单例）
        /// </summary>
        /// <typeparam name="TService">接口类型</typeparam>
        /// <typeparam name="TImplementation">实现类型</typeparam>
        /// <param name="builder">容器生成器</param>
        public static IRegistrationBuilder<TImplementation, ConcreteReflectionActivatorData, SingleRegistrationStyle> AddSingleton<TService, TImplementation>( this ContainerBuilder builder ) where TService : class where TImplementation : class, TService {
            return builder.RegisterType<TImplementation>().As<TService>().SingleInstance();
        }
    }
}
