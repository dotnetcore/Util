using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Menus.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Menus {
    /// <summary>
    /// 菜单项,生成的标签为&lt;li nz-menu-item&gt;&lt;/li&gt;
    /// </summary>
    [HtmlTargetElement( "util-menu-item")]
    public class MenuItemTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 扩展属性,内容文本,支持i18n
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 扩展属性,是否显示update文本,默认文本为'Update',i18n文本为'util.update'
        /// </summary>
        public bool TextUpdate { get; set; }
        /// <summary>
        /// 扩展属性,是否显示delete文本,默认文本为'Delete',i18n文本为'util.delete'
        /// </summary>
        public bool TextDelete { get; set; }
        /// <summary>
        /// 扩展属性,是否显示detail文本,默认文本为'Detail',i18n文本为'util.detail'
        /// </summary>
        public bool TextDetail { get; set; }
        /// <summary>
        /// 扩展属性,是否显示enable文本,默认文本为'Enable',i18n文本为'util.enable'
        /// </summary>
        public bool TextEnable { get; set; }
        /// <summary>
        /// 扩展属性,是否显示disable文本,默认文本为'Disable',i18n文本为'util.disable'
        /// </summary>
        public bool TextDisable { get; set; }
        /// <summary>
        /// 扩展属性,设置图标
        /// </summary>
        public AntDesignIcon Icon { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用
        /// </summary>
        public string BindDisabled { get; set; }
        /// <summary>
        /// [nzSelected],是否被选中
        /// </summary>
        public bool Selected { get; set; }
        /// <summary>
        /// [nzSelected],是否被选中
        /// </summary>
        public string BindSelected { get; set; }
        /// <summary>
        /// [nzDanger],是否危险状态
        /// </summary>
        public bool Danger { get; set; }
        /// <summary>
        /// [nzDanger],是否危险状态
        /// </summary>
        public string BindDanger { get; set; }
        /// <summary>
        /// [nzMatchRouter],是否根据 routerLink 自动设置选中状态
        /// </summary>
        public bool MatchRouter { get; set; }
        /// <summary>
        /// [nzMatchRouter],是否根据 routerLink 自动设置选中状态
        /// </summary>
        public string BindMatchRouter { get; set; }
        /// <summary>
        /// [nzMatchRouterExact],是否路由完整精确匹配
        /// </summary>
        public bool MatchRouterExact { get; set; }
        /// <summary>
        /// [nzMatchRouterExact],是否路由完整精确匹配
        /// </summary>
        public string BindMatchRouterExact { get; set; }
        /// <summary>
        /// (click),单击事件处理函数
        /// </summary>
        public string OnClick { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new MenuItemRender( config );
        }
    }
}