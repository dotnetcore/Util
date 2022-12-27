using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Descriptions.Helpers;
using Util.Ui.NgZorro.Components.Descriptions.Renders;

namespace Util.Ui.NgZorro.Components.Descriptions {
    /// <summary>
    /// 描述列表项,生成的标签为&lt;nz-descriptions-item>&lt;/nz-descriptions-item>
    /// </summary>
    [HtmlTargetElement( "util-descriptions-item" )]
    public class DescriptionItemTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private Config _config;
        /// <summary>
        /// 属性表达式
        /// </summary>
        public ModelExpression For { get; set; }
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
        /// <summary>
        /// 日期格式化字符串，默认值: yyyy-MM-dd HH:mm,仅在使用属性表达式For时有效,格式说明：
        /// 1. 年 - yyyy
        /// 2. 月 - MM
        /// 3. 日 - dd
        /// 4. 时 - HH
        /// 5. 分 - mm
        /// 6. 秒 - ss
        /// 7. 毫秒 - SSS
        /// </summary>
        public string DateFormat { get; set; }

        /// <inheritdoc />
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config = new Config( context, output );
            LoadExpression();
        }

        /// <summary>
        /// 加载表达式
        /// </summary>
        private void LoadExpression() {
            var loader = new DescriptionItemExpressionLoader();
            loader.Load( _config );
        }

        /// <inheritdoc />
        protected override IHtmlContent GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new DescriptionItemRender( _config );
        }
    }
}