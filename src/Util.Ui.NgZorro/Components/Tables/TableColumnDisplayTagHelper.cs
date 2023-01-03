using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Tables {
    /// <summary>
    /// 表格编辑列显示区域,生成的标签为&lt;ng-container>&lt;/ng-container>
    /// </summary>
    [HtmlTargetElement( "util-td-display", ParentTag = "util-td" )]
    public class TableColumnDisplayTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 配置
        /// </summary>
        private Config _config;

        /// <inheritdoc />
        protected override void ProcessBefore( TagHelperContext context, TagHelperOutput output ) {
            _config = new Config( context, output );
        }

        /// <inheritdoc />
        protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
            _config.Content = content;
            return new TableColumnDisplayRender( _config );
        }
    }
}