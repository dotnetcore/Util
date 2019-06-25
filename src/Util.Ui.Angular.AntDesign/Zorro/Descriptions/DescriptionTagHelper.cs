using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.Base;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;
using Util.Ui.Zorro.Descriptions.Renders;

namespace Util.Ui.Zorro.Descriptions {
    /// <summary>
    /// 描述列表
    /// </summary>
    [HtmlTargetElement( "util-description")]
    public class DescriptionTagHelper : AngularTagHelperBase {
        /// <summary>
        /// nzTitle,标题，显示在最顶部
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// [nzBordered],是否显示边框,默认值：false
        /// </summary>
        public bool ShowBorder { get; set; }
        /// <summary>
        /// [nzColumn],可以是数字，表示一行包含的描述项数量，也可以写成像素值或响应式的对象写法，范例：{ xs: 8, sm: 16, md: 24}
        /// </summary>
        public string Column { get; set; }
        /// <summary>
        /// nzSize,列表的大小,只有设置 ShowBorder 为 true 时生效
        /// </summary>
        public DescriptionSize Size { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new DescriptionRender( new Config( context ) );
        }
    }
}