using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Results.Renders;
using Util.Ui.NgZorro.Enums;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Results {
    /// <summary>
    /// 结果,生成的标签为&lt;nz-result>&lt;/nz-result>
    /// </summary>
    [HtmlTargetElement( "util-result" )]
    public class ResultTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzTitle,标题,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// [nzTitle],标题,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string BindTitle { get; set; }
        /// <summary>
        /// nzSubTitle,副标题,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string Subtitle { get; set; }
        /// <summary>
        /// [nzSubTitle],副标题,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string BindSubtitle { get; set; }
        /// <summary>
        /// nzStatus,结果状态，决定图标和颜色,可选值: 'success' | 'error' | 'info' | 'warning'| '404' | '403' | '500',默认值: 'info'
        /// </summary>
        public ResultStatus Status { get; set; }
        /// <summary>
        /// [nzStatus],结果状态，决定图标和颜色,可选值: 'success' | 'error' | 'info' | 'warning'| '404' | '403' | '500',默认值: 'info'
        /// </summary>
        public string BindStatus { get; set; }
        /// <summary>
        /// nzIcon,图标,类型: string | TemplateRef&lt;void>
        /// </summary>
        public AntDesignIcon Icon { get; set; }
        /// <summary>
        /// [nzIcon],图标,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string BindIcon { get; set; }
        /// <summary>
        /// [nzExtra],操作区,类型: string | TemplateRef&lt;void>
        /// </summary>
        public string Extra { get; set; }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            var config = new Config( context, output, content );
            return new ResultRender( config );
        }
    }
}