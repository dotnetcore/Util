using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Menus.Renders;

namespace Util.Ui.Zorro.Menus {
    /// <summary>
    /// 菜单
    /// </summary>
    [HtmlTargetElement( "util-menu")]
    public class MenuTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzMode,菜单模式
        /// </summary>
        public MenuMode Mode { get; set; }
        /// <summary>
        /// [nzSelectable],是否允许选中，默认值：true
        /// </summary>
        public bool Selectable { get; set; }
        /// <summary>
        /// nzTheme,主题颜色
        /// </summary>
        public MenuTheme Theme { get; set; }
        /// <summary>
        /// [nzInlineCollapsed],内联模式时菜单是否折叠状态
        /// </summary>
        public bool InlineCollapsed { get; set; }
        /// <summary>
        /// [nzInlineIndent],内联模式时菜单缩进宽度，默认值：24
        /// </summary>
        public int InlineIndent { get; set; }
        /// <summary>
        /// (nzClick),单击事件处理函数
        /// </summary>
        public string OnClick { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new MenuRender( new Config( context ) );
        }
    }
}