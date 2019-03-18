using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Material.Menus.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Menus.TagHelpers {
    /// <summary>
    /// 菜单项
    /// </summary>
    [HtmlTargetElement( "util-menu-item" )]
    public class MenuItemTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 标签
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// Material图标
        /// </summary>
        public MaterialIcon MaterialIcon { get; set; }
        /// <summary>
        /// Font Awesome图标
        /// </summary>
        public FontAwesomeIcon FontAwesomeIcon { get; set; }
        /// <summary>
        /// 禁用
        /// </summary>
        public string Disabled { get; set; }
        /// <summary>
        /// 路由地址
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// 路由地址表达式[routerLink],范例：['edit',row.id]
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
        /// 查询参数表达式，范例：{id:1}
        /// </summary>
        public string QueryParams { get; set; }
        /// <summary>
        /// 单击事件处理函数,范例：handle()
        /// </summary>
        public string OnClick { get; set; }
        /// <summary>
        /// 子菜单标识
        /// </summary>
        public string MenuId { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new MenuItemRender( new Config( context ) );
        }
    }
}