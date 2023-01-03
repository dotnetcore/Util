using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Selects.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Selects {
    /// <summary>
    /// 下拉选项组,生成的标签为&lt;nz-option-group&gt;&lt;/nz-option-group&gt;,放入下拉选择器 util-select 中使用
    /// </summary>
    [HtmlTargetElement( "util-option-group" )]
    public class OptionGroupTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzLabel,组名
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// [nzLabel],组名
        /// </summary>
        public string BindLabel { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new OptionGroupRender( config );
        }
    }
}