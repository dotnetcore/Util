using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Builders;

namespace Util.Ui.NgZorro.Components.Typographies {
    /// <summary>
    /// div，生成的标签为&lt;div nz-typography&gt;&lt;/div&gt;
    /// </summary>
    [HtmlTargetElement( "util-div" )]
    public class DivTagHelper : TypographyTagHelper {
        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            return new DivBuilder();
        }
    }
}
