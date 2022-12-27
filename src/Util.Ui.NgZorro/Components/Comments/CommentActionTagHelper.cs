using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Comments.Renders;

namespace Util.Ui.NgZorro.Components.Comments {
    /// <summary>
    /// 评论操作,生成的标签为&lt;nz-comment-action>&lt;/nz-comment-action>
    /// </summary>
    [HtmlTargetElement( "util-comment-action" )]
    public class CommentActionTagHelper : AngularTagHelperBase {
        /// <inheritdoc />
        protected override IHtmlContent GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new CommentActionRender( config );
        }
    }
}