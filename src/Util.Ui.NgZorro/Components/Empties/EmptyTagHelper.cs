using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Empties.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Empties {
    /// <summary>
    /// 空状态,生成的标签为&lt;nz-empty>&lt;/nz-empty>
    /// </summary>
    [HtmlTargetElement( "util-empty" )]
    public class EmptyTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzNotFoundImage,设置显示图片,当设置字符串值时表示图片地址,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string NotFoundImage { get; set; }
        /// <summary>
        /// [nzNotFoundImage],设置显示图片,当设置字符串值时表示图片地址,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string BindNotFoundImage { get; set; }
        /// <summary>
        /// nzNotFoundContent,设置描述内容,类型: string | TemplateRef&lt;void> | null
        /// </summary>
        public string NotFoundContent { get; set; }
        /// <summary>
        /// [nzNotFoundContent],设置描述内容,类型: string | TemplateRef&lt;void> | null
        /// </summary>
        public string BindNotFoundContent { get; set; }
        /// <summary>
        /// nzNotFoundFooter,设置底部内容,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string NotFoundFooter { get; set; }
        /// <summary>
        /// [nzNotFoundFooter],设置底部内容,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string BindNotFoundFooter { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new EmptyRender( config );
        }
    }
}