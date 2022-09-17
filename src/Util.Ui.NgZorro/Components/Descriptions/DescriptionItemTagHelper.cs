using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Descriptions.Renders;

namespace Util.Ui.NgZorro.Components.Descriptions {
    /// <summary>
    /// 描述列表项,生成的标签为&lt;nz-descriptions-item>&lt;/nz-descriptions-item>
    /// </summary>
    [HtmlTargetElement( "util-descriptions-item" )]
    public class DescriptionItemTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzTitle,标题,类型: string|TemplateRef&lt;void>
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// [nzTitle],标题,类型: string|TemplateRef&lt;void>
        /// </summary>
        public string BindTitle { get; set; }
        /// <summary>
        /// nzSpan,包含列的数量,默认值: 1
        /// </summary>
        public int Span { get; set; }
        /// <summary>
        /// [nzSpan],包含列的数量,默认值: 1
        /// </summary>
        public string BindSpan { get; set; }

        /// <inheritdoc />
        protected override IHtmlContent GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new DescriptionItemRender( config );
        }
    }
}