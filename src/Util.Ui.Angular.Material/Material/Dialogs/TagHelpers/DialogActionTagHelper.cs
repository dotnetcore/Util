using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Material.Dialogs.Renders;
using Util.Ui.Material.Enums;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Dialogs.TagHelpers {
    /// <summary>
    /// 弹出层操作
    /// </summary>
    [HtmlTargetElement( "util-dialog-actions" )]
    public class DialogActionTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 对齐方式
        /// </summary>
        public Align Align { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new DialogActionRender( new Config( context ) );
        }
    }
}