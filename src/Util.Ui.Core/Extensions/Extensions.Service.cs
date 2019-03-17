using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Util.Ui.Pages;

namespace Util.Ui.Extensions
{
    /// <summary>
    /// UI扩展
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 注册UI操作
        /// </summary>
        /// <param name="services">服务集合</param>
        public static void AddUi(this IServiceCollection services)
        {
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new RelativePathViewLocationExpander());
            });
        }
    }
}
