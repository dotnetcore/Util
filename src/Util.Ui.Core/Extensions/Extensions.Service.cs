using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Util.Ui.Pages;

namespace Util.Ui.Extensions {
    /// <summary>
    /// Ui服务扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 注册Razor相对路径视图位置扩展
        /// </summary>
        /// <param name="services">服务集合</param>
        public static void AddRazorViewLocationExpander( this IServiceCollection services ) {
            services.Configure<RazorViewEngineOptions>( options => {
                options.ViewLocationExpanders.Add( new RelativePathViewLocationExpander() );
            } );
        }
    }
}
