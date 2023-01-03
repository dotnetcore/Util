using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Lists.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Lists {
    /// <summary>
    /// 列表项元信息,生成的标签为&lt;nz-list-item-meta>&lt;/nz-list-item-meta>
    /// </summary>
    [HtmlTargetElement( "util-list-item-meta" )]
    public class ListItemMetaTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzAvatar,头像图标,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string Avatar { get; set; }
        /// <summary>
        /// [nzAvatar],头像图标,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string BindAvatar { get; set; }
        /// <summary>
        /// nzDescription,描述内容,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// [nzDescription],描述内容,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string BindDescription { get; set; }
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
            return new ListItemMetaRender( config );
        }
    }
}