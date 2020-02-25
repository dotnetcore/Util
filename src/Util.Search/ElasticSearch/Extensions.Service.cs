using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Util.Search.ElasticSearch.Configs;
using Util.Search.ElasticSearch.Services;

namespace Util.Search.ElasticSearch {
    /// <summary>
    /// ElasticSearch服务扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 注册ElasticSearch搜索扩展
        /// </summary>
        /// <param name="services">服务集合</param>
        public static void AddElasticSearch( this IServiceCollection services ) {
            services.TryAddSingleton<IConfigProvider, DefaultConfigProvider>();
            services.TryAddSingleton<IElasticSearch, ElasticSearchService>();
        }
    }
}
