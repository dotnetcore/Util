using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material.SideNavs.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.SideNavs.TagHelpers {
    /// <summary>
    /// 侧边栏导航
    /// </summary>
    [HtmlTargetElement( "util-sidenav" )]
    public class SideNavTagHelper : TagHelperBase {
        /// <summary>
        /// 标识，指向模板引用变量，而不是Id属性
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new SideNavRender( new Config( context ) );
        }
    }
}