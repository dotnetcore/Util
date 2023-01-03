using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Checkboxes.Helpers;
using Util.Ui.NgZorro.Components.Switches.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Switches {
    /// <summary>
    /// 开关,生成的标签为&lt;nz-switch>&lt;/nz-switch>
    /// </summary>
    [HtmlTargetElement( "util-switch" )]
    public class SwitchTagHelper : FormControlTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private Config _config;
        /// <summary>
        /// name,名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// [name],名称
        /// </summary>
        public string BindName { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用
        /// </summary>
        public string BindDisabled { get; set; }
        /// <summary>
        /// nzCheckedChildren,选中时显示的标签内容,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string CheckedChildren { get; set; }
        /// <summary>
        /// [nzCheckedChildren],选中时显示的标签内容,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string BindCheckedChildren { get; set; }
        /// <summary>
        /// nzUnCheckedChildren,未选中时显示的标签内容,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string UncheckedChildren { get; set; }
        /// <summary>
        /// [nzUnCheckedChildren],未选中时显示的标签内容,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string BindUncheckedChildren { get; set; }
        /// <summary>
        /// nzSize,可选值: 'small' | 'default',默认值: 'default'
        /// </summary>
        public SwitchSize Size { get; set; }
        /// <summary>
        /// [nzSize],可选值: 'small' | 'default',默认值: 'default'
        /// </summary>
        public string BindSize { get; set; }
        /// <summary>
        /// [nzLoading],加载状态,类型: boolean
        /// </summary>
        public string Loading { get; set; }
        /// <summary>
        /// [nzControl],是否完全由用户控制状态,默认值: false
        /// </summary>
        public bool Control { get; set; }
        /// <summary>
        /// [nzControl],是否完全由用户控制状态,默认值: false
        /// </summary>
        public string BindControl { get; set; }
        /// <summary>
        /// *nzSpaceItem,值为true时设置为间距项,放入 nz-space 组件中使用
        /// </summary>
        public bool SpaceItem { get; set; }
        /// <summary>
        /// (click),单击事件
        /// </summary>
        public string OnClick { get; set; }

        /// <inheritdoc />
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config = new Config( context, output );
            var service = new CheckboxService( _config );
            service.Init();
        }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new SwitchRender( _config );
        }
    }
}
