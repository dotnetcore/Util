using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Util.Ui.NgZorro.Components.Tables.Helpers;
using Util.Ui.NgZorro.Components.TreeTables.Renders;

namespace Util.Ui.NgZorro.Components.TreeTables {
    /// <summary>
    /// 树形表格,生成的标签为&lt;nz-table>&lt;/nz-table>
    /// </summary>
    [HtmlTargetElement( "util-tree-table" )]
    public class TreeTableTagHelper : TableTagHelper {
        /// <summary>
        /// 配置
        /// </summary>
        private Config _config;

        /// <inheritdoc />
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config = new Config( context, output );
            var service = new TableService( _config );
            service.Init();
            service.InitTreeTable();
        }

        /// <inheritdoc />
        protected override IHtmlContent GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new TreeTableRender( _config );
        }
    }
}