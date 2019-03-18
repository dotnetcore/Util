using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Material.Dividers.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Dividers.TagHelpers {
    /// <summary>
    /// 分隔线
    /// </summary>
    [HtmlTargetElement( "util-divider",TagStructure = TagStructure.WithoutEndTag)]
    public class DividerTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 分隔线两端是否存在间距
        /// </summary>
        public bool Inset { get; set; }
        /// <summary>
        /// 垂直方向
        /// </summary>
        public bool Vertical { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new DividerRender( new Config( context ) );
        }
    }
}