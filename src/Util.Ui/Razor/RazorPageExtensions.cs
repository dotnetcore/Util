using Microsoft.Extensions.DependencyInjection;

namespace Util.Ui.Razor {
    /// <summary>
    /// Razor页面扩展
    /// </summary>
    public static class RazorPageExtensions {
        /// <summary>
        /// 添加约定
        /// </summary>
        /// <param name="builder">mvc生成器</param>
        public static IMvcBuilder AddConventions( this IMvcBuilder builder ) {
            return builder.AddRazorPagesOptions( options => {
                options.Conventions.Add( new PageRouteConvention() );
                options.Conventions.AddFolderApplicationModelConvention( "/", model => model.Filters.Add( new GenerateHtmlFilter() ) );
            } );
        }
    }
}
