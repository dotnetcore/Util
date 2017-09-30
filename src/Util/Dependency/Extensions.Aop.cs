using AspectCore.DynamicProxy;
using AspectCore.Extensions.AspectScope;
using Autofac;

namespace Util.Dependency {
	/// <summary>
    /// AspectCore扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 启用Aop作用域
        /// </summary>
	    public static void EnableAspectScoped( this ContainerBuilder builder ) {
            builder.AddSingleton<IAspectScheduler, ScopeAspectScheduler>();
            builder.AddSingleton<IAspectBuilderFactory, ScopeAspectBuilderFactory>();
            builder.AddScoped<IAspectContextFactory, ScopeAspectContextFactory>();
        }
	}
}
