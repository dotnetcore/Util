using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Helpers;
using Util.Ui.NgZorro.Components.Tables.Renders;

namespace Util.Ui.NgZorro.Components.Tables {
    /// <summary>
    /// 表格行,生成的标签为&lt;tr>&lt;/tr>
    /// </summary>
    [HtmlTargetElement( "util-tr" )]
    public class TableRowTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private Config _config;
        /// <summary>
        /// 是否启用自动创建嵌套结构,默认为 true
        /// </summary>
        public bool EnableAutoCreate { get; set; }
        /// <summary>
        /// [nzExpand],当前列是否展开，与 td 上的 nzExpand 属性配合使用
        /// </summary>
        public string Expand { get; set; }

        /// <inheritdoc />
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config = new Config( context, output );
            var service = new TableRowService( _config );
            service.Init();
        }

        /// <inheritdoc />
        protected override IHtmlContent GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new TableRowRender( _config );
        }
    }
}