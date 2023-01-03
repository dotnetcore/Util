using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Collapses.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Collapses {
    /// <summary>
    /// 折叠面板,生成的标签为&lt;nz-collapse-panel>&lt;/nz-collapse-panel>
    /// </summary>
    [HtmlTargetElement( "util-collapse-panel" )]
    public class CollapsePanelTagHelper : AngularTagHelperBase {
        /// <summary>
        /// [nzDisabled],是否禁用,默认值: false
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用,默认值: false
        /// </summary>
        public string BindDisabled { get; set; }
        /// <summary>
        /// nzHeader,面板头内容,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string Header { get; set; }
        /// <summary>
        /// [nzHeader],面板头内容,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string BindHeader { get; set; }
        /// <summary>
        /// nzExpandedIcon,自定义切换图标,类型: string | TemplateRef&lt;void>
        /// </summary>
        public AntDesignIcon ExpandedIcon { get; set; }
        /// <summary>
        /// [nzExpandedIcon],自定义切换图标,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string BindExpandedIcon { get; set; }
        /// <summary>
        /// nzExtra,自定义渲染每个面板右上角的内容,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string Extra { get; set; }
        /// <summary>
        /// [nzExtra],自定义渲染每个面板右上角的内容,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string BindExtra { get; set; }
        /// <summary>
        /// [nzShowArrow],是否显示箭头,默认值: true
        /// </summary>
        public bool ShowArrow { get; set; }
        /// <summary>
        /// [nzShowArrow],是否显示箭头,默认值: true
        /// </summary>
        public string BindShowArrow { get; set; }
        /// <summary>
        /// [nzActive],是否展开面板
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// [nzActive],是否展开面板
        /// </summary>
        public string BindActive { get; set; }
        /// <summary>
        /// [(nzActive)],是否展开面板
        /// </summary>
        public string BindonActive { get; set; }
        /// <summary>
        /// (nzActiveChange),面板展开变化事件,类型: EventEmitter&lt;boolean>
        /// </summary>
        public string OnActiveChange { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new CollapsePanelRender( config );
        }
    }
}