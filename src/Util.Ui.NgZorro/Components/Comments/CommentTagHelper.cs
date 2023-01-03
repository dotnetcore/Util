using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Comments.Configs;
using Util.Ui.NgZorro.Components.Comments.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Comments {
    /// <summary>
    /// 评论,生成的标签为&lt;nz-comment>&lt;/nz-comment>
    /// </summary>
    [HtmlTargetElement( "util-comment" )]
    public class CommentTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzAuthor,作者,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// [nzAuthor],作者,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string BindAuthor { get; set; }
        /// <summary>
        /// nzDatetime,时间描述,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string Datetime { get; set; }
        /// <summary>
        /// [nzDatetime],时间描述,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string BindDatetime { get; set; }

        /// <summary>
        /// 渲染前操作
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="output">输出</param>
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            context.SetValueToItems( new CommentShareConfig() );
        }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new CommentRender( config );
        }
    }
}