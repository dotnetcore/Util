using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.Rendering;
using Util.Helpers;
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
        public static IUiService Angular( this IHtmlHelper helper ) {
            return new UiService( helper,Ioc.Create<HtmlEncoder>() );
        }
    }
}
