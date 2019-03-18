using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Material.Lists.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Lists.TagHelpers {
    /// <summary>
    /// 导航列表项，该标签应放到 util-nav-list 中
    /// </summary>
    [HtmlTargetElement( "util-nav-list-item" )]
    public class NavListItemTagHelper : AngularTagHelperBase {
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
        /// routerLinkActive,路由链接激活class
        /// </summary>
        public string Active { get; set; }
        /// <summary>
        /// [routerLinkActive],路由链接激活绑定
        /// </summary>
        public string BindActive { get; set; }
        /// <summary>
        /// 路由激活状态是否精确匹配
        /// </summary>
        public bool Exact { get; set; }
        /// <summary>
        /// 单击事件处理函数,范例：handle()
        /// </summary>
        public string OnClick { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new NavListItemRender( new Config( context ) );
        }
    }
}