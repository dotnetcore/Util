using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Material.SideNavs.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.SideNavs.TagHelpers {
    /// <summary>
    /// 侧边栏导航容器
    /// </summary>
    [HtmlTargetElement( "util-sidenav-container" )]
    public class SideNavContainerTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 全屏
        /// </summary>
        public bool Fullscreen { get; set; }
        /// <summary>
        /// 自动调整大小
        /// </summary>
        public bool AutoSize { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new SideNavContainerRender( new Config( context ) );
        }
    }
}