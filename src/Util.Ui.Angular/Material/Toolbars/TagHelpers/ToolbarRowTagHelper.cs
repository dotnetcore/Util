using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material.Toolbars.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Toolbars.TagHelpers {
    /// <summary>
    /// 工具栏项
    /// </summary>
    [HtmlTargetElement( "util-toolbar-row" )]
    public class ToolbarRowTagHelper : TagHelperBase {
        /// <summary>
        /// 标识，指向模板引用变量，而不是Id属性
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new ToolbarRowRender( new Config( context ) );
        }
    }
}