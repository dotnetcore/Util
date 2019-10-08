using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Material.Dialogs.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Dialogs.TagHelpers {
    /// <summary>
    /// 弹出层内容
    /// </summary>
    [HtmlTargetElement( "util-dialog-content" )]
    public class DialogContentTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new DialogContentRender( new Config( context ) );
        }
    }
}