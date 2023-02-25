using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Util.Generators.Configuration;
using Util.Generators.Contexts;
using Util.Generators.Resources;
using Util.Generators.Templates;
using Util.Infrastructure;

namespace Util.Generators.Razor.Infrastructure {
    /// <summary>
    /// Razor生成服务注册器
    /// </summary>
    public class RazorGeneratorServiceRegistrar : IServiceRegistrar {
        /// <summary>
        /// 获取服务名
        /// </summary>
        public static string ServiceName => "Util.Generators.Razor.Infrastructure.RazorGeneratorServiceRegistrar";

        /// <summary>
        /// 排序号
        /// </summary>
        public int OrderId => 10010;

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
                services.TryAddSingleton<IGenerator, Generator>();
                services.TryAddSingleton<IGeneratorContextBuilder, GeneratorContextBuilder>();
                services.TryAddSingleton<IGeneratorOptionsBuilder, GeneratorOptionsBuilder>();
                services.TryAddSingleton<ITemplateFinder, RazorTemplateFinder>();
                services.TryAddSingleton<ITemplateFilterManager, TemplateFilterManager>();
                services.TryAddSingleton<IResourceManager, ResourceManager>();
            } );
            AddFilters();
            return null;
        }

        /// <summary>
        /// 添加模板过滤器
        /// </summary>
        private void AddFilters() {
            TemplateFilterManager.AddFilter( new PartTemplateFilter() );
        }
    }
}
