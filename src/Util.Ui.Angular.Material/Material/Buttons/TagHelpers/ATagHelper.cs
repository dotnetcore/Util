using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Material.Buttons.Renders;
using Util.Ui.Material.Enums;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Buttons.TagHelpers {
    /// <summary>
    /// 链接
    /// </summary>
    [HtmlTargetElement( "util-a" )]
    public class ATagHelper : AngularTagHelperBase {
        /// <summary>
        /// 文本
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 文本属性绑定
        /// </summary>
        public string BindText { get; set; }
        /// <summary>
        /// 样式
        /// </summary>
        public ButtonStyle Styles { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public Color Color { get; set; }
        /// <summary>
        /// 禁用
        /// </summary>
        public string Disabled { get; set; }
        /// <summary>
        /// 提示
        /// </summary>
        public string Tooltip { get; set; }
        /// <summary>
        /// 路由地址字符串
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
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new AnchorRender( new Config( context ) );
        }
    }
}
