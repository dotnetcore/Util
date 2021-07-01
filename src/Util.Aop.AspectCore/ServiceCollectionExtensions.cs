using AspectCore.DynamicProxy;
using AspectCore.DynamicProxy.Parameters;
using AspectCore.Extensions.AspectScope;
using AspectCore.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Util.Aop {
    /// <summary>
    /// 服务扩展
    /// </summary>
    public static class ServiceCollectionExtensions {
        /// <summary>
        /// 注册AspectCore Aop服务
        /// </summary>
        /// <param name="services">服务集合</param>
        public static IServiceCollection AddAop( this IServiceCollection services ) {
            RegisterParameterAspect( services );
            RegisterAspectScoped( services );
            return services;
        }

        /// <summary>
        /// 注册参数拦截器
        /// </summary>
        private static void RegisterParameterAspect( IServiceCollection services ) {
            services.ConfigureDynamicProxy( t => t.EnableParameterAspect() );
        }

        /// <summary>
        /// 注册拦截作用域
        /// </summary>
        private static void RegisterAspectScoped( IServiceCollection services ) {
            services.AddScoped<IAspectScheduler, ScopeAspectScheduler>();
            services.AddScoped<IAspectBuilderFactory, ScopeAspectBuilderFactory>();
            services.AddScoped<IAspectContextFactory, ScopeAspectContextFactory>();
        }
    }
}
