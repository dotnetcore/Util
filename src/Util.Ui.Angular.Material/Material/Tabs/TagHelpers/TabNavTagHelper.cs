using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Tabs.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Tabs.TagHelpers {
    /// <summary>
    /// 导航选项卡组
    /// </summary>
    [HtmlTargetElement( "util-nav-tabs" )]
    public class TabNavTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 背景色
        /// </summary>
        public Color BackgroundColor { get; set; }
        /// <summary>
        /// 主题色
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new TabNavRender( new Config( context ) );
        }
    }
}