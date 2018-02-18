using Microsoft.AspNetCore.Razor.TagHelpers;
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
    public class MenuItemTagHelper : TagHelperBase {
        /// <summary>
        /// 文本
        /// </summary>
        public string Text { get; set; }
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
        /// 路由链接地址
        /// </summary>
        public string Link { get; set; }
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