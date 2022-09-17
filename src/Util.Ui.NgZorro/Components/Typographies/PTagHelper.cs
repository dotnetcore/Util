using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Builders;

namespace Util.Ui.NgZorro.Components.Typographies {
    /// <summary>
    /// 段落，生成的标签为&lt;p nz-typography&gt;&lt;/p&gt;
    /// </summary>
    [HtmlTargetElement( "util-p" )]
    public class PTagHelper : TypographyTagHelper {
        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            return new PBuilder();
        }
    }
}
