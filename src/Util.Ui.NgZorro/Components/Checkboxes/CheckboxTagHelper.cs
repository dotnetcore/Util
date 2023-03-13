using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Checkboxes.Helpers;
using Util.Ui.NgZorro.Components.Checkboxes.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Checkboxes {
    /// <summary>
    /// 复选框,生成的标签为&lt;label nz-checkbox&gt;&lt;/label&gt;
    /// </summary>
    [HtmlTargetElement( "util-checkbox" )]
    public class CheckboxTagHelper : FormControlTagHelperBase {
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
        /// [nzAutoFocus],是否自动获取焦点
        /// </summary>
        public bool AutoFocus { get; set; }
        /// <summary>
        /// [nzAutoFocus],是否自动获取焦点
        /// </summary>
        public string BindAutoFocus { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用
        /// </summary>
        public string BindDisabled { get; set; }
        /// <summary>
        /// [nzIndeterminate],是否中间状态
        /// </summary>
        public string Indeterminate { get; set; }
        /// <summary>
        /// nzValue,值,仅与 nz-checkbox-wrapper 的选中回调配合使用
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// [nzValue],值,仅与 nz-checkbox-wrapper 的选中回调配合使用
        /// </summary>
        public string BindValue { get; set; }
        /// <summary>
        /// 标签文本
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// 标签文本
        /// </summary>
        public string BindLabel { get; set; }
        /// <summary>
        /// *nzSpaceItem,值为true时设置为间距项,放入 nz-space 组件中使用
        /// </summary>
        public bool SpaceItem { get; set; }
        /// <summary>
        /// [nzChecked],是否选中
        /// </summary>
        public string Checked { get; set; }
        /// <summary>
        /// (nzCheckedChange),选中状态变更事件
        /// </summary>
        public string OnCheckedChange { get; set; }

        /// <inheritdoc />
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config = new Config( context, output );
            var service = new CheckboxService( _config );
            service.Init();
        }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new CheckboxRender( _config );
        }
    }
}
