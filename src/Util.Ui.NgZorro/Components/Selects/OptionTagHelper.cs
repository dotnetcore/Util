using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Selects.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Selects {
    /// <summary>
    /// 下拉选项,生成的标签为&lt;nz-option&gt;&lt;/nz-option&gt;,放入下拉选择器 util-select 中使用
    /// </summary>
    [HtmlTargetElement( "util-option" )]
    public class OptionTagHelper : AngularTagHelperBase {
        /// <summary>
        /// [nzDisabled],是否禁用
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// [nzDisabled],是否禁用
        /// </summary>
        public string BindDisabled { get; set; }
        /// <summary>
        /// nzLabel,标签
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// [nzLabel],标签
        /// </summary>
        public string BindLabel { get; set; }
        /// <summary>
        /// nzValue,nz-select 中 ngModel 的值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// [nzValue],nz-select 中 ngModel 的值
        /// </summary>
        public string BindValue { get; set; }
        /// <summary>
        /// [nzHide],是否隐藏
        /// </summary>
        public bool Hide { get; set; }
        /// <summary>
        /// [nzHide],是否隐藏
        /// </summary>
        public string BindHide { get; set; }
        /// <summary>
        /// [nzCustomContent],是否自定义在下拉菜单中的Template内容，当为 true 时，nz-option 包裹的内容将直接渲染在下拉菜单中,默认值: false
        /// </summary>
        public bool CustomContent { get; set; }
        /// <summary>
        /// [nzCustomContent],是否自定义在下拉菜单中的Template内容，当为 true 时，nz-option 包裹的内容将直接渲染在下拉菜单中,默认值: false
        /// </summary>
        public string BindCustomContent { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new OptionRender( config );
        }
    }
}