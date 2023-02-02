using System;
using Microsoft.Extensions.DependencyInjection;
using RazorEngineCore;
using Util.Infrastructure;
using Util.Reflections;
using Util.Templates.Razor;
using Util.Templates.Razor.Filters;

namespace Util.Templates.Infrastructure {
    /// <summary>
    /// Razor模板引擎服务注册器
    /// </summary>
    public class RazorServiceRegistrar : IServiceRegistrar {
        /// <summary>
        /// 获取服务名
        /// </summary>
        public static string ServiceName => "Util.Templates.Infrastructure.RazorServiceRegistrar";

        /// <summary>
        /// 排序号
        /// </summary>
        public int OrderId => 610;

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled => ServiceRegistrarConfig.IsEnabled( ServiceName );

        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="serviceContext">服务上下文</param>
        public Action Register( ServiceContext serviceContext ) {
            serviceContext.HostBuilder.ConfigureServices( ( context, services ) => {
                RegisterDependency( services );
            } );
            RegisterAssemblyReference( serviceContext.TypeFinder );
            RegisterFilters();
            return null;
        }

        /// <summary>
        /// 注册依赖
        /// </summary>
        private void RegisterDependency( IServiceCollection services ) {
            services.AddSingleton<IRazorEngine, RazorEngine>();
            services.AddSingleton<ITemplateEngine, RazorTemplateEngine>();
            services.AddSingleton<IRazorTemplateEngine, RazorTemplateEngine>();
        }

        /// <summary>
        /// 注册程序集引用
        /// </summary>
        private void RegisterAssemblyReference( ITypeFinder finder ) {
            RazorTemplateEngine.AddAssemblyReference( "System.Collections" );
            if( !( finder is AppDomainTypeFinder typeFinder ) )
                return;
            typeFinder.GetAssemblies().ForEach( RazorTemplateEngine.AddAssemblyReference );
        }

        /// <summary>
        /// 注册模板过滤器
        /// </summary>
        private void RegisterFilters() {
            RazorTemplateEngine.AddFilter( new ModelFilter() );
            RazorTemplateEngine.AddFilter( new PartialAsyncFilter() );
        }
    }
}
