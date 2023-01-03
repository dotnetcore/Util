using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Anchors.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Anchors {
    /// <summary>
    /// 锚点链接,生成的标签为&lt;nz-link>&lt;/nz-link>
    /// </summary>
    [HtmlTargetElement( "util-link" )]
    public class LinkTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzHref,锚点链接
        /// </summary>
        public string Href { get; set; }
        /// <summary>
        /// [nzHref],锚点链接
        /// </summary>
        public string BindHref { get; set; }
        /// <summary>
        /// nzTitle,标题,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// [nzTitle],标题,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string BindTitle { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new LinkRender( config );
        }
    }
}