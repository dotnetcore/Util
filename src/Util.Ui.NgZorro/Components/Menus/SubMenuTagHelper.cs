using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Menus.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Menus {
    /// <summary>
    /// 子菜单,生成的标签为&lt;li nz-submenu&gt;&lt;ul&gt;&lt;/ul&gt;&lt;/li&gt;
    /// </summary>
    [HtmlTargetElement( "util-submenu" )]
    public class SubMenuTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzTitle,标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// [nzTitle],标题
        /// </summary>
        public string BindTitle { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用
        /// </summary>
        public string BindDisabled { get; set; }
        /// <summary>
        /// nzIcon,图标
        /// </summary>
        public AntDesignIcon Icon { get; set; }
        /// <summary>
        /// [nzIcon],图标
        /// </summary>
        public string BindIcon { get; set; }
        /// <summary>
        /// [nzOpen],是否展开
        /// </summary>
        public bool Open { get; set; }
        /// <summary>
        /// [nzOpen],是否展开
        /// </summary>
        public string BindOpen { get; set; }
        /// <summary>
        /// [(nzOpen)],是否展开
        /// </summary>
        public string BindonOpen { get; set; }
        /// <summary>
        /// nzMenuClassName,自定义子菜单容器类名
        /// </summary>
        public string MenuClassName { get; set; }
        /// <summary>
        /// [nzMenuClassName],自定义子菜单容器类名
        /// </summary>
        public string BindMenuClassName { get; set; }
        /// <summary>
        /// (nzOpenChange),展开变更事件
        /// </summary>
        public string OnOpenChange { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new SubMenuRender( config );
        }
    }
}