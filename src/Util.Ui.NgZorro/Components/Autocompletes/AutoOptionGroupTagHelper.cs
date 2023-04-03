using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Autocompletes.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Autocompletes {
    /// <summary>
    /// 自动完成选项组,生成的标签为&lt;nz-auto-optgroup&gt;&lt;/nz-auto-optgroup&gt;,放入自动完成组件 util-autocomplete 中使用
    /// </summary>
    [HtmlTargetElement( "util-auto-option-group" )]
    public class AutoOptionGroupTagHelper : AngularTagHelperBase {
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
            return new AutoOptionGroupRender( config );
        }
    }
}