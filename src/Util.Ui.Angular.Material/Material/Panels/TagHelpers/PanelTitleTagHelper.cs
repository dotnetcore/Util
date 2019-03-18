using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Material.Panels.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Panels.TagHelpers {
    /// <summary>
    /// 面板标题
    /// </summary>
    [HtmlTargetElement( "util-panel-title" )]
    public class PanelTitleTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new PanelTitleRender( new Config( context ) );
        }
    }
}