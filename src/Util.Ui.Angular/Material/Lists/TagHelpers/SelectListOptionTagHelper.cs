using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material.Lists.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Lists.TagHelpers {
    /// <summary>
    /// 选择列表项，该标签应放到 util-select-list 中
    /// </summary>
    [HtmlTargetElement( "util-select-list-item" )]
    public class SelectListOptionTagHelper : TagHelperBase {
        /// <summary>
        /// ngFor指令，范例：let item of items
        /// </summary>
        public string NgFor { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new SelectListOptionRender( new Config( context ) );
        }
    }
}