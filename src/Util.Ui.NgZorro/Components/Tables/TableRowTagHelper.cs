using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Helpers;
using Util.Ui.NgZorro.Components.Tables.Renders;
using Util.Ui.Renders;

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
        /// <summary>
        /// (click),行单击事件，使用row访问行对象，范例：on-click="click(row)"
        /// </summary>
        public string OnClick { get; set; }

        /// <inheritdoc />
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config = new Config( context, output );
            var service = new TableRowService( _config );
            service.Init();
        }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new TableRowRender( _config );
        }
    }
}