using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tabs.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Tabs {
    /// <summary>
    /// 标签页子标签,生成的标签为&lt;nz-tab>&lt;/nz-tab>
    /// </summary>
    [HtmlTargetElement( "util-tab" )]
    public class TabTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 扩展属性,是否延迟加载,设置为true则创建ng-template包装内容
        /// </summary>
        public bool Lazy { get; set; }
        /// <summary>
        /// nzTitle,标题,支持i18n
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// [nzTitle],标题,类型: string | TemplateRef&lt;TabTemplateContext>
        /// </summary>
        public string BindTitle { get; set; }
        /// <summary>
        /// [nzForceRender],隐藏时是否强制渲染DOM结构,默认值: false
        /// </summary>
        public bool ForceRender { get; set; }
        /// <summary>
        /// [nzForceRender],隐藏时是否强制渲染DOM结构,默认值: false
        /// </summary>
        public string BindForceRender { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用
        /// </summary>
        public string BindDisabled { get; set; }
        /// <summary>
        /// [nzClosable],是否显示关闭按钮,当父标签页 nz-tabset 的 nzType 为 'editable-card'时可用,默认值: false
        /// </summary>
        public bool Closable { get; set; }
        /// <summary>
        /// [nzClosable],是否显示关闭按钮,当父标签页 nz-tabset 的 nzType 为 'editable-card'时可用,默认值: false
        /// </summary>
        public string BindClosable { get; set; }
        /// <summary>
        /// nzCloseIcon,关闭按钮图标,当父标签页 nz-tabset 的 nzType 为 'editable-card'时可用,类型: string | TemplateRef&lt;void>
        /// </summary>
        public AntDesignIcon CloseIcon { get; set; }
        /// <summary>
        /// [nzCloseIcon],关闭按钮图标,当父标签页 nz-tabset 的 nzType 为 'editable-card'时可用,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string BindCloseIcon { get; set; }
        /// <summary>
        /// (nzClick),单击事件,类型: EventEmitter&lt;void>
        /// </summary>
        public string OnClick { get; set; }
        /// <summary>
        /// (nzContextmenu),右键上下文菜单事件,类型: EventEmitter&lt;MouseEvent>
        /// </summary>
        public string OnContextmenu { get; set; }
        /// <summary>
        /// (nzSelect),选中事件,类型: EventEmitter&lt;void>
        /// </summary>
        public string OnSelect { get; set; }
        /// <summary>
        /// (nzDeselect),取消选中事件,类型: EventEmitter&lt;void>
        /// </summary>
        public string OnDeselect { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new TabRender( config );
        }
    }
}