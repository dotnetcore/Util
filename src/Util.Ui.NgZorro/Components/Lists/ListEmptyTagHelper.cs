using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Lists.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Lists {
    /// <summary>
    /// 列表空内容,生成的标签为&lt;nz-list-empty>&lt;/nz-list-empty>
    /// </summary>
    [HtmlTargetElement( "util-list-empty" )]
    public class ListEmptyTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzNoResult,空内容显示文本
        /// </summary>
        public string NoResult { get; set; }
        /// <summary>
        /// [nzNoResult],空内容显示文本
        /// </summary>
        public string BindNoResult { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new ListEmptyRender( config );
        }
    }
}