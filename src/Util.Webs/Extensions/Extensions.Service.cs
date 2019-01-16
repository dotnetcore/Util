using Microsoft.Extensions.DependencyInjection;
using Util.Webs.Razors;

namespace Util.Webs.Extensions {
    /// <summary>
    /// 服务扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 注册Razor静态Html生成器
        /// </summary>
        /// <param name="services">服务集合</param>
        public static IServiceCollection AddRazorHtml( this IServiceCollection services ) {
            services.AddScoped<IRouteAnalyzer, RouteAnalyzer>();
            services.AddScoped<IRazorHtmlGenerator, DefaultRazorHtmlGenerator>();
            return services;
        }
    }
}
