using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Cards.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Cards {
    /// <summary>
    /// 卡片元信息,生成的标签为&lt;nz-card-meta>&lt;/nz-card-meta>
    /// </summary>
    [HtmlTargetElement( "util-card-meta" )]
    public class CardMetaTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzTitle,标题,类型: string|TemplateRef&lt;void>
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// [nzTitle],标题,类型: string|TemplateRef&lt;void>
        /// </summary>
        public string BindTitle { get; set; }
        /// <summary>
        /// [nzAvatar],头像,类型: TemplateRef&lt;void>
        /// </summary>
        public string Avatar { get; set; }
        /// <summary>
        /// nzDescription,描述,类型: string|TemplateRef&lt;void>
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// [nzDescription],描述,类型: string|TemplateRef&lt;void>
        /// </summary>
        public string BindDescription { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new CardMetaRender( config );
        }
    }
}