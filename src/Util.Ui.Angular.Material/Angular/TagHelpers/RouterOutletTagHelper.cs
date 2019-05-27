using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Angular.Renders;
using Util.Ui.Configs;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Angular.TagHelpers {
    /// <summary>
    /// router-outlet路由出口
    /// </summary>
    [HtmlTargetElement( "util-router-outlet" )]
    public class RouterOutletTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new RouterOutletRender( new Config( context ) );
        }
    }
}