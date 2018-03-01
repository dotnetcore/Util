using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material.Lists.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Lists.TagHelpers {
    /// <summary>
    /// 列表项
    /// </summary>
    [HtmlTargetElement( "util-list-item" )]
    public class ListItemTagHelper : TagHelperBase {
        /// <summary>
        /// ngFor指令，范例：let item of items
        /// </summary>
        public string NgFor { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new ListItemRender( new Config( context ) );
        }
    }
}