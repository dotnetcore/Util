using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Material.Lists.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Lists.TagHelpers {
    /// <summary>
    /// 导航列表
    /// </summary>
    [HtmlTargetElement( "util-nav-list" )]
    public class NavListTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 紧凑模式，列表内容间距变小
        /// </summary>
        public bool Dense { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new NavListRender( new Config( context ) );
        }
    }
}