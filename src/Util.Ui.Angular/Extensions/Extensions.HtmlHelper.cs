using Microsoft.AspNetCore.Mvc.Rendering;
using Util.Ui.Services;

namespace Util.Ui.Extensions {
    /// <summary>
    /// HtmlHelper扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// Angular组件服务
        /// </summary>
        /// <param name="helper">HtmlHelper</param>
        public static IUiService<TModel> Ui<TModel>( this IHtmlHelper<TModel> helper ) {
            return new UiService<TModel>( helper );
        }
    }
}
