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

        /// <summary>
        /// 添加Razor页面约定
        /// </summary>
        /// <param name="builder">Mvc生成器</param>
        public static void AddRazorPageConventions( this IMvcBuilder builder ) {
            builder.AddRazorPagesOptions( options => {
                options.Conventions.Add( new ViewPageRouteConvention() );
                options.Conventions.AddFolderApplicationModelConvention( "/", model => model.Filters.Add( new GeneratePageFilter() ) );
            } );
        }
    }
}
