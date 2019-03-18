using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Material.SideNavs.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.SideNavs.TagHelpers {
    /// <summary>
    /// 侧边栏内容区域
    /// </summary>
    [HtmlTargetElement( "util-drawer-content" )]
    public class DrawerContentTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new DrawerContentRender( new Config( context ) );
        }
    }
}