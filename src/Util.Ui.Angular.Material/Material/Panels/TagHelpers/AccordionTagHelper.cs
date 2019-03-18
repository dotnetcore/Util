using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Panels.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Panels.TagHelpers {
    /// <summary>
    /// 手风琴
    /// </summary>
    [HtmlTargetElement( "util-accordion" )]
    public class AccordionTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 允许多个面板同时处于展开状态
        /// </summary>
        public bool Multiple { get; set; }
        /// <summary>
        /// 显示模式，设置为Flat则展开的面板间没有间距
        /// </summary>
        public AccordionDisplayMode DisplayMode { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new AccordionRender( new Config( context ) );
        }
    }
}