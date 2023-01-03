using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Menus.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Menus {
    /// <summary>
    /// 菜单,生成的标签为&lt;ul nz-menu&gt;&lt;/ul&gt;
    /// </summary>
    [HtmlTargetElement( "util-menu")]
    public class MenuTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzMode,菜单模式,支持垂直、水平、和内嵌模式三种,可选值: 'vertical' | 'horizontal' | 'inline',默认值: 'vertical'
        /// </summary>
        public MenuMode Mode { get; set; }
        /// <summary>
        /// [nzMode],菜单模式,支持垂直、水平、和内嵌模式三种,可选值: 'vertical' | 'horizontal' | 'inline',默认值: 'vertical'
        /// </summary>
        public string BindMode { get; set; }
        /// <summary>
        /// [nzSelectable],是否允许选中，默认值：true
        /// </summary>
        public bool Selectable { get; set; }
        /// <summary>
        /// [nzSelectable],是否允许选中，默认值：true
        /// </summary>
        public string BindSelectable { get; set; }
        /// <summary>
        /// nzTheme,主题颜色,可选值: 'light' | 'dark'
        /// </summary>
        public MenuTheme Theme { get; set; }
        /// <summary>
        /// [nzTheme],主题颜色,可选值: 'light' | 'dark'
        /// </summary>
        public string BindTheme { get; set; }
        /// <summary>
        /// [nzInlineCollapsed],内嵌模式时菜单是否折叠
        /// </summary>
        public bool InlineCollapsed { get; set; }
        /// <summary>
        /// [nzInlineCollapsed],内嵌模式时菜单是否折叠
        /// </summary>
        public string BindInlineCollapsed { get; set; }
        /// <summary>
        /// [nzInlineIndent],内嵌模式时菜单缩进宽度，默认值：24
        /// </summary>
        public int InlineIndent { get; set; }
        /// <summary>
        /// [nzInlineIndent],内嵌模式时菜单缩进宽度，默认值：24
        /// </summary>
        public string BindInlineIndent { get; set; }
        /// <summary>
        /// (nzClick),单击菜单项事件处理函数
        /// </summary>
        public string OnClick { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new MenuRender( config );
        }
    }
}