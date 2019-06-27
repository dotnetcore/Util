using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Menus.Renders;

namespace Util.Ui.Zorro.Menus {
    /// <summary>
    /// 菜单项
    /// </summary>
    [HtmlTargetElement( "util-menu-item")]
    public class MenuItemTagHelper : AngularTagHelperBase {
        /// <summary>
        /// [nzDisabled],是否禁用，默认值：false
        /// </summary>
        public string Disabled { get; set; }
        /// <summary>
        /// [nzSelected],是否被选中，默认值：false
        /// </summary>
        public string Selected { get; set; }
        /// <summary>
        /// (click),单击事件处理函数
        /// </summary>
        public string OnClick { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new MenuItemRender( new Config( context ) );
        }
    }
}