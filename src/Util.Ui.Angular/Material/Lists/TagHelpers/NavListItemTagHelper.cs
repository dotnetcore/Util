using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material.Lists.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Lists.TagHelpers {
    /// <summary>
    /// 导航列表项
    /// </summary>
    [HtmlTargetElement( "util-nav-list-item" )]
    public class NavListItemTagHelper : TagHelperBase {
        /// <summary>
        /// ngFor指令，范例：let item of items
        /// </summary>
        public string NgFor { get; set; }
        /// <summary>
        /// href,链接字符串，范例：http://a.com
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// routerLink,路由链接字符串
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// [routerLink],路由链接属性绑定
        /// </summary>
        public string BindLink { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new NavListItemRender( new Config( context ) );
        }
    }
}