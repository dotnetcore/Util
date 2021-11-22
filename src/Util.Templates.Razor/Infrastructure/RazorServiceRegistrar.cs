using System;
using Microsoft.Extensions.Configuration;
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
        /// 获取标识
        /// </summary>
        public static int GetId() => 610;

        /// <summary>
        /// 标识
        /// </summary>
        public int Id => GetId();

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled => ServiceRegistrarConfig.Instance.IsEnabled( GetId() );

        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="configuration">配置</param>
        /// <param name="finder">类型查找器</param>
        public Action Register( IServiceCollection services, IConfiguration configuration, ITypeFinder finder ) {
            RegisterDependency( services );
            RegisterAssemblyReference( finder );
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
