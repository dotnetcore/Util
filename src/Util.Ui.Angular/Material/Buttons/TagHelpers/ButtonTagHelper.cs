using Util.Ui.Configs;
using Util.Ui.Material.Buttons.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Buttons.TagHelpers {
    /// <summary>
    /// 按钮TagHelper
    /// </summary>
    public class ButtonTagHelper : ButtonTagHelperBase {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new ButtonRender( new Config( context.Attributes, context.OtherAttributes, context.Content ) );
        }
    }
}
