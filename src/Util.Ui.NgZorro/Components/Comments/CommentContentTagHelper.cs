using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Comments.Renders;

namespace Util.Ui.NgZorro.Components.Comments {
    /// <summary>
    /// 评论内容,生成的标签为&lt;nz-comment-content>&lt;/nz-comment-content>
    /// </summary>
    [HtmlTargetElement( "util-comment-content" )]
    public class CommentContentTagHelper : AngularTagHelperBase {
        /// <inheritdoc />
        protected override IHtmlContent GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new CommentContentRender( config );
        }
    }
}