using System;
using AspectCore.Configuration;
using AspectCore.DynamicProxy;
using AspectCore.DynamicProxy.Parameters;
using AspectCore.Extensions.AspectScope;
using AspectCore.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util.Configs;
using Util.Helpers;

namespace Util.Aop {
    /// <summary>
    /// Aop配置项扩展
    /// </summary>
    public class AopOptionsExtension : OptionsExtensionBase {
        /// <summary>
        /// Aop配置
        /// </summary>
        private readonly Action<IAspectConfiguration> _configure;

        /// <summary>
        /// 初始化Aop配置项扩展
        /// </summary>
        /// <param name="configure">Aop配置</param>
        public AopOptionsExtension( Action<IAspectConfiguration> configure ) {
            _configure = configure;
        }

        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="hostBuilder">主机生成器</param>
        public override void Config( IHostBuilder hostBuilder ) {
            hostBuilder.UseServiceProviderFactory( new DynamicProxyServiceProviderFactory() );
        }

        /// <inheritdoc />
        public override void ConfigureServices( HostBuilderContext context, IServiceCollection services ) {
            ConfigureDynamicProxy( services );
            RegisterAspectScoped( services );
        }

        /// <summary>
        /// 配置拦截器
        /// </summary>
        private void ConfigureDynamicProxy( IServiceCollection services ) {
            services.ConfigureDynamicProxy( config => {
                config.EnableParameterAspect();
                config.NonAspectPredicates.Add( t => Reflection.GetTopBaseType( t.DeclaringType ).SafeString() == "Microsoft.EntityFrameworkCore.DbContext" );
                config.NonAspectPredicates.Add( t => t.DeclaringType.SafeString().Contains( "Xunit.DependencyInjection.ITestOutputHelperAccessor" ) );
                _configure?.Invoke( config );
            } );
        }

        /// <summary>
        /// 注册拦截作用域
        /// </summary>
        private void RegisterAspectScoped( IServiceCollection services ) {
            services.AddScoped<IAspectScheduler, ScopeAspectScheduler>();
            services.AddScoped<IAspectBuilderFactory, ScopeAspectBuilderFactory>();
            services.AddScoped<IAspectContextFactory, ScopeAspectContextFactory>();
        }
    }
}
