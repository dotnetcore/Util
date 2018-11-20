using System;
using AspectCore.Configuration;
using AspectCore.DynamicProxy;
using AspectCore.DynamicProxy.Parameters;
using AspectCore.Extensions.AspectScope;
using AspectCore.Extensions.Autofac;
using Autofac;
using Util.Helpers;

namespace Util.Dependency {
    /// <summary>
    /// AspectCore扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 启用Aop
        /// </summary>
        /// <param name="builder">容器生成器</param>
        /// <param name="configAction">Aop配置</param>
        public static void EnableAop( this ContainerBuilder builder,Action<IAspectConfiguration> configAction = null ) {
            builder.RegisterDynamicProxy( config => {
                config.EnableParameterAspect();
                config.NonAspectPredicates.Add( t => Reflection.GetTopBaseType( t.DeclaringType ).SafeString() == "Microsoft.EntityFrameworkCore.DbContext" );
                configAction?.Invoke( config );
            } );
            builder.EnableAspectScoped();
        }

        /// <summary>
        /// 启用Aop作用域
        /// </summary>
	    public static void EnableAspectScoped( this ContainerBuilder builder ) {
            builder.AddScoped<IAspectScheduler, ScopeAspectScheduler>();
            builder.AddScoped<IAspectBuilderFactory, ScopeAspectBuilderFactory>();
            builder.AddScoped<IAspectContextFactory, ScopeAspectContextFactory>();
        }
    }
}
