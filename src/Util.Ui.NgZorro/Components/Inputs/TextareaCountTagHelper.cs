using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Inputs.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Inputs {
    /// <summary>
    /// 文本域计数,生成的标签为&lt;nz-textarea-count&gt;&lt;/nz-textarea-count&gt;
    /// </summary>
    [HtmlTargetElement( "util-textarea-count" )]
    public class TextareaCountTagHelper : AngularTagHelperBase {
        /// <summary>
        /// [nzMaxCharacterCount],文本域数字提示显示的最大值
        /// </summary>
        public int MaxCharacterCount { get; set; }
        /// <summary>
        /// [nzMaxCharacterCount],文本域数字提示显示的最大值
        /// </summary>
        public string BindMaxCharacterCount { get; set; }
        /// <summary>
        /// [nzComputeCharacterCount],文本域数字提示最大值计算函数
        /// </summary>
        public string ComputeCharacterCount { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new TextareaCountRender( config );
        }
    }
}